using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravianTool.Dominio
{
    class ConsultaBD
    {
        string conexao = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        SqlConnection con;
        SqlCommand cmd;
        string query;
        string whereOrAnd = "WHERE";

        public ConsultaBD()
        {
            query = "SELECT * FROM x_world";
        }

        public void AddNomeAldeia(string aldeia)
        {
            query = string.Format("{0} {1} village LIKE '%{2}%'", query, whereOrAnd, aldeia);
            whereOrAnd = "AND";
        }

        public void AddPopMin(int popMin)
        {
            query = string.Format("{0} {1} population >= {2}", query, whereOrAnd, popMin);
            whereOrAnd = "AND";
        }

        public void AddPopMax(int popMax)
        {
            query = string.Format("{0} {1} population <= {2}", query, whereOrAnd, popMax);
            whereOrAnd = "AND";
        }

        public void AddTribo(int tribo)
        {
            query = string.Format("{0} {1} tid = {2}", query, whereOrAnd, tribo);
            whereOrAnd = "AND";
        }

        public void AddDistancia(int dist)
        {
            
        }

        public void EfetuaConsulta()
        {
            con = new SqlConnection(conexao);
            cmd = new SqlCommand(query);

            cmd.Connection = con;
            con.Open();

            var result = cmd.ExecuteReader();

            con.Close();
        }

    }
}
