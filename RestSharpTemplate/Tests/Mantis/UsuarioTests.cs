using NUnit.Framework;
using RestSharp;
using RestSharpTemplate.Bases;
using RestSharpTemplate.DBSteps;
using RestSharpTemplate.Helpers;
using RestSharpTemplate.Requests.Mantis;
using System.Collections;

namespace RestSharpTemplate.Tests.Mantis
{
    class UsuarioTests : TestBase
    {
        #region Data Driven Providers
        public static IEnumerable CriarUsuarioDataDriver() {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/DataDriver/CriarUsuarios.csv");
        }
        #endregion

        [Test]
        public void CriarUsuario() {
            #region
            string usuario = "teste";
            string senha = "123456";
            string nome = "Test_User";
            string email = "Test@uol.com";
            string status = "Created";
            #endregion
            UsuarioDBSteps.DeletaUsuario();

            UsuarioRequest usuarioRequest = new UsuarioRequest(Method.POST);
            usuarioRequest.SetBody(usuario,senha,nome,email);
            IRestResponse<dynamic> response = usuarioRequest.ExecuteRequest();
            Assert.AreEqual(status, response.StatusCode.ToString());
            

        }

        [Test]
        [Parallelizable]
        public void DeletaUsuario() {

            #region
            string status = "NoContent";
            #endregion

            UsuarioRequest usuarioRequest = new UsuarioRequest(Method.DELETE,UsuarioDBSteps.RetornaIdUsuario());
            IRestResponse<dynamic> response = usuarioRequest.ExecuteRequest();
            Assert.AreEqual(status,response.StatusCode.ToString());

        }   

        [Test]
        public void ObterInformacaoDoUsuarioLogado() {
            #region
            string nome = "administrator";
            string email = "root@localhost";
            string language = "english";
            string timezone = "Asia/Shanghai";
            string nomeAcess = "administrator";
            string label = "administrator";
            string id = "me";
            string status = "OK";
            #endregion

            UsuarioRequest usuarioRequest = new UsuarioRequest(Method.GET,id);
            IRestResponse<dynamic> response = usuarioRequest.ExecuteRequest();
            Assert.AreEqual(status,response.StatusCode.ToString());
            Assert.Multiple(() => {

                Assert.AreEqual(nome, response.Data["name"].ToString());
                StringAssert.IsMatch("[A-Za-z0-9\\._]+@[A-Za-z]+", response.Data["email"].ToString());
                Assert.AreEqual(email, response.Data["email"].ToString());
                Assert.AreEqual(language, response.Data["language"].ToString());
                Assert.AreEqual(timezone, response.Data["timezone"].ToString());
                Assert.AreEqual(nomeAcess, response.Data["access_level"]["name"].ToString());
                Assert.AreEqual(label, response.Data["access_level"]["label"].ToString());


            });

        }

        [Test, TestCaseSource("CriarUsuarioDataDriver")]
        [Parallelizable]
        public void CriarUsuarioDDT(ArrayList usuarioDataDriver) {

            string usuario = usuarioDataDriver[0].ToString() + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string senha = usuarioDataDriver[1].ToString();
            string nome = usuarioDataDriver[2].ToString();
            string email = usuarioDataDriver[3].ToString()+GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string status = "Created";
           

            UsuarioRequest usuarioRequest = new UsuarioRequest(Method.POST);
            usuarioRequest.SetBody(usuario,senha,nome,email);
            IRestResponse<dynamic> response = usuarioRequest.ExecuteRequest();

            Assert.AreEqual(status,response.StatusCode.ToString());
        }

    }
}
