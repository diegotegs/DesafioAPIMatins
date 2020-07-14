using RestSharpTemplate.Helpers;
using RestSharpTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTemplate.DBSteps
{
    public class ProjetoDBSteps {

        public static void CriarProjeto() {

            string query = CriarProjetoQueries.MassaDeDadosCriarProjeto;
            query = query.Replace("$name", "Nome_Projeto " + GeneralHelpers.ReturnStringWithRandomNumbers(2));
            query = query.Replace("$descricao", "Descrição_Projeto " + GeneralHelpers.ReturnStringWithRandomNumbers(2));
            DBHelpers.ExecuteQuery(query);
        }

        public static string RetornaIdProjeto() {
            string query = SelectsQueries.RetornaIdProjeto;
            return DBHelpers.RetornaDadosQuery(query)[0];
        }

        public static string RetornaProjeto(int posicao) {
            string query = SelectsQueries.RetornaUmProjeto;
            return DBHelpers.RetornaDadosQuery(query)[posicao];
        }

        public static void LimparProjeto() {
            string query = DeleteQueries.LimparProjeto;
            DBHelpers.ExecuteQuery(query);
        }
    }
}
