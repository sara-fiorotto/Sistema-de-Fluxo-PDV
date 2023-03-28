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
    public partial class frmCadastroProduto : Form
    {
        conexao conect = new conexao();
        MySqlCommand cmd;
        string sql, id;
        Event_Botoes_Campos evnt = new Event_Botoes_Campos();

        public frmCadastroProduto()
        {
            InitializeComponent();
            evnt.ListarGrid("SELECT * FROM produtos ORDER BY NOME ASC", gridProdutos);
            //gridProdutos.Columns[0].Visible = false;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            evnt.HabilitaBotoes(btnCancelar, btnSalvar, null, null);
            btnNovo.Enabled = false;
            txtNome.Focus();
            evnt.HabilitaCampos(txtNome, txtQuantidade, txtValor, txtEstoque);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            {
                if (txtNome.Text.ToString().Trim() == "")
                {
                    MessageBox.Show("OPS! Digite o nome!");
                    txtNome.Text = "";
                    txtNome.Focus();
                    return;
                }


                //if (this.Controls.OfType<TextBox>().Any(f => string.IsNullOrEmpty(f.Text)))

                if (this.Controls.OfType<MaskedTextBox>().Any(f => string.IsNullOrEmpty(f.Text)))
                {
                    MessageBox.Show("É necessario preencher todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    conect.AbrirConexao();

                    //Usando a variavel sql como auxiliar para guardar a informção do comando para o base de dados (seu índice no banco, e valores a serem guardados)
                    sql = "INSERT INTO produtos(nome, valor, quantidade, estoque_min) VALUES(@nome, @valor, @quantidade, @estoque_min)";

                    //Instanciando um comando no MySql passando respectivamente o parametro da variavel sql e a conexão que está na classe Conexão
                    cmd = new MySqlCommand(sql, conect.sqlConnection);

                    //Passando os parametros usados na variavel sql, adicionando seu nome e respectivo valor
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@valor", txtValor.Text);
                    cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);
                    cmd.Parameters.AddWithValue("@estoque_min", txtEstoque.Text);

                    //Comando que executa a Query, NÃO FUNCIONA SEM ELE!
                    cmd.ExecuteNonQuery();
                    conect.FecharConexao();

                    evnt.LimparTextBox(txtNome, txtQuantidade, txtValor, txtEstoque);
                    evnt.DesabilitaBotoes(btnAlterar, btnCancelar, btnExcluir, btnSalvar);
                    evnt.DesabilitaCampos(txtNome, txtQuantidade, txtValor, txtEstoque);
                    btnNovo.Enabled = true;

                    MessageBox.Show("Registro Salvo com sucesso", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    evnt.ListarGrid("SELECT * FROM produtos ORDER BY NOME ASC", gridProdutos);
                }
            }
        }

        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'sistema_fluxo_caixaDataSet.produtos'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosTableAdapter.Fill(this.sistema_fluxo_caixaDataSet.produtos);

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Excluir o Registro", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conect.AbrirConexao();
                sql = "DELETE from produtos WHERE id_produtos=@id";
                cmd = new MySqlCommand(sql, conect.sqlConnection);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                conect.FecharConexao();
                MessageBox.Show("Registro Excluido com sucesso", "Deletado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            evnt.LimparTextBox(txtNome, txtQuantidade, txtValor, txtEstoque);
            evnt.DesabilitaBotoes(btnAlterar, btnCancelar, btnExcluir, btnSalvar);
            evnt.DesabilitaCampos(txtNome, txtQuantidade, txtValor, txtEstoque);
            evnt.ListarGrid("SELECT * FROM produtos ORDER BY NOME ASC", gridProdutos);
            btnNovo.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            evnt.DesabilitaBotoes(btnAlterar, btnCancelar, btnExcluir, btnSalvar);
            btnNovo.Enabled = true;
            evnt.LimparTextBox(txtEstoque, txtNome, txtQuantidade, txtValor);
            evnt.DesabilitaCampos(txtValor, txtQuantidade, txtNome, txtEstoque);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("OPS! Digite o nome!");
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }

            //Verifica se as Maskaras do controle do formulario possuem texto, com uma função lambda embutida no IF 
            //Cada elemento do controle é F, se F for nulo pois não possue texto então retorna a mensagem!
            if (this.Controls.OfType<MaskedTextBox>().Any(f => string.IsNullOrEmpty(f.Text)))
            {
                MessageBox.Show("É necessario preencher todos os campos.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                conect.AbrirConexao();

                sql = "UPDATE produtos SET nome=@nome, valor=@valor, quantidade=@quantidade, estoque_min=@estoque_min WHERE id_produtos=@id";
                cmd = new MySqlCommand(sql, conect.sqlConnection);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@valor", txtValor.Text);
                cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);
                cmd.Parameters.AddWithValue("@estoque_min", txtEstoque.Text);

                cmd.ExecuteNonQuery();
                conect.FecharConexao();

                evnt.LimparTextBox(txtNome, txtQuantidade, txtValor, txtEstoque);
                evnt.DesabilitaBotoes(btnAlterar, btnCancelar, btnExcluir, btnSalvar);
                evnt.DesabilitaCampos(txtNome, txtQuantidade, txtValor, txtEstoque);
                btnNovo.Enabled = true;

                MessageBox.Show("Registro Salvo com sucesso", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                evnt.ListarGrid("SELECT * FROM produtos ORDER BY NOME ASC", gridProdutos);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            evnt.BuscarGrid("SELECT * FROM produtos WHERE nome LIKE @nome ORDER BY nome ASC", txtBuscar, gridProdutos);
        }

        private void gridProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            evnt.HabilitaBotoes(btnAlterar, btnCancelar, btnExcluir, null);
            btnNovo.Enabled = false;

            evnt.HabilitaCampos(txtNome, txtEstoque, txtQuantidade, txtValor);

            id = gridProdutos.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = gridProdutos.CurrentRow.Cells[1].Value.ToString();
            txtValor.Text = gridProdutos.CurrentRow.Cells[2].Value.ToString();
            txtQuantidade.Text = gridProdutos.CurrentRow.Cells[3].Value.ToString();
            txtEstoque.Text = gridProdutos.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
