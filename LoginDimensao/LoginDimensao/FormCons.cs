using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginDimensao
{
    public partial class FormCons : Form
    {
        public FormCons()
        {
            InitializeComponent();
        }
       

        private void BtnBusca_Click(object sender, EventArgs e)
        {
         
            {


                SqlConnection Conexao = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=LoginDimensao;Integrated Security=True");
                Conexao.Open();
                var cons = "Select * from Paciente where nome like '%" + txtPesquisa.Text + "%'";
                
                SqlDataAdapter dp = new SqlDataAdapter(cons, Conexao);
                DataTable dt = new DataTable();
                dp.Fill(dt);
                dataGridView1.DataSource = dt;



                

                }
            }

        private void BtnVolt_Click(object sender, EventArgs e)
        {
            FormMenu principal = new FormMenu();
            this.Hide();
            principal.Show();
        }
    }
}
