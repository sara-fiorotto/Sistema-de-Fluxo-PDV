using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using System.Data;

namespace Sistema_de_Fluxo_PDV
{
    class Event_Botoes_Campos
    {
        conexao conect = new conexao();
        MySqlCommand cmd;
        string sql;
        public void DesabilitaCampos(Control textBox, Control textBox2, Control textBox3, Control textBox4)
        {
            Array lista;
            lista = new Control[] { textBox, textBox2, textBox3, textBox4 };

            foreach (Control n in lista)
            {
                if (n != null) { n.Enabled = false; }
                else { return; };
            }
        }
    

        public void HabilitaCampos(Control textBox, Control textBox2, Control textBox3, Control textBox4)
        {
            Array lista;
            lista = new Control[] { textBox, textBox2, textBox3, textBox4 };

            foreach (Control n in lista)
            {
                if (n != null) { n.Enabled = true; }
                else { return; };
            }
        }
        public void LimparTextBox(Control textBox, Control textBox2, Control textBox3, Control textBox4)
        {
            Array lista;
            lista = new Control[] { textBox, textBox2, textBox3, textBox4};

            foreach (Control n in lista)
            {
                if (n != null) { n.Text = ""; }
                else { return; };
            }

        }

        public void DesabilitaBotoes(Control btn, Control btn2, Control btn3, Control btn4)
        {
            Array lista;
            lista = new Control[] { btn, btn2, btn3, btn4 };

            foreach (Control n in lista)
            {
                if (n != null) { n.Enabled = false; }
                else { return; };
            }
        }

        public void HabilitaBotoes(Control btn, Control btn2, Control btn3, Control btn4)
        {
            Array lista;
            lista = new Control[] { btn, btn2, btn3, btn4 } ;

            foreach (Control n in lista)
            {
                if (n != null)  { n.Enabled = true; }
                else { return; };
            }
        }

        public void ListarGrid(string comando, DataGridView grid)
        {
            conect.AbrirConexao();


            sql = comando;
            cmd = new MySqlCommand(sql, conect.sqlConnection);

            //o MySqlAdapter é a ponte entre o programa e o banco de dados para o recebimento de alterações como o UPDATE para o preenchimento de um DataSet/Tabela..
            MySqlDataAdapter da = new MySqlDataAdapter();

            //Passa uma instrução para executar um comando no objeto Criado,  que são usados para preencher o DataSet e atualizar o banco de dados do SQL Server.
            da.SelectCommand = cmd;

            //criando uma tabela e alimentando ela com as informações obtidas no objeto Da.
            DataTable dt = new System.Data.DataTable();
            da.Fill(dt);

            //Grid Recebendo a tabela
            grid.DataSource = dt;

            conect.FecharConexao();
        }

        public void BuscarGrid(string comando, Control textBox, DataGridView grid)
        {
            conect.AbrirConexao();
            sql = comando; //LIKE é usado para valores aproximados não necessariamento valor 100% igual
            cmd = new MySqlCommand(sql, conect.sqlConnection);
            cmd.Parameters.AddWithValue("@nome", textBox.Text + "%");//Todo valor passado para o LIKE precisa acompanhar %

            MySqlDataAdapter da = new MySqlDataAdapter(); //Atualizando o DataGrid á partir do comando passado CMD 
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;

            conect.FecharConexao();
        }

    }
}
