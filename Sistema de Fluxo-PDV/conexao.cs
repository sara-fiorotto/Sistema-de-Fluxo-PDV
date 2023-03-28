using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema_de_Fluxo_PDV
{
    class conexao
    {
        public string conect = "SERVER=localhost;DATABASE=sistema_fluxo_caixa;UID=root;PWD=;PORT=";

        public MySqlConnection sqlConnection = null;

        public void AbrirConexao()
        {
            sqlConnection = new MySqlConnection(conect);
            sqlConnection.Open();
        }

        public void FecharConexao()
        {
            sqlConnection = new MySqlConnection(conect);
            sqlConnection.Close();
            sqlConnection.Dispose();

        }
    }
}
