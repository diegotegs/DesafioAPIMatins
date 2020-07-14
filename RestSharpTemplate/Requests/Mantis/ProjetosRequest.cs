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
    public class ProjetosRequest : RequestBase {
        public ProjetosRequest() {
            requestService = "/api/rest/projects/";
            SetMethod(Method.GET);
            headers.Add("Authorization", Properties.Settings.Default.TOKEN);

        }
        public ProjetosRequest(Method method) {
            requestService = "/api/rest/projects/";            
            SetMethod(method);
            headers.Add("Authorization", Properties.Settings.Default.TOKEN);
        }

        public ProjetosRequest(Method method , string idProjeto) {
            requestService = "/api/rest/projects/{idProjeto}";
            SetMethod(method);
            headers.Add("Authorization", Properties.Settings.Default.TOKEN);
            parameters.Add("idProjeto", idProjeto);
        }
        

        public void SetBody(string id, string nomeProjeto, string idStatus, string nomeStatus, string labelStatus, string desgricao, string enable , string caminho,string idState,string nameState, string labeState) {

            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Mantis/ProjetosJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("idProjeto", id);
            jsonBody = jsonBody.Replace("$nomeProjeto", nomeProjeto);
            jsonBody = jsonBody.Replace("idStatus",idStatus);
            jsonBody = jsonBody.Replace("$nomeStatus",nomeStatus);
            jsonBody = jsonBody.Replace("$labelStatus", labelStatus);
            jsonBody = jsonBody.Replace("enabled",enable);
            jsonBody = jsonBody.Replace("$descricao",desgricao);
            jsonBody = jsonBody.Replace("$caminho", caminho);
            jsonBody = jsonBody.Replace("idState", idState);
            jsonBody = jsonBody.Replace("$nameState", nameState);
            jsonBody = jsonBody.Replace("$labelState", labeState);


        }

        public void SetBoyAtualizarProjeto(string id, string nome, string status) {
            jsonBody= File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Mantis/AtualizarProjeto.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$IdProjeto",id);
            jsonBody = jsonBody.Replace("$NameProjeto",nome);
            jsonBody = jsonBody.Replace("$Status",status);

        }
    }

}

    

