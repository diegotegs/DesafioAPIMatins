using RestSharp;
using RestSharpTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RestSharpTemplate.Bases
{
    public class RequestSoapBase
    {
        #region Parameters
        protected string xmlBody = null;

        protected string url = Properties.Settings.Default.URL;

        protected string requestService = null;

        protected bool httpBasicAuthenticator = false;

        protected bool ntlmAuthenticator = false;

        protected IDictionary<string, string> headers = new Dictionary<string, string>()
        {
            //Dicionário de headeres deve ser iniciado com os headers comuns a todos os métodos da API
            {"Content-Type", "text/xml;charset=UTF-8"},
            {"SOAPAction", ""}
        };

        protected IDictionary<string, string> cookies = new Dictionary<string, string>()
        {
            //Dicionário de cookies deve ser iniciado com os headers comuns à todas os métodos da API
        };
        #endregion

        #region Actions
        public IRestResponse<dynamic> ExecuteRequest()
        {
            var response = RestSharpHelpers.ExecuteSoapRequest(url, headers, cookies, xmlBody, httpBasicAuthenticator, ntlmAuthenticator);
            ExtentReportHelpers.AddTestInfoXml(url, requestService, headers, cookies, xmlBody, httpBasicAuthenticator, ntlmAuthenticator, response);
            
            return response;
        }

        public void RemoveHeader(string header)
        {
            headers.Remove(header);
        }

        public void RemoveCookie(string cookie)
        {
            cookies.Remove(cookie);
        }
        #endregion
    }
}
