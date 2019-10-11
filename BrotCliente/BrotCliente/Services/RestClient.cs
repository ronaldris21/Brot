﻿using BrotCliente.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClienteRest.Service
{
    public class ApiService
    {
        private String url = "http://cdsapirest.somee.com/api/";
        public HttpClient cliente = new HttpClient();
        public async Task<Response> GetAll<T>(String Controller)
        {
            try
            {
                var response = await cliente.GetAsync(url + Controller);

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = "Error de respuesta del servidor"
                    };
                }

                var result = await response.Content.ReadAsStringAsync();
                var list = JsonConvert.DeserializeObject<ObservableCollection<T>>(result);

                return new Response
                {
                    IsSuccess = true,
                    Result = list
                };
            }
            catch (Exception e)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = $"Error al cargar los datos {e}"
                };
            }
        }
        public async Task<bool> Post<T>(String Controller, T item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await cliente.PostAsync(url + Controller, content);
                //String mensaje = JsonConvert.DeserializeObject<String>(await response.Content.ReadAsStringAsync());
                //Debug.Print(mensaje);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Delete<T>(String controller, int id)
        {
            try
            {
                HttpResponseMessage response = await cliente.DeleteAsync(url + controller + id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Put<T>(String controller, int id, T item)
        {
            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await cliente.PutAsync(url + controller + id, content);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}