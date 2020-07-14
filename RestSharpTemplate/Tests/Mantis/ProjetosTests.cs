using NUnit.Framework;
using RestSharp;
using RestSharpTemplate.Bases;
using RestSharpTemplate.DBSteps;
using RestSharpTemplate.Helpers;
using RestSharpTemplate.Requests.Mantis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTemplate.Tests.Mantis
{
    public class ProjetosTests : TestBase
    {
        [Test]
        public void RetornaTodosProjetos() {

            #region paramentros
            string status = "OK";
            #endregion

            ProjetosRequest projetosRequest = new ProjetosRequest();
            IRestResponse<dynamic> response = projetosRequest.ExecuteRequest();
            Assert.AreEqual(status, response.StatusCode.ToString());
        }

        [Test]
        public void RetornaProjetoPorId() {            
            #region
            string statusAPI = "OK";
            string nomeProjeto = ProjetoDBSteps.RetornaProjeto(1);
            string statusNome = "development";
            string statusLabel = "development";
            string idProjeto = ProjetoDBSteps.RetornaIdProjeto();
            #endregion
            ProjetosRequest projetosRequest = new ProjetosRequest(Method.GET, idProjeto);
            IRestResponse<dynamic> response = projetosRequest.ExecuteRequest();
            Assert.AreEqual(statusAPI, response.StatusCode.ToString());            
            Assert.Multiple(() => {
                Assert.AreEqual(statusAPI, response.StatusCode.ToString());
                Assert.AreEqual(nomeProjeto, response.Data["projects"][0]["name"].ToString());
                Assert.AreEqual(statusNome, response.Data["projects"][0]["status"]["name"].ToString());
                Assert.AreEqual(statusLabel, response.Data["projects"][0]["status"]["label"].ToString());
            });

        }


        [Test]
        public void InserirProjeto() {

            #region Parametros
            string nomeProjeto = "Projeto_news_" + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string id = "2";
            string idStatus = "10";
            string nomeStatus = "development";
            string labelStatus = "development";
            string descricao = "Teste api descrissão";
            string enabled = "true";
            string caminho = "/tmp/";
            string idState = "10";
            string nomeView = "public";
            string labelView = "public";
            string statusCode = "Created";
            #endregion

            ProjetosRequest projetosRequest = new ProjetosRequest(Method.POST);
            projetosRequest.SetBody(id, nomeProjeto, idStatus, nomeStatus, labelStatus, descricao, enabled, caminho, idState, nomeView, labelView);
            IRestResponse<dynamic> response = projetosRequest.ExecuteRequest();
            Assert.AreEqual(statusCode,response.StatusCode.ToString());

        }

        [Test]
        public void AtualizarProjeto() {            
            #region Paramentros
            string nomeProjeto = "New_Name_Projeto_" + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string id = ProjetoDBSteps.RetornaIdProjeto();
            string statusCode = "OK";
            string status = "true";
            #endregion

            ProjetosRequest projetosRequest = new ProjetosRequest(Method.PATCH, id);
            projetosRequest.SetBoyAtualizarProjeto(id, nomeProjeto, status);
            IRestResponse<dynamic> response = projetosRequest.ExecuteRequest();
            Assert.AreEqual(statusCode, response.StatusCode.ToString());
        }

        [Test]
        public void DeletarProjeto() {
            ProjetoDBSteps.CriarProjeto();
            #region
            string statusCode = "OK";
            string idProjeto = ProjetoDBSteps.RetornaIdProjeto();
            #endregion
            
            ProjetosRequest projetosRequest = new ProjetosRequest(Method.DELETE, idProjeto);
            IRestResponse responde = projetosRequest.ExecuteRequest();
            Assert.AreEqual(statusCode, responde.StatusCode.ToString());

        }

        [Test] // verificar pq não está criando um subprojeto
        public void AdicionaSubProjeto() {

            #region parametros
            string statusCode = "OK";
            string idProjeto = ProjetoDBSteps.RetornaIdProjeto();
            string nomeSubProjeto = "SubProjeto_"+GeneralHelpers.ReturnStringWithRandomNumbers(2);
            #endregion
            SubProjetosRequest subProjeto = new SubProjetosRequest(Method.POST,idProjeto);
            subProjeto.SetBody(nomeSubProjeto);
            IRestResponse<dynamic> response = subProjeto.ExecuteRequest();
            Assert.AreEqual(statusCode,response.StatusCode.ToString());
            
        }

        [Test]
        public void AdicionarVersion() {
            #region
            string statusCode = "NoContent";
            string idProjeto = ProjetoDBSteps.RetornaIdProjeto();
            string versao = GeneralHelpers.ReturnStringWithRandomNumbers(1)+"."+ GeneralHelpers.ReturnStringWithRandomNumbers(1);
            #endregion

            VersaoRequest versaoRequest = new VersaoRequest(idProjeto);
            versaoRequest.SetBody(versao);
            IRestResponse<dynamic> response = versaoRequest.ExecuteRequest();
            Assert.AreEqual(statusCode, response.StatusCode.ToString());


        }
    }
}
