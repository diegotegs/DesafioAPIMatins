using NUnit.Framework;
using RestSharpTemplate.DBSteps;
using RestSharpTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTemplate.Bases
{
    public class TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            UsuarioDBSteps.DeletaUsuario();
            ExtentReportHelpers.CreateReport();
        }

        [SetUp]
        public void SetUp()
        {
            ProjetoDBSteps.LimparProjeto();
            ExtentReportHelpers.AddTest();
            ProjetoDBSteps.CriarProjeto();
        }

        [TearDown]
        public void TearDown()
        {
            ExtentReportHelpers.AddTestResult();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReportHelpers.GenerateReport();
        }
    }
}
