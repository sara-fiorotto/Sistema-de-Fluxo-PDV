using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_Fluxo_PDV.Formularios
{
    public partial class frmQuantidade : Form
    {
        public int globalQnt;
        public frmQuantidade()
        {
            InitializeComponent();
        }

        public void btnInserir_Click(object sender, EventArgs e)
        {
            if (this.Controls.OfType<MaskedTextBox>().Any(f => string.IsNullOrEmpty(f.Text)))
            {
                MessageBox.Show("Insira um valor", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (mskQuant.Text == "0") { MessageBox.Show("Insira um valor válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            else
            {
                
                globalQnt = Int32.Parse(mskQuant.Text);
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
