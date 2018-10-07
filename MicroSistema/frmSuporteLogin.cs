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
    public partial class frmSuporteLogin : Form
    {
        public frmSuporteLogin()
        {
            InitializeComponent();

        }
        public frmSuporteLogin(int x, int y)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = new Point(x, y);
        }

        private async void FadeIn(Form o, int interval = 80)
        {
            //Object is not fully invisible. Fade it in
            while (o.Opacity < 1.0)
            {
                await Task.Delay(interval);
                o.Opacity += 0.05;
            }
            o.Opacity = 1; //make fully visible       
        }

        private async void FadeOut(Form o, int interval = 80)
        {
            //Object is fully visible. Fade it out
            while (o.Opacity > 0.0)
            {
                await Task.Delay(interval);
                o.Opacity -= 0.05;
            }
            o.Opacity = 0; //make fully invisible       
            o.Close();
        }

        private void frmSuporteLogin_Load(object sender, EventArgs e)
        {
            FadeIn(this, 15);
        }

        private void frmSuporteLogin_MouseLeave(object sender, EventArgs e)
        {
            FadeOut(this, 15);
        }
    }
}
