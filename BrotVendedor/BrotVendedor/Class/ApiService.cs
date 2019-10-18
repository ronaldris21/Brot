using BrotVendedor.Model;
using DLL.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace BrotVendedor.Class
{
    public class ApiService
    {
        String url= "http://brotproject.somee.com/api/";
        HttpClient cliente = new HttpClient();
        public static bool isConnectedToInterned()  //Lo ideal seria mandar esto desde la app antes de usar el REST
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                return true;
            }

            return false;
        }
        public async Task<Response> GetAll<T>(String controller)
        {
            if (isConnectedToInterned())
            {
                try
                {
                    var response = await cliente.GetAsync(url + controller);
                    if (!response.IsSuccessStatusCode)
                    {
                        return new Response
                        {
                            isSuccess = false,
                            Message = await response.Content.ReadAsStringAsync()
                        };
                    }
                    var json = await response.Content.ReadAsStringAsync();
                    return new Response
                    {
                        isSuccess = true,
                        Result = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<T>>(json)
                    };
                }
                catch (Exception e)
                {
                    return new Response
                    {
                        isSuccess = false,
                        Message = e.Message
                    };
                }
            }
            return new Response()
            {
                isSuccess = false,
                Message = "No es posible conectarse a internet"
            };
           

        }
        public async Task<Response> GetById<T>(String controller,String id)
        {
            if (isConnectedToInterned())
            {
                try
                {
                    var response = await cliente.GetAsync(url + controller + "/" + id);
                    if (!response.IsSuccessStatusCode)
                    {
                        return new Response
                        {
                            Message = await response.Content.ReadAsStringAsync(),
                            isSuccess = false
                        };
                    }
                    var json = await response.Content.ReadAsStringAsync();
                    return new Response
                    {
                        isSuccess = true,
                        Result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json)
                    };
                }
                catch (Exception e)
                {
                    return new Response
                    {
                        Message = e.Message,
                        isSuccess = false
                    };
                }
            }
            return new Response()
            {
                isSuccess = false,
                Message = "No es posible conectarse a internet"
            };
            
            
        }
        public async Task<Response> Post<T>(String controller,T item)
        {
            if (isConnectedToInterned())
            {
                try
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await cliente.PostAsync(url + controller, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        return new Response
                        {
                            isSuccess = false,
                            Message = await response.Content.ReadAsStringAsync()
                        };
                    }
                    try
                    {
                        T result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                        if (item.GetType().Equals(typeof(userModel)))
                        {
                            return new Response
                            {
                                isSuccess = true,
                                Result = result
                            };
                        }
                    }
                    catch (Exception)
                    {
                        return new Response
                        {
                            isSuccess = true,
                            Result = await response.Content.ReadAsStringAsync()
                        };
                    }
                    return new Response
                    {
                        isSuccess = true,
                        Result = await response.Content.ReadAsStringAsync()
                    };
                }
                catch (Exception e)
                {
                    return new Response
                    {
                        isSuccess = false,
                        Message = e.Message
                    };
                }
            }
            return new Response()
            {
                isSuccess = false,
                Message = "No es posible conectarse a internet"
            };
        }
        public async Task<Response> Put<T>(String controller,int id,T item)
        {
            if (isConnectedToInterned())
            {


                try
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(item);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    var response = await cliente.PutAsync(url + controller + "/" + id, content);
                    if (!response.IsSuccessStatusCode)
                    {
                        return new Response
                        {
                            isSuccess = false,
                            Message = await response.Content.ReadAsStringAsync()
                        };
                    }
                    return new Response
                    {
                        isSuccess = true,
                        Result = await response.Content.ReadAsStringAsync()
                    };
                }
                catch (Exception e)
                {
                    return new Response
                    {
                        isSuccess = false,
                        Message = e.Message
                    };
                }
            }
            return new Response()
            {
                isSuccess = false,
                Message = "No es posible conectarse a internet"
            };
        }
    }
}
