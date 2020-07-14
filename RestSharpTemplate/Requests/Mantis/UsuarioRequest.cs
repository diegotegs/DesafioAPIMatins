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
    //TODO: Mapear requisição de gerar token e incluir no onetime setup.
    public class UsuarioRequest : RequestBase
    {
        public UsuarioRequest(Method metodo) {
            headers.Add("Authorization", Properties.Settings.Default.TOKEN);
            requestService = "/api/rest/users/";
            SetMethod(metodo);
        }

        public UsuarioRequest(Method metodo, string id) {
            headers.Add("Authorization", Properties.Settings.Default.TOKEN);
            requestService = "/api/rest/users/{id}";
            parameters.Add("id",id);
            method = metodo;
        }

        public void SetBody(string usuario, string senha, string nome, string email) {

            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Mantis/CriarUsuario.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$usuario", usuario);
            jsonBody = jsonBody.Replace("$senha", senha);
            jsonBody = jsonBody.Replace("$nome", nome);
            jsonBody = jsonBody.Replace("$email", email);

        }
    }
}
