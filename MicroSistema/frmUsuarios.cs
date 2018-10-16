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
    public partial class frmUsuarios : Form
    {
        

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CarregarDadosFiltro();

            dgvUsuarios.RowHeadersWidth = 20;
            dgvUsuarios.Columns[0].Width = 120;
            dgvUsuarios.Columns[1].Width = 150;
            dgvUsuarios.Columns[2].HeaderText = "Nível de Acesso";
            dgvUsuarios.Columns[3].HeaderText = "Data de Cadastro";
            dgvUsuarios.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvUsuarios.Columns[4].Visible = false;
            CarregarDadosGrid();            
        }

        private void CarregarDadosGrid()
        {
            int cdNA = Convert.ToInt32(cmbxFiltroNivelAcesso.SelectedValue.GetHashCode());
            dgvUsuarios.DataSource = (System.Collections.IList)ContaUsuario.ListarUsuarios(cdNA);
        }

        private void CarregarDadosFiltro()
        {
            cmbxFiltroNivelAcesso.DataSource = (System.Collections.IList)ContaUsuario.ListarNiveisAcesso("Todos");
            cmbxFiltroNivelAcesso.DisplayMember = "Titulo";
            cmbxFiltroNivelAcesso.ValueMember = "CdNivelAcesso";
        }

        private void cmbxFiltroNivelAcesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDadosGrid();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            frmCadUsuario cadUsuario = new frmCadUsuario();
            cadUsuario.ShowDialog();
            CarregarDadosGrid();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int cdUsuarioSelecionado = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString());
            Usuario usuario = ContaUsuario.BuscarUsuario(cdUsuarioSelecionado);
            frmCadUsuario cadUsuario = new frmCadUsuario(usuario);
            cadUsuario.ShowDialog();
            CarregarDadosGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int cdUsuarioSelecionado = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString());
            Usuario usuario = ContaUsuario.BuscarUsuario(cdUsuarioSelecionado);
            ContaUsuario.Excluir(usuario);
            CarregarDadosGrid();
        }

        private void btnResetSenha_Click(object sender, EventArgs e)
        {
            int cdUsuarioSelecionado = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells[4].Value.ToString());
            Usuario usuario = ContaUsuario.BuscarUsuario(cdUsuarioSelecionado);
            frmTrocaSenha trocaSenha = new frmTrocaSenha(usuario, true, false);
            trocaSenha.ShowDialog();
        }
    }
}
