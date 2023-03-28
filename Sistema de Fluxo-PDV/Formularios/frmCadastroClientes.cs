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
    public partial class frmCadastroClientes : Form
    {
        conexao conect = new conexao();
        string sql, id;
        MySqlCommand cmd;

        Event_Botoes_Campos evnt = new Event_Botoes_Campos();
        public frmCadastroClientes()
        {
            InitializeComponent();
            evnt.ListarGrid("SELECT * FROM clientes ORDER BY NOME ASC", grid);
        }

        public void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            evnt.HabilitaBotoes(btnAlterar, btnCancelar, btnExcluir, null);
            btnNovo.Enabled = false;

            evnt.HabilitaCampos(txtNome, txtTel, txtTel2, txtBuscar);

            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtTel.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtTel2.Text = grid.CurrentRow.Cells[3].Value.ToString();
        }

        private void frmCadastroClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'sistema_fluxo_caixaDataSet.clientes'. Você pode movê-la ou removê-la conforme necessário.
            this.clientesTableAdapter.Fill(this.sistema_fluxo_caixaDataSet.clientes);

        }

        public void btnNovo_Click(object sender, EventArgs e)
        {
            evnt.HabilitaCampos(txtNome, txtTel, txtTel2, null);
            txtNome.Focus();

            evnt.HabilitaBotoes(btnSalvar, btnCancelar, null, null);
            btnNovo.Enabled = false;
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            //Fique alegre com os pequenos códigos
            if (MessageBox.Show("Deseja Excluir o Registro", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conect.AbrirConexao();
                sql = "DELETE from clientes WHERE id=@id";
                cmd = new MySqlCommand(sql, conect.sqlConnection);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                conect.FecharConexao();
                MessageBox.Show("Registro Excluido com sucesso", "Deletado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            evnt.LimparTextBox(txtNome, txtTel, txtTel2, null);
            evnt.DesabilitaBotoes(btnAlterar, btnCancelar, btnExcluir, btnSalvar);
            evnt.DesabilitaCampos(txtTel, txtNome, txtTel2, null);
            evnt.ListarGrid("SELECT * FROM clientes ORDER BY NOME ASC", grid);
            btnNovo.Enabled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            evnt.LimparTextBox(txtNome, txtTel, txtTel2, null);
            evnt.DesabilitaBotoes(btnAlterar, btnCancelar, btnExcluir, btnSalvar);
            evnt.DesabilitaCampos(txtNome, txtTel, txtTel2, null);
            btnNovo.Enabled = true;
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

            if (txtTel.Text == "(  )     -" || txtTel.Text.Length < 12)
            {
                MessageBox.Show("OPS! Digite pelo menos um Telefone!");
                txtTel.Text = "";
                return;
            }

            conect.AbrirConexao();

            sql = "UPDATE clientes SET nome=@nome, telefone=@telefone, telefone2=@telefone2 WHERE id=@id";
            cmd = new MySqlCommand(sql, conect.sqlConnection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTel.Text);
            cmd.Parameters.AddWithValue("@telefone2", txtTel2.Text);

            cmd.ExecuteNonQuery();
            conect.FecharConexao();

            evnt.LimparTextBox(txtNome, txtTel, txtTel2, null);
            evnt.DesabilitaBotoes(btnAlterar, btnCancelar, btnExcluir, btnSalvar);
            evnt.DesabilitaCampos(txtNome, txtTel, txtTel2, null);

            btnNovo.Enabled = true;
            MessageBox.Show("Registro Alterado com sucesso", "Editado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            evnt.ListarGrid("SELECT * FROM clientes ORDER BY NOME ASC", grid);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            evnt.BuscarGrid("SELECT * FROM clientes WHERE nome LIKE @nome ORDER BY nome ASC", txtBuscar, grid);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                MessageBox.Show("OPS! Digite o nome!");
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }

            if (txtTel.Text == "(  )     -" || txtTel.Text.Length < 12)
            {
                MessageBox.Show("OPS! Digite pelo menos um Telefone!");
                txtTel.Text = "";
                return;
            }

            conect.AbrirConexao();

            //Usando a variavel sql como auxiliar para guardar a informção do comando para o base de dados (seu índice no banco, e valores a serem guardados)
            sql = "INSERT INTO clientes(nome, telefone, telefone2) VALUES(@nome, @telefone, @telefone2)";

            //Instanciando um comando no MySql passando respectivamente o parametro da variavel sql e a conexão que está na classe Conexão
            cmd = new MySqlCommand(sql, conect.sqlConnection);

            //Passando os parametros usados na variavel sql, adicionando seu nome e respectivo valor
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@telefone", txtTel.Text);
            cmd.Parameters.AddWithValue("@telefone2", txtTel2.Text);


            //Comando que executa a Query, NÃO FUNCIONA SEM ELE!
            cmd.ExecuteNonQuery();
            conect.FecharConexao();

            evnt.LimparTextBox(txtNome, txtTel, txtTel2, null);
            evnt.DesabilitaBotoes(btnAlterar, btnCancelar, btnExcluir, btnSalvar);
            evnt.DesabilitaCampos(txtNome, txtTel, txtTel2, null);
            btnNovo.Enabled = true;

            evnt.ListarGrid("SELECT * FROM clientes ORDER BY NOME ASC", grid);
            MessageBox.Show("Registro Salvo com sucesso", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
