using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace RestSharpTemplate.Helpers
{
    public class ExtentReportHelpers
    {
        public static ExtentReports EXTENT_REPORT = null;
        public static ExtentTest TEST;

        static string reportName = Properties.Settings.Default.REPORT_NAME + "_" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm");

        static string projectBinDebugPath = AppDomain.CurrentDomain.BaseDirectory;
        static FileInfo fileInfo = new FileInfo(projectBinDebugPath);
        static DirectoryInfo projectFolder = fileInfo.Directory;
        static string projectFolderPath = projectFolder.FullName;
        static string reportRootPath = projectFolderPath + "/Reports/";
        static string reportPath = projectFolderPath + "/Reports/" + reportName + "/";
        static string fileName = reportName + ".html";
        static string fullReportFilePath = reportPath + "_" + fileName;

        public static void CreateReport()
        {
            if (EXTENT_REPORT == null)
            {
                GeneralHelpers.EnsureDirectoryExists(reportRootPath);
                GeneralHelpers.EnsureDirectoryExists(reportPath);

                var htmlReporter = new ExtentHtmlReporter(fullReportFilePath);
                EXTENT_REPORT = new ExtentReports();
                EXTENT_REPORT.AttachReporter(htmlReporter);
            }
        }

        public static void AddTest()
        {
            string testName = TestContext.CurrentContext.Test.MethodName;
            string testCategory = TestContext.CurrentContext.Test.ClassName.Substring(Properties.Settings.Default.REPORT_SUBSTRING_LENGTH);

            TEST = EXTENT_REPORT.CreateTest(testName).AssignCategory(testCategory);
        }

        public static void AddTestInfo(int methodLevel, string text)
        {
            TEST.Log(Status.Pass, GeneralHelpers.GetMethodNameByLevel(methodLevel) + " || " + text);
        }

        public static void AddTestInfo(string url, string requestService, string method, IDictionary<string, string> headers, IDictionary<string, string> cookies, IDictionary<string, string> parameters, string jsonBody, bool httpBasicAuthenticator, bool ntlmAuthenticator, IRestResponse<dynamic> response)
        {
            string allHeaders = null;
            string allCookies = null;
            string allParameters = null;
            string allResponseHeaders = null;

            foreach (var parameter in parameters)
            {
                allParameters = allParameters + "\n" + "<i>" + parameter.Key + "</i>" + " = " + parameter.Value;
            }

            foreach (var header in headers)
            {
                allHeaders = allHeaders + "\n" + "<i>" + header.Key + "</i>" + " = " + header.Value;
            }

            foreach (var cookie in cookies)
            {
                allCookies = allCookies + "\n" + "<i>" + cookie.Key + "</i>" + " = " + cookie.Value;
            }

            foreach (var responseHeader in response.Headers)
            {
                allResponseHeaders = allResponseHeaders + "\n" + responseHeader.ToString();
            }

            TEST.Log(Status.Info, "<pre>" + "<b>URL: </b>" + url + "</pre>");
            TEST.Log(Status.Info, "<pre>" + "<b>REQUEST: </b>" + requestService + "</pre>");
            TEST.Log(Status.Info, "<pre>" + "<b>METHOD: </b>" + method + "</pre>");

            if (allParameters != null)
            {
                TEST.Log(Status.Info, "<pre>" + "<b>PARAMETERS: </b>" + allParameters + "</pre>");
            }

            if(jsonBody != null)
            {
                TEST.Log(Status.Info, "<pre>" + "<b>JSON BODY: </b>" + "\n" + jsonBody + "</pre>");
            }

            if (allHeaders != null)
            {
                TEST.Log(Status.Info, "<pre>" + "<b>HEADERS: </b>" + allHeaders + "</pre>");
            }

            if (allCookies != null)
            {
                TEST.Log(Status.Info, "<pre>" + "<b>COOKIES: </b>" + allCookies + "</pre>");
            }

            if (httpBasicAuthenticator || ntlmAuthenticator)
            {
                TEST.Log(Status.Info, "<pre>" + "<b>AUTHENTICATOR: </b>" + "\n" + "<b>USER: </b>"+ Properties.Settings.Default.AUTHENTICATOR_USER + "\n" + "<b>PASSWORD: </b>" + Properties.Settings.Default.AUTHENTICATOR_PASSWORD + "</pre>");
            }

            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;

            TEST.Log(Status.Info, "<pre>" + "<b>STATUS CODE: </b>" + numericStatusCode + " - " +response.StatusCode.ToString() + "</pre>");
            TEST.Log(Status.Info, "<pre>" + "<b>RESPONSE HEADERS: </b>" + allResponseHeaders + "</pre>");
            TEST.Log(Status.Info, "<pre>" + "<b>PAYLOAD: </b>" + "\n" + GeneralHelpers.FormatJson(response.Content) + "</pre>");
        }

        public static void AddTestInfoXml(string url, string requestService, IDictionary<string, string> headers, IDictionary<string, string> cookies, string xmlBody, bool httpBasicAuthenticator, bool ntlmAuthenticator, IRestResponse<dynamic> response)
        {
            string allHeaders = null;
            string allCookies = null;
            string allResponseHeaders = null;

            foreach (var header in headers)
            {
                allHeaders = allHeaders + "\n" + "<i>" + header.Key + "</i>" + " = " + header.Value;
            }

            foreach (var cookie in cookies)
            {
                allCookies = allCookies + "\n" + "<i>" + cookie.Key + "</i>" + " = " + cookie.Value;
            }

            foreach (var responseHeader in response.Headers)
            {
                allResponseHeaders = allResponseHeaders + "\n" + responseHeader.ToString();
            }

            TEST.Log(Status.Info, "<pre>" + "<b>URL: </b>" + url + "</pre>");
            TEST.Log(Status.Info, "<b>REQUEST: </b><textarea>" + xmlBody + "</textarea>");
            TEST.Log(Status.Info, "<pre>" + "<b>METHOD: </b>" + Method.POST + "</pre>");

            if (allHeaders != null)
            {
                TEST.Log(Status.Info, "<pre>" + "<b>HEADERS: </b>" + allHeaders + "</pre>");
            }

            if (allCookies != null)
            {
                TEST.Log(Status.Info, "<pre>" + "<b>COOKIES: </b>" + allCookies + "</pre>");
            }

            if (httpBasicAuthenticator || ntlmAuthenticator)
            {
                TEST.Log(Status.Info, "<pre>" + "<b>AUTHENTICATOR: </b>" + "\n" + "<b>USER: </b>" + Properties.Settings.Default.AUTHENTICATOR_USER + "\n" + "<b>PASSWORD: </b>" + Properties.Settings.Default.AUTHENTICATOR_PASSWORD + "</pre>");
            }

            HttpStatusCode statusCode = response.StatusCode;
            int numericStatusCode = (int)statusCode;

            TEST.Log(Status.Info, "<pre>" + "<b>STATUS CODE: </b>" + numericStatusCode + " - " + response.StatusCode.ToString() + "</pre>");
            TEST.Log(Status.Info, "<pre>" + "<b>RESPONSE HEADERS: </b>" + allResponseHeaders + "</pre>");
            TEST.Log(Status.Info, "<b>PAYLOAD: </b> <textarea>" + response.Content + "</textarea>");
        }

        public static void AddTestResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.Message);
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            switch (status)
            {
                case TestStatus.Failed:
                    TEST.Log(Status.Fail, "Test Result: " + Status.Fail + "<pre>" + "Message: " + message + "</pre>" + "<pre>" + "Stack Trace: " + stacktrace + "</pre>");
                    break;
                case TestStatus.Inconclusive:
                    TEST.Log(Status.Warning, "Test Result: " + Status.Warning + "<pre>" + "Message: " + message + "</pre>" + "<pre>" + "Stack Trace: " + stacktrace + "</pre>");
                    break;
                case TestStatus.Skipped:
                    TEST.Log(Status.Skip, "Test Result: " + Status.Skip + "<pre>" + "Message: " + message + "</pre>" + "<pre>" + "Stack Trace: " + stacktrace + "</pre>");
                    break;
                default:
                    TEST.Log(Status.Pass, "Test Result: " + Status.Pass);
                    break;
            }
        }

        public static void GenerateReport()
        {
            EXTENT_REPORT.Flush();
        }
    }
}
