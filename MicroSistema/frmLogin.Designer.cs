﻿namespace MicroSistema
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            this.pcbxIlustraLogin = new System.Windows.Forms.PictureBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlTextoUsuario = new System.Windows.Forms.Panel();
            this.pnlTextoSenha = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcbxIlustraLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pcbxIlustraLogin
            // 
            this.pcbxIlustraLogin.BackgroundImage = global::MicroSistema.Properties.Resources.Assinatura;
            this.pcbxIlustraLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pcbxIlustraLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.pcbxIlustraLogin.Location = new System.Drawing.Point(0, 0);
            this.pcbxIlustraLogin.Name = "pcbxIlustraLogin";
            this.pcbxIlustraLogin.Size = new System.Drawing.Size(204, 263);
            this.pcbxIlustraLogin.TabIndex = 0;
            this.pcbxIlustraLogin.TabStop = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(109, 23);
            this.txtUsuario.MaxLength = 25;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(229, 22);
            this.txtUsuario.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(12, 23);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 21);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuário";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.Location = new System.Drawing.Point(20, 64);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(53, 21);
            this.lblSenha.TabIndex = 3;
            this.lblSenha.Text = "Senha";
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.SystemColors.Control;
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSenha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.Location = new System.Drawing.Point(109, 64);
            this.txtSenha.MaxLength = 20;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(229, 22);
            this.txtSenha.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.txtSenha);
            this.panel1.Controls.Add(this.lblSenha);
            this.panel1.Controls.Add(this.lblUsuario);
            this.panel1.Controls.Add(this.pnlTextoUsuario);
            this.panel1.Controls.Add(this.pnlTextoSenha);
            this.panel1.Location = new System.Drawing.Point(210, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 106);
            this.panel1.TabIndex = 5;
            // 
            // pnlTextoUsuario
            // 
            this.pnlTextoUsuario.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTextoUsuario.Location = new System.Drawing.Point(101, 18);
            this.pnlTextoUsuario.Name = "pnlTextoUsuario";
            this.pnlTextoUsuario.Size = new System.Drawing.Size(244, 32);
            this.pnlTextoUsuario.TabIndex = 5;
            this.pnlTextoUsuario.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTextoUsuario_Paint);
            // 
            // pnlTextoSenha
            // 
            this.pnlTextoSenha.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTextoSenha.Location = new System.Drawing.Point(101, 59);
            this.pnlTextoSenha.Name = "pnlTextoSenha";
            this.pnlTextoSenha.Size = new System.Drawing.Size(244, 32);
            this.pnlTextoSenha.TabIndex = 6;
            this.pnlTextoSenha.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTextoSenha_Paint);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(397, 212);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(121, 39);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "&Entrar";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 263);
            this.ControlBox = false;
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pcbxIlustraLogin);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Text = "Entrada no Sistema";
            ((System.ComponentModel.ISupportInitialize)(this.pcbxIlustraLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pcbxIlustraLogin;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTextoUsuario;
        private System.Windows.Forms.Panel pnlTextoSenha;
        private System.Windows.Forms.Button btnLogin;
    }
}