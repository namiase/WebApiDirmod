using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Invoker
{
    /// <summary>
    /// Autor: Enderson Namias
    /// Fecha: 11-11-2019
    /// Descripción: Metodo para la invocacion una pagina
    /// </summary>
    /// <returns></returns>
    public class Invoker
    {
        #region Variables
        private const string _errorBaseJSON = @"{{'error':true,'clientErrorDetail':'{0}','apiDetail':'{1}' }}";
        private const string _errorBaseListJSON = @"[{{'error':true,'clientErrorDetail':'{0}','apiDetail':'{1}' }}]";
        private string _path = string.Empty;
        private HttpRequestMessage _request;
        #endregion

        #region Constructor
        public Invoker(HttpRequestMessage request)
        {
            try
            {
                _request = request;
            }
            catch (Exception ex)
            {
                throw ex; //Regresa valor a una pagina al producirse un error
            }
        }
        #endregion

        #region Get

        public object get(string apiDefination, Type dataType)
        {
            var url = string.Empty;
            try
            {
                var client = new HttpClient();
                url = string.Format("{0}{1}", _path, apiDefination);

                var json = client.GetAsync(url).Result;
                if (json.IsSuccessStatusCode)
                {
                    var answer = JsonConvert.DeserializeObject(json.Content.ReadAsStringAsync().Result, dataType);
                    return answer;
                }
                else
                    return this.jsonResponseErrorHandler(json, dataType, url);
            }
            catch (Exception ex)
            {
                return this.exceptionErrorHandler(ex, dataType, url);
            }
        }



        #endregion

        #region Methods

        object jsonResponseErrorHandler(HttpResponseMessage json, Type type, string apiDetail)
        {
            //var message = (internalError)JsonConvert.DeserializeObject(json.Content.ReadAsStringAsync().Result, typeof(internalError));
            //var exception = new Exception(string.Format("Request Error - {0}", json.StatusCode), new Exception());
            var finalJson = string.Empty;
            if (type.ToString().Contains("List"))
                finalJson = string.Format(_errorBaseListJSON, "Ha ocurrido un error inesperado. Detalle = " + json.StatusCode.ToString(), apiDetail);
            else
                finalJson = string.Format(_errorBaseJSON, "Ha ocurrido un error inesperado. Detalle = " + json.StatusCode.ToString(), apiDetail);

            var answer = JsonConvert.DeserializeObject(finalJson, type);
            return answer;
        }

        object exceptionErrorHandler(Exception ex, Type type, string apiDetail)
        {
            var finalJson = string.Empty;
            if (type.ToString().Contains("List"))
                finalJson = string.Format(_errorBaseListJSON, "Ha ocurrido un error inesperado.", apiDetail);
            else
                finalJson = string.Format(_errorBaseJSON, "Ha ocurrido un error inesperado.", apiDetail);

            var answer = JsonConvert.DeserializeObject(finalJson, type);
            return answer;
        }

        private static string ExtractAuthHeader(System.Net.Http.Headers.HttpRequestHeaders headers, string headerName)
        {
            string result = String.Empty;
            try
            {
                //Check header
                result = String.IsNullOrEmpty(headers.GetValues(headerName).FirstOrDefault()) ? String.Empty : headers.GetValues(headerName).FirstOrDefault();
            }
            catch (Exception)
            {
                //Nothing, the header was not found
            }
            if (String.IsNullOrEmpty(result))
            {
                try
                {
                    //Check Cookie
                    var cookieAuth = GetCookie(headers, headerName);
                    if (cookieAuth != null)
                    {
                        result = cookieAuth;
                    }
                }
                catch
                {
                    // fallback here because it is null
                }
            }
            return result;
        }

        private static string ExtractAuthHeader(System.Collections.Specialized.NameValueCollection headers, string headerName)
        {
            string result = String.Empty;
            try
            {
                //Check header
                result = String.IsNullOrEmpty(headers.GetValues(headerName).FirstOrDefault()) ? String.Empty : headers.GetValues(headerName).FirstOrDefault();
            }
            catch (Exception)
            {
                //Nothing, the header was not found
            }
            if (String.IsNullOrEmpty(result))
            {
                try
                {
                    //Check Cookie
                    var cookieAuth = GetCookie(headers, headerName);
                    if (cookieAuth != null)
                    {
                        result = cookieAuth;
                    }
                }
                catch
                {
                    // fallback here because it is null
                }
            }
            return result;
        }

        private static string GetCookie(HttpRequestHeaders header, string headerName)
        {
            IEnumerable<string> cookies;
            if (header.TryGetValues("Cookie", out cookies))
            {
                return giveMeAuth(cookies, headerName);
            }
            if (header.TryGetValues("header", out cookies))
            {
                return giveMeAuth(cookies, headerName);
            }
            return null;
        }

        private static string GetCookie(System.Collections.Specialized.NameValueCollection header, string headerName)
        {
            IEnumerable<string> cookies;
            cookies = header.GetValues("Cookie");
            if (cookies != null)
            {
                return giveMeAuth(cookies, headerName);
            }
            return null;
        }

        private static string giveMeAuth(IEnumerable<string> _cookies, string headerName)
        {
            foreach (string cookie in _cookies)
            {
                var eval = cookie.Split(';');
                foreach (var item in eval)
                {
                    if (item.Trim().StartsWith(headerName + "="))
                        return item.Trim().Replace(headerName + "=", string.Empty);
                }
            }
            return string.Empty;
        }

        #endregion
    }
}
