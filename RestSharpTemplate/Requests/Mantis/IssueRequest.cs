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
    public class IssueRequest : RequestBase
    {
        public IssueRequest(Method metodo, string id) {
            headers.Add("Authorization", Properties.Settings.Default.TOKEN);
            requestService = "/api/rest/issues/{issue_id}";
            SetMethod(metodo);
            parameters.Add("issue_id", id);
        }

        public IssueRequest(Method metodo) {
            headers.Add("Authorization", Properties.Settings.Default.TOKEN);
            requestService = "/api/rest/issues";
            SetMethod(metodo);
        }


        public void SetBodyIssueWithAttachments(string summary,string description,string nameProject,string nameCategory,string custimFieldName,string value, string nameFile1,string fileContent1,string nameFile2,string fileContant2) {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons/Mantis/CreateIssueWithAttachments.json",Encoding.UTF8);
            jsonBody = jsonBody.Replace("$summary", summary);
            jsonBody = jsonBody.Replace("$description", description);
            jsonBody = jsonBody.Replace("$name", nameProject);
            jsonBody = jsonBody.Replace("$categoryName", nameCategory);
            jsonBody = jsonBody.Replace("$fieldName", custimFieldName);
            jsonBody = jsonBody.Replace("$value", value);
            jsonBody = jsonBody.Replace("$filename", nameFile1);
            jsonBody = jsonBody.Replace("$fileContent", fileContent1);
            jsonBody = jsonBody.Replace("$fileName2", nameFile2);
            jsonBody = jsonBody.Replace("$fileContent2", fileContant2);

        }

        public void SetBodyIssueMinimal(string summary, string description, string nameCategory, string nameProject) {

            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath ()+"Jsons/Mantis/CreateIssue.json", Encoding.UTF8);

            jsonBody = jsonBody.Replace("$sumamry",summary);
            jsonBody = jsonBody.Replace("$description",description);
            jsonBody = jsonBody.Replace("$nameCategory",nameCategory);
            jsonBody = jsonBody.Replace("$projetoName",nameProject);

        }


    }
}
