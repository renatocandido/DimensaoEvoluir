using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginDimensao
{
    public partial class FormCad : Form
    {
        public FormCad()
        {
            InitializeComponent();
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            FormMenu principal = new FormMenu();
            this.Hide();
            principal.Show();
        }
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            SalvarPaciente();
        }
        private void SalvarPaciente()
        {
           
    
                SqlConnection Conexao = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=LoginDimensao;Integrated Security=True");
                Conexao.Open();
                var reg = "Insert into Paciente (Nome, DataNascimento, Rgpaciente, NomeResponsavel, Endereço, telefone, Observaçoes)" +
                          " Values (@Nome, @DataNascimento, @Rgpaciente, @NomeResponsavel, @Endereço, @Telefone, @Observaçoes)";

            // Converter data nascimento de string para DateTime
            try
            {
                DateTime dataNasc = DateTime.ParseExact(txtData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                using SqlCommand cmd = new SqlCommand(reg, Conexao);
                {
                    cmd.Parameters.AddWithValue("@Nome", txtNome.Text);
                    cmd.Parameters.AddWithValue("@DataNascimento", dataNasc);
                    cmd.Parameters.AddWithValue("@Rgpaciente", txtRg.Text);
                    cmd.Parameters.AddWithValue("@NomeResponsavel", txtResp.Text);
                    cmd.Parameters.AddWithValue("@Endereço", txtEnd.Text);
                    cmd.Parameters.AddWithValue("@Telefone", txtTel.Text);
                    cmd.Parameters.AddWithValue("@Observaçoes", txtObs.Text);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Cadastrado com Sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cadastro não realizado devido a dados inválidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            Conexao.Close();

        }

    }
}
