using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                AdministratorPage ap = new AdministratorPage();
                ap.Show();
                this.Hide();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                Librarian lb = new Librarian();
                lb.Show();
                this.Hide();
            }
            else{
                SelectMember memberForm = new SelectMember();
                memberForm.Show();
                this.Hide();
            }
        }

        private void HomePage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
