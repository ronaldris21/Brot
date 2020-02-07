//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Text;

//namespace Brot.Services
//{
//    public class FilesService
//    {
//        //Xamarin form 
//        var content = new MultipartFormDataContent();
//        //MediaTypeFormatter md = null;
//        //md.SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
//        content.Add(new StreamContent(_file.GetStream()), "\"file\"", $"\"{_file.Path }\"");
            
//            mdl_status mdlstatus = new mdl_status();
//        mdl_user user = new mdl_user();
//        user.Name_en = "abc";
//            user.MobileNo = "0000";
//            var httpClient = new HttpClient();
//        string serviceURL = "";
//        var response1 = await httpClient.PostAsync<mdl_user>(serviceURL, user, content, "");
//    }
//}
