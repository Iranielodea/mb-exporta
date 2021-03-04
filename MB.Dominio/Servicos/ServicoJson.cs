using MB.Dominio.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MB.Dominio.Servicos
{
    public class ServicoJson<T>
    {
        //public T Insert(string uri, object model)
        public Mensagem Insert(string uri, object model)
        {
            uri = Constantes.URL + uri;
            try
            {
                using (var client = new HttpClient())
                {
                    var serializedObj = JsonConvert.SerializeObject(model);

                    var content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        var temp = JsonConvert.DeserializeObject<Mensagem>(retorno);
                    return temp;
                    //return T;
                    
                    }
                    else
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        var temp = JsonConvert.DeserializeObject<Mensagem>(retorno);
                        return temp;
                        //throw new Exception("Erro: " + temp.mensagem);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Mensagem Update(string uri, object model)
        {
            uri = Constantes.URL + uri;
            try
            {
                using (var client = new HttpClient())
                {
                    var serializedObj = JsonConvert.SerializeObject(model);
                    var content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PutAsync(uri, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<Mensagem>(retorno);
                    }
                    else
                        throw new Exception("Erro: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T Delete(string uri)
        {
            uri = Constantes.URL + uri;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    HttpResponseMessage response = client.DeleteAsync(uri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T>(retorno);
                    }
                    else
                    {
                        throw new Exception("Falha ao excluir o produto  : " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T First(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(uri).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T>(retorno);
                    }
                    else
                    {
                        throw new Exception("Erro: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T[] GetAll(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = client.GetAsync(uri).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T[]>(retorno);
                    }
                    else
                    {
                        throw new Exception("Erro : " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T[] ObjetoToJSon(string uri, object model)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var serializedObj = JsonConvert.SerializeObject(model);
                    var content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(uri, content).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<T[]>(retorno);
                    }
                    else
                    {
                        var retorno = response.Content.ReadAsStringAsync().Result;
                        var temp = JsonConvert.DeserializeObject<Mensagem>(retorno);
                        throw new Exception("Erro: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    public class Mensagem
    {
        public string mensagem { get; set; }
    }
}
