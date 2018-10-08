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
    public partial class frmMensagemSuporte : Form
    {
        public frmMensagemSuporte()
        {
            InitializeComponent();
        }

        public frmMensagemSuporte(Point location, string mensagem)
        {
            InitializeComponent();

            // Atribuindo posição inicial do form.
            Opacity = 0;
            StartPosition = FormStartPosition.Manual;
            Location = location;//new Point(x, y);
            lblMensagem.Text = mensagem;
        }

        public frmMensagemSuporte(Point location, Size tamanho, string mensagem)
        {
            InitializeComponent();

            // Atribuindo posição inicial do form.
            StartPosition = FormStartPosition.Manual;
            Location = location;//new Point(x, y);
            this.Size = tamanho;
            lblMensagem.Text = mensagem;
        }

        private async void Aparecer(Form f, int incrementoDeTempo = 15)
        {
            // Incrementa a opacidade do form em 5% a cada incremento de tempo (milissegundos).
            while (f.Opacity < 1.0)
            {
                await Task.Delay(incrementoDeTempo);
                f.Opacity += 0.05;
            }
            f.Opacity = 1;  // Totalmente visível
        }

        private async void Desparecer(Form f, int incrementoDeTempo = 15)
        {
            // Incrementa a transparência do form em 5% a cada incremento de tempo (milissegundos).
            while (f.Opacity > 0.0)
            {
                await Task.Delay(incrementoDeTempo);
                f.Opacity -= 0.05;
            }
            f.Opacity = 0; // Totalmente invisível.
            this.Close();  // Encerra a execução da janela.
        }

        private void frmMensagemSuporte_Load(object sender, EventArgs e)
        {
            var d = System.Drawing.SystemIcons.Information;
            pcbxIcone.Image = d.ToBitmap();
            Aparecer(this); // Realiza o efeito no carregamento do form.
        }

        private void frmMensagemSuporte_MouseLeave(object sender, EventArgs e)
        {
            Desparecer(this); // Realiza o desaparecimento, e posteriormente o fechamento, ao perder a presença do mouse.
        }
    }
}
