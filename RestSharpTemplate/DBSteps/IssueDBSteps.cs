using RestSharpTemplate.Helpers;
using RestSharpTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTemplate.DBSteps
{
    class IssueDBSteps
    {
        public static void DeletaIssue() {

            string query = DeleteQueries.DeleteIssue;
            DBHelpers.ExecuteQuery(query);

        }

        public static string RetornaIdIssue() {
            string query = SelectsQueries.RetornaIdIssue;
            return DBHelpers.RetornaDadosQuery(query)[0];
        }
    }
}
