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
        private ContaUsuario usuarioLogin;
        public frmLogin()
        {
            InitializeComponent();
            
            usuarioLogin = new ContaUsuario();
            
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
            MessageBox.Show("Entrar");
        }

        private void btnAjuda_Click(object sender, EventArgs e)
        {
            frmSuporteLogin suporteLogin = new frmSuporteLogin(this.Left + btnAjuda.Left, this.Top + btnAjuda.Top);
            suporteLogin.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
