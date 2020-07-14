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
    public class SubProjetosRequest : RequestBase
    {

        public SubProjetosRequest(Method metodo, string idProjeto) {

            requestService = "/api/rest/projects/{$idProjeto}/subprojects";
            method = metodo;
            headers.Add("Authorization", Properties.Settings.Default.TOKEN);
            parameters.Add("$idProjeto", idProjeto);
        }

        public void SetBody(string nomeSubProjeto) {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Mantis/CriarSubProjeto.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$subProjeto", nomeSubProjeto);
        }
    }
}