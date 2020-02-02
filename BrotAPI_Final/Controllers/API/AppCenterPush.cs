﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BrotAPI_Final.Controllers.API
{
    public class AppCenterPush
    {
        User receiver = new User();

        public AppCenterPush(Dictionary<string, string> dicInstallIdPlatform)
        {
            //Simply get all the Install IDs for the receipient with the platform name as the value
            foreach (var key in dicInstallIdPlatform)
            {
                switch (key.Key)
                {
                    case "Android":
                        receiver.AndroidDevices.Add(key.Value);

                        break;

                    case "iOS":
                        receiver.IOSDevices.Add(key.Value);

                        break;
                }
            }
        }

        public class Constants
        {
            public const string Url = "https://appcenter.ms/api/v0.1/apps";
            public const string ApiKeyName = "X-API-Token";

            //Push required to use this. Go to https://docs.microsoft.com/en-us/appcenter/api-docs/index for instruction
            public const string FullAccessToken = "bc47566d004675653b118cb161b08d7bad7480ce";

            public const string DeviceTarget = "devices_target";
            public class Apis { public const string Notification = "push/notifications"; }

            //You can find your AppName and Organization/User name at your AppCenter URL as such https://appcenter.ms/users/{owner-name}/apps/{app-name}
            public const string AppNameAndroid = "Brot";
            public const string AppNameIOS = "Brot_IOS";

            public const string Organization = "Coffee-Breakers";
        }

        [JsonObject]
        public class Push
        {
            [JsonProperty("notification_target")]
            public Target Target { get; set; }

            [JsonProperty("notification_content")]
            public Content Content { get; set; }
        }

        [JsonObject]
        public class Content
        {
            public Content()
            {
                Name = "default";   //By default cannot be empty, must have at least 3 characters
            }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("body")]
            public string Body { get; set; }

            [JsonProperty("custom_data")]
            public IDictionary<string, string> CustomData { get; set; }
        }

        [JsonObject]
        public class Target
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("devices")]
            public IEnumerable Devices { get; set; }
        }

        public class User
        {
            public User()
            {
                IOSDevices = new List<string>();
                AndroidDevices = new List<string>();
            }

            public List<string> IOSDevices { get; set; }
            public List<string> AndroidDevices { get; set; }
        }

        public async Task<bool> Notify(string name,string title, string message, Dictionary<string, string> customData = default(Dictionary<string, string>))
        {
            try
            {
                //title, message length cannot exceed 100 char
                if (title.Length > 100)
                    title = title.Substring(0, 95) + "...";

                if (message.Length > 100)
                    message = message.Substring(0, 95) + "...";

                if (!receiver.IOSDevices.Any() && !receiver.AndroidDevices.Any())
                    return false; //No devices to send

                //To make sure in Android, title and message is retain when click from notification. Else it's lost when app is in background
                if (customData == null)
                    customData = new Dictionary<string, string>();

                if (!customData.ContainsKey("Title"))
                    customData.Add("Title", title);

                if (!customData.ContainsKey("Message"))
                    customData.Add("Message", message);

                //custom data cannot exceed 100 char 
                foreach (string key in customData.Keys)
                {
                    if (customData[key].Length > 100)
                    {
                        customData[key] = customData[key].Substring(0, 95) + "...";
                    }
                }

                var push = new Push
                {
                    Content = new Content
                    {
                        Name=name,
                        Title = title,
                        Body = message,
                        CustomData = customData
                    },
                    Target = new Target
                    {
                        Type = Constants.DeviceTarget
                    }
                };

                HttpClient httpClient = new HttpClient();

                //Set the content header to json and inject the token
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Add(Constants.ApiKeyName, Constants.FullAccessToken);

                //Needed to solve SSL/TLS issue when 
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                //TODO Dividir en Bloques de 100 Push

                if (receiver.IOSDevices.Any())
                {
                    push.Target.Devices = receiver.IOSDevices;

                    string content = JsonConvert.SerializeObject(push);

                    HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                    string URL = $"{Constants.Url}/{Constants.Organization}/{Constants.AppNameIOS}/{Constants.Apis.Notification}";

                    var result = await httpClient.PostAsync(URL, httpContent);
                }

                if (receiver.AndroidDevices.Any())
                {
                    push.Target.Devices = receiver.AndroidDevices;

                    string content = JsonConvert.SerializeObject(push);

                    HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                //https://appcenter.ms/api/v0.1/apps/Coffee-Breakers/Brot/push/notifications
                    string URL = $"{Constants.Url}/{Constants.Organization}/{Constants.AppNameAndroid}/{Constants.Apis.Notification}";

                    var result = await httpClient.PostAsync(URL, httpContent);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return false;
            }
        }
    }
}