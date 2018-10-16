using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicroSistema
{
    public partial class frmCadUsuario : Form
    {
        private string SenhaGerada;
        private enum Gravar { Adicionar, Alterar }
        private Gravar operacao;
        private Usuario usuario;
        public frmCadUsuario()
        {
            InitializeComponent();
            operacao = Gravar.Adicionar;
        }

        public frmCadUsuario(Usuario usuarioAlterado)
        {
            InitializeComponent();
            operacao = Gravar.Alterar;
            usuario = usuarioAlterado;
        }

        private void frmCadUsuario_Load(object sender, EventArgs e)
        {
            cmbxNivelAcesso.DataSource = ContaUsuario.ListarNiveisAcesso();
            cmbxNivelAcesso.DisplayMember = "Titulo";
            cmbxNivelAcesso.ValueMember = "CdNivelAcesso";
            
            switch (operacao)
            {
                case Gravar.Adicionar:
                    btnResetSenha.Visible = false;
                    SenhaGerada = "Temp@" + DateTime.Now.ToString("ss.mm");
                    txtSenha.Text = SenhaGerada;
                    lblData.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    this.Text = "Cadastro de Usuário";
                    chbxAtivo.AutoCheck = false;
                    break;
                case Gravar.Alterar:
                    lblSenha.Visible = false;
                    txtSenha.Visible = false;
                    btnCopiar.Visible = false;
                    lblData.Text = usuario.DataCadastro.ToShortDateString();
                    txtEmail.Text = usuario.Email;
                    txtNome.Text = usuario.Nome;
                    chbxAtivo.Checked = usuario.Ativo;
                    cmbxNivelAcesso.SelectedValue = usuario.CdNivelAcesso;
                    this.Text = "Alteração de Usuário";
                    this.Height = Height - 30;
                    break;
            }
            lblTitulo.Text = Text;
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            txtSenha.SelectAll();
            Clipboard.SetText(txtSenha.Text);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            int cdNA = Convert.ToInt32(cmbxNivelAcesso.SelectedValue.GetHashCode());
            switch (operacao)
            {
                case Gravar.Adicionar:
                    try
                    {
                        ContaUsuario.NovoUsuario(txtEmail.Text, txtNome.Text, SenhaGerada, cdNA);
                    }
                    catch (ContaInvalidaException)
                    {
                        MessageBox.Show(this, "E-mail inválido!\nA conta de e-mail deve pertencer ao domínio @empresa.com.br e não conter espaços em branco.", "Erro", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    catch (SenhaInvalidaException)
                    {
                        MessageBox.Show(this, "Senha inválida!\nA senha de possuir ao menos 6 caracteres e conter letras minúsculas e maiúsculas, números e símbolos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;
                case Gravar.Alterar:
                    try
                    {
                        usuario.Nome = txtNome.Text;
                        usuario.Email = txtEmail.Text;
                        usuario.Ativo = chbxAtivo.Checked;
                        usuario.CdNivelAcesso = cdNA;
                        ContaUsuario.AlterarUsuario(usuario);
                    }
                    catch (ContaInvalidaException)
                    {
                        MessageBox.Show(this, "E-mail inválido!\nA conta de e-mail deve pertencer ao domínio @empresa.com.br e não conter espaços em branco.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;
            }
            Close();
        }
    }
}
