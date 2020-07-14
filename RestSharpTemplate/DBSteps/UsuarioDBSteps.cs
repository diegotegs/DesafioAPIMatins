using RestSharpTemplate.Helpers;
using RestSharpTemplate.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTemplate.DBSteps
{
    class UsuarioDBSteps {

        public static void DeletaUsuario() {
            string query = DeleteQueries.DeletaUsuariosCriado;
            DBHelpers.ExecuteQuery(query);
        }
        
        public static string RetornaIdUsuario() {
            string query = SelectsQueries.RetornaIdUsuario;
            string dados = DBHelpers.RetornaDadosQuery(query)[0];
            return dados;
        }
    }
}
