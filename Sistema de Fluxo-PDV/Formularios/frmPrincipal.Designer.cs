
namespace Sistema_de_Fluxo_PDV
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCadastroProduto = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProdutosStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMovimentacao = new System.Windows.Forms.ToolStripMenuItem();
            this.caixaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFluxodeCaixa = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLancamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSaidaseEntradas = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRelatorioEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRelatorioMovimentacoes = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRelatorioCadastros = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.img04 = new System.Windows.Forms.PictureBox();
            this.img03 = new System.Windows.Forms.PictureBox();
            this.img02 = new System.Windows.Forms.PictureBox();
            this.img01 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img04)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img03)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img01)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem,
            this.MenuProdutosStrip,
            this.caixaToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuClientes,
            this.MenuFornecedores,
            this.MenuCadastroProduto});
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.cadastroToolStripMenuItem.Text = "Controle";
            this.cadastroToolStripMenuItem.Click += new System.EventHandler(this.cadastroToolStripMenuItem_Click);
            // 
            // MenuClientes
            // 
            this.MenuClientes.Name = "MenuClientes";
            this.MenuClientes.Size = new System.Drawing.Size(180, 22);
            this.MenuClientes.Text = "Clientes";
            this.MenuClientes.Click += new System.EventHandler(this.MenuClientes_Click);
            // 
            // MenuFornecedores
            // 
            this.MenuFornecedores.Name = "MenuFornecedores";
            this.MenuFornecedores.Size = new System.Drawing.Size(180, 22);
            this.MenuFornecedores.Text = "Fornecedores";
            // 
            // MenuCadastroProduto
            // 
            this.MenuCadastroProduto.Name = "MenuCadastroProduto";
            this.MenuCadastroProduto.Size = new System.Drawing.Size(180, 22);
            this.MenuCadastroProduto.Text = "Produtos";
            this.MenuCadastroProduto.Click += new System.EventHandler(this.MenuCadastroProduto_Click);
            // 
            // MenuProdutosStrip
            // 
            this.MenuProdutosStrip.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEstoque,
            this.MenuMovimentacao});
            this.MenuProdutosStrip.Name = "MenuProdutosStrip";
            this.MenuProdutosStrip.Size = new System.Drawing.Size(75, 20);
            this.MenuProdutosStrip.Text = "Cobranças";
            this.MenuProdutosStrip.Click += new System.EventHandler(this.MenuProdutosStrip_Click);
            // 
            // MenuEstoque
            // 
            this.MenuEstoque.Name = "MenuEstoque";
            this.MenuEstoque.Size = new System.Drawing.Size(180, 22);
            this.MenuEstoque.Text = "Clientes";
            this.MenuEstoque.Click += new System.EventHandler(this.MenuEstoque_Click);
            // 
            // MenuMovimentacao
            // 
            this.MenuMovimentacao.Name = "MenuMovimentacao";
            this.MenuMovimentacao.Size = new System.Drawing.Size(180, 22);
            this.MenuMovimentacao.Text = "Movimentação";
            this.MenuMovimentacao.Click += new System.EventHandler(this.MenuMovimentacao_Click);
            // 
            // caixaToolStripMenuItem
            // 
            this.caixaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFluxodeCaixa,
            this.MenuLancamentos,
            this.MenuSaidaseEntradas});
            this.caixaToolStripMenuItem.Name = "caixaToolStripMenuItem";
            this.caixaToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.caixaToolStripMenuItem.Text = "Caixa";
            // 
            // MenuFluxodeCaixa
            // 
            this.MenuFluxodeCaixa.Name = "MenuFluxodeCaixa";
            this.MenuFluxodeCaixa.Size = new System.Drawing.Size(160, 22);
            this.MenuFluxodeCaixa.Text = "Venda";
            this.MenuFluxodeCaixa.Click += new System.EventHandler(this.MenuFluxodeCaixa_Click);
            // 
            // MenuLancamentos
            // 
            this.MenuLancamentos.Name = "MenuLancamentos";
            this.MenuLancamentos.Size = new System.Drawing.Size(160, 22);
            this.MenuLancamentos.Text = "Lançamentos";
            // 
            // MenuSaidaseEntradas
            // 
            this.MenuSaidaseEntradas.Name = "MenuSaidaseEntradas";
            this.MenuSaidaseEntradas.Size = new System.Drawing.Size(160, 22);
            this.MenuSaidaseEntradas.Text = "Saídas /Entradas";
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuRelatorioEstoque,
            this.MenuRelatorioMovimentacoes,
            this.MenuRelatorioCadastros});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            // 
            // MenuRelatorioEstoque
            // 
            this.MenuRelatorioEstoque.Name = "MenuRelatorioEstoque";
            this.MenuRelatorioEstoque.Size = new System.Drawing.Size(159, 22);
            this.MenuRelatorioEstoque.Text = "Estoque";
            // 
            // MenuRelatorioMovimentacoes
            // 
            this.MenuRelatorioMovimentacoes.Name = "MenuRelatorioMovimentacoes";
            this.MenuRelatorioMovimentacoes.Size = new System.Drawing.Size(159, 22);
            this.MenuRelatorioMovimentacoes.Text = "Movimentações";
            // 
            // MenuRelatorioCadastros
            // 
            this.MenuRelatorioCadastros.Name = "MenuRelatorioCadastros";
            this.MenuRelatorioCadastros.Size = new System.Drawing.Size(159, 22);
            this.MenuRelatorioCadastros.Text = "Cadastros";
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            // 
            // img04
            // 
            this.img04.Image = global::Sistema_de_Fluxo_PDV.Properties.Resources.dollar_symbol;
            this.img04.Location = new System.Drawing.Point(562, 83);
            this.img04.Name = "img04";
            this.img04.Size = new System.Drawing.Size(123, 131);
            this.img04.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img04.TabIndex = 4;
            this.img04.TabStop = false;
            // 
            // img03
            // 
            this.img03.Image = global::Sistema_de_Fluxo_PDV.Properties.Resources.shop;
            this.img03.Location = new System.Drawing.Point(408, 83);
            this.img03.Name = "img03";
            this.img03.Size = new System.Drawing.Size(123, 131);
            this.img03.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img03.TabIndex = 3;
            this.img03.TabStop = false;
            // 
            // img02
            // 
            this.img02.Image = global::Sistema_de_Fluxo_PDV.Properties.Resources.cart;
            this.img02.Location = new System.Drawing.Point(251, 83);
            this.img02.Name = "img02";
            this.img02.Size = new System.Drawing.Size(123, 131);
            this.img02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img02.TabIndex = 2;
            this.img02.TabStop = false;
            // 
            // img01
            // 
            this.img01.Image = global::Sistema_de_Fluxo_PDV.Properties.Resources.atm_machine;
            this.img01.Location = new System.Drawing.Point(96, 83);
            this.img01.Name = "img01";
            this.img01.Size = new System.Drawing.Size(123, 131);
            this.img01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img01.TabIndex = 1;
            this.img01.TabStop = false;
            this.img01.Click += new System.EventHandler(this.img01_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.img04);
            this.Controls.Add(this.img03);
            this.Controls.Add(this.img02);
            this.Controls.Add(this.img01);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img04)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img03)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuClientes;
        private System.Windows.Forms.ToolStripMenuItem MenuFornecedores;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastroProduto;
        private System.Windows.Forms.ToolStripMenuItem MenuProdutosStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuEstoque;
        private System.Windows.Forms.ToolStripMenuItem MenuMovimentacao;
        private System.Windows.Forms.ToolStripMenuItem caixaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuFluxodeCaixa;
        private System.Windows.Forms.ToolStripMenuItem MenuLancamentos;
        private System.Windows.Forms.ToolStripMenuItem MenuSaidaseEntradas;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuRelatorioEstoque;
        private System.Windows.Forms.ToolStripMenuItem MenuRelatorioMovimentacoes;
        private System.Windows.Forms.ToolStripMenuItem MenuRelatorioCadastros;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.PictureBox img01;
        private System.Windows.Forms.PictureBox img02;
        private System.Windows.Forms.PictureBox img03;
        private System.Windows.Forms.PictureBox img04;
    }
}

