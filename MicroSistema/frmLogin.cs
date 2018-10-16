using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace MicroSistema
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void pnlTextoUsuario_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Gray, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        public void DrawRoundRect(Graphics g, Pen p, float X, float Y, float width, float height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(X + radius, Y, X + width - (radius * 2), Y);
            gp.AddArc(X + width - (radius * 2), Y, radius * 2, radius * 2, 270, 90);
            gp.AddLine(X + width, Y + radius, X + width, Y + height - (radius * 2));
            gp.AddArc(X + width - (radius * 2), Y + height - (radius * 2), radius * 2, radius * 2, 0, 90);
            gp.AddLine(X + width - (radius * 2), Y + height, X + radius, Y + height);
            gp.AddArc(X, Y + height - (radius * 2), radius * 2, radius * 2, 90, 90);
            gp.AddLine(X, Y + height - (radius * 2), X, Y + radius);
            gp.AddArc(X, Y, radius * 2, radius * 2, 180, 90);
            gp.CloseFigure();
            g.DrawPath(p, gp);
            gp.Dispose();
        }

        private void pnlTextoSenha_Paint(object sender, PaintEventArgs e)
        {
            Graphics v = e.Graphics;
            DrawRoundRect(v, Pens.Gray, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 10);
            base.OnPaint(e);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            ContaUsuario.Login(txtConta.Text, txtSenha.Text);
            if (ContaUsuario.UsuarioUtilizador == null)
                MessageBox.Show("Usuário ou senha inválidos!");
            else
            {
                this.FormClosing -= new FormClosingEventHandler(this.frmLogin_FormClosing);
                this.Close();
            }
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            Point l = new Point(this.Left + btnAjuda.Left, this.Top + btnAjuda.Top);
            Size t = new Size(420, 130);
            frmMensagemSuporte mensagemLogin = new frmMensagemSuporte(l, t, "Em caso de problemas, consulte o suporte:\n" + 
                                                                            "- Elisa Monteiro, \nAdministradora do Sistema - Ramal 145\n" +
                                                                            "- Ricardo Estefan Florença, \nSuporte Autorizado do Sistema - (11) 4891-7752");
            mensagemLogin.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.FormClosing -= new FormClosingEventHandler(this.frmLogin_FormClosing);
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }
    }

    public class RoundButton : Button
    {
        public RoundButton(): base()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
           
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath grPath = new GraphicsPath();
            grPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(grPath);
            base.OnPaint(e);
        }
    }
}
