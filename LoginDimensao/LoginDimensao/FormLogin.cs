
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace LoginDimensao
 
{
    public partial class FormLogin : Form
    {
        //Referencia da conexao
        SqlConnection Conexao = new SqlConnection(@"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=LoginDimensao;Integrated Security=True");
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao.Open(); //Abrir conexao
            string query = "SELECT * FROM Usuario WHERE Username ='" + txtUser.Text + "'";
            SqlDataAdapter  dp = new SqlDataAdapter(query,Conexao);
            DataTable dt = new DataTable();
            dp.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                 // Verificar se a senha e valida
                if (txtSenha.Text == dt.Rows[0]["Password"].ToString())
                {
                    FormMenu principal = new FormMenu();
                    //FormMenu principal = new FormMenu();
                    this.Hide();
                    principal.Show();
                }
            }
            else
            {
                MessageBox.Show("Usuario ou Senha inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Text = ""; //Limpa as textbox depois de serem verificadas
                txtSenha.Text = "";
                txtUser.Select(); //cursor ira sinalizar a primeira textbox
            }
        }
    }
}