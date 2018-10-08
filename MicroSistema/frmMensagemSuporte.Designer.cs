namespace MicroSistema
{
    partial class frmMensagemSuporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMensagem = new System.Windows.Forms.Label();
            this.pcbxIcone = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxIcone)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensagem
            // 
            this.lblMensagem.AutoSize = true;
            this.lblMensagem.Location = new System.Drawing.Point(59, 9);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(150, 21);
            this.lblMensagem.TabIndex = 0;
            this.lblMensagem.Text = "Texto da Mensagem.";
            // 
            // pcbxIcone
            // 
            this.pcbxIcone.Location = new System.Drawing.Point(12, 12);
            this.pcbxIcone.Name = "pcbxIcone";
            this.pcbxIcone.Size = new System.Drawing.Size(41, 39);
            this.pcbxIcone.TabIndex = 1;
            this.pcbxIcone.TabStop = false;
            // 
            // frmMensagemSuporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(374, 141);
            this.ControlBox = false;
            this.Controls.Add(this.pcbxIcone);
            this.Controls.Add(this.lblMensagem);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMensagemSuporte";
            this.Opacity = 0D;
            this.Text = "frmMensagemSuporte";
            this.Load += new System.EventHandler(this.frmMensagemSuporte_Load);
            this.MouseLeave += new System.EventHandler(this.frmMensagemSuporte_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pcbxIcone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.PictureBox pcbxIcone;
    }
}