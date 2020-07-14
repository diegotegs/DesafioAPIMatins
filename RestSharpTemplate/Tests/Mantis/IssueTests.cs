using NUnit.Framework;
using RestSharp;
using RestSharpTemplate.Bases;
using RestSharpTemplate.DBSteps;
using RestSharpTemplate.Helpers;
using RestSharpTemplate.Requests.Mantis;


namespace RestSharpTemplate.Tests.Mantis
{
    public class IssueTests : TestBase
    {
        [Test]
        public void CriarIssueMinimal() {
            #region
            string summary = "Summary_" + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string descricao = "descricao_" + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string nomeCategoria = "General";
            string nomeProjeto = "Nome_Projeto 30";
            string status = "Created";
            #endregion
            IssueRequest issueRequest = new IssueRequest(Method.POST);
            issueRequest.SetBodyIssueMinimal(summary, descricao, nomeCategoria, nomeProjeto);
            IRestResponse<dynamic> response = issueRequest.ExecuteRequest();

            Assert.AreEqual(status, response.StatusCode.ToString());

        }

        [Test]
        public void GetUmIssueNaoEncontrado() {

            #region
            string id = "123";
            string msg = "Issue #123 not found";
            string code = "1100";
            string localized = "Issue 123 not found.";
            #endregion
            IssueRequest issueRequest = new IssueRequest(Method.GET, id);
            IRestResponse<dynamic> response = issueRequest.ExecuteRequest();
            Assert.Multiple(() => {
                Assert.AreEqual(msg, response.Data["message"].ToString());
                Assert.AreEqual(code, response.Data["code"].ToString());
                Assert.AreEqual(localized, response.Data["localized"].ToString());

            });
        }

        [Test]
        public void GetUmIssueComSucesso() {

            #region
            string id = "22";
            string summary = "tarefa_Test";
            string description = "Descrição Testes";
            string nameProjeto = "Nome_Projeto 40";
            string nameCategory = "General";
            string nameviewState = "public";
            string statusCode = "OK";

            #endregion
            IssueRequest issueRequest = new IssueRequest(Method.GET, id);
            IRestResponse<dynamic> response = issueRequest.ExecuteRequest();
            Assert.Multiple(() => {
                Assert.AreEqual(summary, response.Data["issues"][0]["summary"].ToString());
                Assert.AreEqual(description, response.Data["issues"][0]["description"].ToString());
                Assert.AreEqual(nameProjeto, response.Data["issues"][0]["project"]["name"].ToString());
                Assert.AreEqual(nameCategory, response.Data["issues"][0]["category"]["name"].ToString());
                Assert.AreEqual(nameviewState, response.Data["issues"][0]["view_state"]["name"].ToString());

                Assert.AreEqual(statusCode, response.StatusCode.ToString());
            });
        }

        [Test]
        public void CriarIssueComAcessorios() {
            #region
            string summary = "Sample REST issue with attachment";
            string description = "Description for sample REST issue.";
            string name = "mantisbt";
            string nameCategory = "bugtracker";
            string customFieldsName = "The City";
            string value = "Seattle";
            string fileName1 = "test.txt";
            string fileContent1 = "VGhpcyBpcyBhIFRFU1QuDQpUaGlzIGlzIGEgVEVTVC4NClRoaXMgaXMgYSBURVNULg0KVGhpcyBpcyBhIFRFU1QuDQpUaGlzIGlzIGEgVEVTVC4";
            string fileName2 = "test2.txt";
            string fileContent2 = "VGhpcyBpcyBhIFRFU1QuDQpUaGlzIGlzIGEgVEVTVC4NClRoaXMgaXMgYSBURVNULg0KVGhpcyBpcyBhIFRFU1QuDQpUaGlzIGlzIGEgVEVTVC4";
            string statusCode = "OK";
            #endregion


            IssueRequest issueRequest = new IssueRequest(Method.POST);
            issueRequest.SetBodyIssueWithAttachments(summary, description, name, nameCategory, customFieldsName, value, fileName1, fileContent1, fileName2, fileContent2);
            IRestResponse<dynamic> response = issueRequest.ExecuteRequest();
            Assert.AreEqual(statusCode, response.StatusCode.ToString());

        }

        [Test]
        public void DeletaIssue() {
            #region
            string statusCode = "NoContent";

            #endregion

            IssueRequest issueRequest = new IssueRequest(Method.DELETE, IssueDBSteps.RetornaIdIssue());
            IRestResponse<dynamic> response = issueRequest.ExecuteRequest();
            Assert.AreEqual(statusCode, response.StatusCode.ToString());


        }


    }
}
