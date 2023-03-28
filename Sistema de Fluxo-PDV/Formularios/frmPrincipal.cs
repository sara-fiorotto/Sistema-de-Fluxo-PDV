using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Fluxo_PDV
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void img01_Click(object sender, EventArgs e)
        {
            Formularios.frmVenda frm = new Formularios.frmVenda();
            frm.ShowDialog();
        }


        private void MenuClientes_Click(object sender, EventArgs e)
        {
            Formularios.frmCadastroClientes frm = new Formularios.frmCadastroClientes();
            frm.ShowDialog();
        }

        private void MenuCadastroProduto_Click(object sender, EventArgs e)
        {
            Formularios.frmCadastroProduto frm = new Formularios.frmCadastroProduto();
            frm.ShowDialog();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MenuFluxodeCaixa_Click(object sender, EventArgs e)
        {
            Formularios.frmVenda frm = new Formularios.frmVenda();
            frm.ShowDialog();
        }

        private void MenuProdutosStrip_Click(object sender, EventArgs e)
        {

        }

        private void MenuMovimentacao_Click(object sender, EventArgs e)
        {

        }

        private void MenuEstoque_Click(object sender, EventArgs e)
        {

        }
    }
}
