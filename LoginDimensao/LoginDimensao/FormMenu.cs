using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginDimensao
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnCad_Click(object sender, EventArgs e)
        {
            FormCad cad = new FormCad();
            this.Hide();
            cad.Show();
        }

        private void BtnCons_Click(object sender, EventArgs e)
        {
            FormCons cons = new FormCons();
            this.Hide();
            cons.Show();
        }
    }
}