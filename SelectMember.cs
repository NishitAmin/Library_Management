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
    public partial class SelectMember : Form
    {
        public static int memberID = 0;
        public SelectMember()
        {
            InitializeComponent();
            cmbSelectMember.SelectedIndex = -1;
            DataTable dt = SelectQueries.GetAllMembers();
            cmbSelectMember.ValueMember = "member_id";
            cmbSelectMember.DisplayMember = "member_id";
            cmbSelectMember.DataSource = dt;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (cmbSelectMember.SelectedIndex != -1)
            {
                memberID = Convert.ToInt32(cmbSelectMember.SelectedValue.ToString());
                Member m = new Member();
                // Properties.Resources.memberID= Convert.ToInt32(cmbSelectMember.SelectedValue.ToString());
                memberID = Convert.ToInt32(cmbSelectMember.SelectedValue.ToString());
                //MessageBox.Show("" + cmbSelectMember.SelectedValue.ToString());
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No Members Selected");
            }
        }

        private void SelectMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
        }
    }
}
