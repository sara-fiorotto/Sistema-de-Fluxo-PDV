using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sistema_de_Fluxo_PDV.Formularios
{
    public partial class frmVenda : Form
    {
        Event_Botoes_Campos evnt = new Event_Botoes_Campos();
        conexao conect = new conexao();
        string sql, id, valor, nome;
        int quantidade, comanda, linha;


        MySqlCommand cmd;
        decimal total, total_conta, valorTemp, total_cliente;

        public frmVenda()
        {
            InitializeComponent();
            gridItens.RowHeadersVisible = false;
            gridProdutos.RowHeadersVisible = false;
            GeraComanda();
        }

        #region Base de Dados
        private void frmVenda_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'sistema_fluxo_caixaDataSet.clientes'. Você pode movê-la ou removê-la conforme necessário.
            this.clientesTableAdapter.Fill(this.sistema_fluxo_caixaDataSet.clientes);
            // TODO: esta linha de código carrega dados na tabela 'sistema_fluxo_caixaDataSet.produtos'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosTableAdapter.Fill(this.sistema_fluxo_caixaDataSet.produtos);
        }
        #endregion

        #region DataGrid - Cell Click
        private void gridProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mskQntd.Enabled = true;
            btnAdicionar.Enabled = true;

            id = gridProdutos.CurrentRow.Cells[0].Value.ToString();
            nome = gridProdutos.CurrentRow.Cells[1].Value.ToString();
            valor = gridProdutos.CurrentRow.Cells[2].Value.ToString();
        }

        private void gridItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            evnt.HabilitaBotoes(btnDeletar, btnQuantidade, null, null);
            mskQntd.Enabled = true;
            linha = e.RowIndex;
        }
        #endregion

        #region Botões - Evento Click
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (mskQntd.Text == "" || mskQntd.Text == "0")
            { MessageBox.Show("Digite uma quantidade!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            else
            {
                decimal total_item = Int32.Parse(mskQntd.Text) * Decimal.Parse(valor);
                gridItens.Rows.Add(id, nome, mskQntd.Text, total_item.ToString());
            }
            evnt.LimparTextBox(mskQntd, txtBuscar, null, null);
            evnt.DesabilitaBotoes(mskQntd, btnAdicionar, btnDeletar, null);
            TotalVenda();
        }
        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            int cliente = (int)cmbCliente.SelectedValue;
            string pag = cmbPag.Text;
            string data = DateTime.Now.ToString("yyyy'-'MM'-'dd");

            conect.AbrirConexao();

            sql = "INSERT INTO venda(id_cliente, valor, data, pagamento, comanda) VALUES(@id, @valor, @data, @pagamento, @comanda)";
            cmd = new MySqlCommand(sql, conect.sqlConnection);

            cmd.Parameters.AddWithValue("@id", cliente);
            cmd.Parameters.AddWithValue("@valor", total);
            cmd.Parameters.AddWithValue("@data", data);
            cmd.Parameters.AddWithValue("@pagamento", pag);
            cmd.Parameters.AddWithValue("@comanda", comanda);

            cmd.ExecuteNonQuery();
            conect.FecharConexao();
            adicionar_item();
            SubtraiProduto();
            TotalCliente();
            MessageBox.Show("Venda Cadastrada com Sucesso!!", "Deu certo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            GeraComanda();
            cmbPag.SelectedItem = "";
            lblTotal.Text = "0,00";
            gridItens.Rows.Clear();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            gridItens.Rows.Clear();
            lblTotal.Text = "R$0,00";
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            gridItens.Rows.RemoveAt(linha);
            evnt.DesabilitaBotoes(btnQuantidade, btnDeletar, null, null);
            TotalVenda();
        }

        private void btnQuantidade_Click(object sender, EventArgs e)
        {
            if (mskQntd.Text == "" || mskQntd.Text == "0")
            { MessageBox.Show("Digite uma quantidade!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

            else
            {
                nome = gridItens.CurrentRow.Cells[0].Value.ToString();
                BuscarValor(nome);

                gridItens.CurrentRow.Cells[1].Value = mskQntd.Text;
                decimal total_item = Int32.Parse(mskQntd.Text) * valorTemp;
                gridItens.CurrentRow.Cells[2].Value = total_item.ToString();
                TotalVenda();
            }
        }
        #endregion

        #region Funções Auxiliares
        private void adicionar_item()
        {
            
            conect.AbrirConexao();
            sql = "INSERT INTO itens_venda(nome_prod, quantidade, valor, comanda) VALUES(@nome_prod, @quantidade, @valor, @comanda)";

            cmd = new MySqlCommand(sql, conect.sqlConnection);

            for (int i = 0; i < gridItens.Rows.Count; i++)
            {
                //limpo os parâmetros
                cmd.Parameters.Clear();
                //crio os parâmetro do comando e passo as linhas do grid para eles onde a célula indica a coluna da tabela
                cmd.Parameters.AddWithValue("@nome_prod", gridItens.Rows[i].Cells[1].Value);
                cmd.Parameters.AddWithValue("@quantidade",gridItens.Rows[i].Cells[2].Value);
                cmd.Parameters.AddWithValue("@valor",gridItens.Rows[i].Cells[3].Value);
                cmd.Parameters.AddWithValue("@comanda", comanda);
                //executo o comando
                cmd.ExecuteNonQuery();
            }
            conect.FecharConexao();

            evnt.LimparTextBox(mskQntd, txtBuscar, null, null);
            evnt.DesabilitaBotoes(mskQntd, btnAdicionar, btnDeletar, btnLimpar);
        }

        private void SubtraiProduto()
        {
            int quant_atual, quant_sub, quant_nova; 

            conect.AbrirConexao();
            
            for (int i = 0; i < gridItens.Rows.Count; i++)
            {
                sql = "SELECT quantidade FROM produtos WHERE id_produtos=@id";
                cmd = new MySqlCommand(sql, conect.sqlConnection);
                cmd.Parameters.AddWithValue("@id", gridItens.Rows[i].Cells[0].Value);
                quant_atual = (int)cmd.ExecuteScalar();

                quant_sub =  Convert.ToInt32(gridItens.Rows[i].Cells[2].Value);
                quant_nova = quant_atual - quant_sub;

                sql = "UPDATE produtos SET quantidade=@quantidade WHERE id_produtos=@id";
                cmd = new MySqlCommand(sql, conect.sqlConnection);
                cmd.Parameters.AddWithValue("@id", gridItens.Rows[i].Cells[0].Value);
                cmd.Parameters.AddWithValue("@quantidade", quant_nova);
                cmd.ExecuteNonQuery();
            }
            conect.FecharConexao();
        }

        private void TotalCliente()
        {
            if (cmbPag.Text == "Fiado")
            {
                conect.AbrirConexao();

                sql = "SELECT valor FROM clientes WHERE id=@id";
                cmd = new MySqlCommand(sql, conect.sqlConnection);
                cmd.Parameters.AddWithValue("@id", (int)cmbCliente.SelectedValue);
                total_cliente = (decimal)cmd.ExecuteScalar();

                total_conta = total_cliente + total;

                sql = "UPDATE clientes SET valor=@valor WHERE id=@id";
                cmd = new MySqlCommand(sql, conect.sqlConnection);
                cmd.Parameters.AddWithValue("@id", (int)cmbCliente.SelectedValue);
                cmd.Parameters.AddWithValue("@valor", total_conta);
                cmd.ExecuteNonQuery();
                conect.FecharConexao();
            }
        }
        private int GeraComanda()
        {
            conect.AbrirConexao();
            try
            {
                sql = "SELECT MAX(comanda) FROM itens_venda";
                cmd = new MySqlCommand(sql, conect.sqlConnection);
                comanda = (int)cmd.ExecuteScalar();
                //Armazena retorno do sql na váriavel comanda
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
             return comanda ++;
        }

        private void TotalVenda()
        {
            total = 0;
            foreach (DataGridViewRow row in gridItens.Rows)
            {
                total += Convert.ToDecimal(row.Cells[3].Value);
            }

            lblTotal.Text = Convert.ToDouble(total).ToString("C");
        }

        private void BuscarValor(string nomes)
        {
            conect.AbrirConexao();

            sql = "SELECT valor FROM produtos WHERE nome=@nome";
            cmd = new MySqlCommand(sql, conect.sqlConnection);
            cmd.Parameters.AddWithValue("@nome", nomes);
            valorTemp = (decimal)cmd.ExecuteScalar();
            //Pega o valor do produto pelo banco de dados e armazena em Valor Temporário 

            cmd.ExecuteNonQuery();
            conect.FecharConexao();

            //return decimal;
        }
        #endregion

        #region Buscar BD
        private void cmbCliente_TextChanged(object sender, EventArgs e)
        {
            //buscar cliente 
            conect.AbrirConexao();
            sql = "SELECT * FROM clientes WHERE nome LIKE @nome ORDER BY nome ASC"; //LIKE é usado para valores aproximados não necessariamento valor 100% igual
            cmd = new MySqlCommand(sql, conect.sqlConnection);
            cmd.Parameters.AddWithValue("@nome", cmbCliente.Text + "%");//Todo valor passado para o LIKE precisa acompanhar %

            MySqlDataAdapter da = new MySqlDataAdapter(); //Atualizando o DataGrid á partir do comando passado CMD 
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbCliente.Items.Add(dt);

            conect.FecharConexao();
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
           evnt.BuscarGrid("SELECT * FROM produtos WHERE nome LIKE @nome ORDER BY nome ASC", txtBuscar, gridProdutos);
        }

        #endregion
    }
}
