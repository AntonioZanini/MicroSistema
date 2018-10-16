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
    public partial class frmTrocaSenha : Form
    {
        private Usuario usuarioAlterado;

        private bool necessitaSenha;
        private bool senhaTemporaria;
        public frmTrocaSenha(Usuario usuario, bool pedirSenhaAtual, bool trocaSenhaTemporaria)
        {
            InitializeComponent();
            necessitaSenha = pedirSenhaAtual;
            senhaTemporaria = trocaSenhaTemporaria;
            usuarioAlterado = usuario;
        }

        private void frmTrocaSenha_Load(object sender, EventArgs e)
        {
            if (!necessitaSenha)
            {
                lblSenhaAnterior.Visible = false;
                txtSenhaAnterior.Visible = false;                
                lblNovaSenha.Top -= 35;
                txtNovaSenha.Top -= 35;
                lblConfirmacao.Top -= 35;
                txtConfirmacao.Top -= 35;
                this.Height -= 35;
            }
            if (senhaTemporaria)
            {
                btnCancelar.Visible = false;
            }
            txtUsuario.Text = usuarioAlterado.Email;
        }

        private void frmTrocaSenha_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && senhaTemporaria)
                e.Cancel = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            try
            {
                if (necessitaSenha)
                {
                    if (!ContaUsuario.AutenticarSenha(usuarioAlterado, txtSenhaAnterior.Text))
                    {
                        MessageBox.Show(this, "A senha atual não está correta!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtSenhaAnterior.Focus();
                        return;
                    }
                }
                if (txtNovaSenha.Text != txtConfirmacao.Text)
                {
                    MessageBox.Show(this, "A senha e a confirmação estão diferentes!\nCertifique-se de que estas são iguais antes de prosseguir.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ContaUsuario.AlterarSenha(usuarioAlterado, txtNovaSenha.Text);
                    this.FormClosing -= new FormClosingEventHandler(this.frmTrocaSenha_FormClosing);
                    this.Close();
                }
            }
            catch (SenhaInvalidaException)
            {
                MessageBox.Show(this, "Senha inválida!\nA senha de possuir ao menos 6 caracteres e conter letras minúsculas e maiúsculas, números e símbolos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
