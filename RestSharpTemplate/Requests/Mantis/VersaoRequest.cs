using RestSharp;
using RestSharpTemplate.Bases;
using RestSharpTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTemplate.Requests.Mantis
{
    public class VersaoRequest : RequestBase
    {
        public VersaoRequest(string idProjeto) {
            requestService = "/api/rest/projects/{$projeto}/versions/";
            method = Method.POST;
            headers.Add("Authorization", Properties.Settings.Default.TOKEN);
            parameters.Add("$projeto", idProjeto);
        }

        public void SetBody(string nomeVersao) {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath()+"/Jsons/Mantis/AddVersion.json",Encoding.UTF8);
            jsonBody = jsonBody.Replace("$nomeVersao",nomeVersao);

        }
    }
}
