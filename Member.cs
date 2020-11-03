using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Final_Project
{
    public partial class Member : Form
    {
        private string conString = DbaseCon.GetConString();
        private SqlCommand cmd;
        SqlConnection conn = new SqlConnection();
        

        public int memberID = 0;
        public Member() { 
            InitializeComponent();
            memberID = SelectMember.memberID;
            lblMemberID.Text = memberID.ToString();
            MemberClass member = new MemberClass();
            member.MemberID = memberID;
            member = SelectQueries.GetMemberInfo(member);
            lblDateJoined.Text =member.JoinDate.ToShortDateString();
            txtFirstName_Mem.Text = member.FName;
            txtLastName_Mem.Text = member.LName;
            txtPhone_Mem.Text = member.Number;
            txtEmail_Mem.Text = member.Email;
            txtAddress_Mem.Text = member.Address;
            lblBooklimit.Text = member.IssueLimit.ToString();
            pictureBoxImage.ImageLocation = member.ProfileImage;

            DataTable dt = new DataTable();
            dt = SelectQueries.BooksLeftToReturn(memberID);
            booksLeftGriedView.DataSource = dt;
            cmbIssueID.ValueMember = "Issue_ID";
            cmbIssueID.DisplayMember = "Issue_ID";
            cmbIssueID.DataSource = dt;

            dt = SelectQueries.IssueHistory(memberID);
            issueHistoryGridView.DataSource = dt;

            dt = SelectQueries.ReturnHistory(memberID);
            returnHistoryGridView.DataSource = dt;


            dt = SelectQueries.UnpaidOverdues(memberID);
            UnpaidGridView.DataSource = dt;

            dt = SelectQueries.PaidOverdues(memberID);
            PaidGridView.DataSource = dt;
        }

        private void BtnImage_Click(object sender, EventArgs e)
        {
            btnUploadURL.Enabled = false;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg;*.jpeg;*.PNG;)|*.jpg;*.jpeg;*.PNG";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImage.Image = new Bitmap(dialog.FileName);
                txtURL.Text = dialog.FileName;
            }
        }

       

        private void Button1_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName_Mem.Text;
            string lname = txtLastName_Mem.Text;
            string phone = txtPhone_Mem.Text.ToString();
            string email = txtEmail_Mem.Text;
            string address = txtAddress_Mem.Text;
            string profileImage = txtURL.Text;

            if (fname == "" || lname == "" || phone == "" || email == "" || address == "" || profileImage == "")
            {
                MessageBox.Show("Fields can not be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();


                    string query = "Update Member Set First_Name='" + fname + "', Last_Name='" + lname + "' , " +
                        "Phone_Number='" + phone + "', Email='" + email + "', Address='" + address + "', Profile_Image='" + profileImage + "' where Member_ID= " + SelectMember.memberID;

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    string message = ex.Message.ToString();
                    string caption = "Error!";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Member information updated", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void Button2_Click(object sender, EventArgs e)
        {
            string searchQuery = txtBoxSearch.Text;
            DataTable dt = new DataTable();
            //search by book title
            if (cmbFilter.SelectedIndex == 0)
            {
                dt=SelectQueries.SearchBookByTitle(searchQuery);
                bookSearchGridView.DataSource = dt;
            }
            //search by author
            if (cmbFilter.SelectedIndex == 1) {
                dt=SelectQueries.SearchBookByAuthor(searchQuery);
                bookSearchGridView.DataSource = dt;
            }
            //search by publisher
            if (cmbFilter.SelectedIndex == 2) {
                dt=SelectQueries.SearchBookByPublisher(searchQuery);
                bookSearchGridView.DataSource = dt;
            }
            //search by category
            if (cmbFilter.SelectedIndex == 3)
            {
                dt=SelectQueries.SearchBookByCategory(searchQuery);
                bookSearchGridView.DataSource = dt;
            }
            if (bookSearchGridView.Rows.Count == 1)
            {
                lblMsg.Text = "Book not found!";
                MessageBox.Show("Book not found.\n Please try searching again", "NOT FOUND"
                        , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lblMsg.Text = "Book Found";
                MessageBox.Show("Book Found", "FOUND", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbBookID.ValueMember = "book_id";
                cmbBookID.DisplayMember = "book_id";
                cmbBookID.DataSource = dt;
            }
        }

        private void TabPage5_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            int bookID = Convert.ToInt32(cmbBookID.SelectedValue.ToString());
            string status = "PENDING";
            InsertQueries.InsertIntoIssueRequest(memberID, bookID, status);
            MessageBox.Show("Issue request successfully sent");
        }

        private void BtnUploadURL_Click(object sender, EventArgs e)
        {
            if (txtURL.Text == "")
            {
                MessageBox.Show("Image URL can not be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btnImage.Enabled = false;
            }
            string imageName = txtURL.Text;
            pictureBoxImage.ImageLocation = imageName;
            pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();

            try
            {
                string query = "Delete from Member where Member_ID = " + SelectMember.memberID;
                cmd.CommandText = query;

                conn.Open();
                //Execute the query
                cmd.ExecuteScalar();
                MessageBox.Show("Member account deleted!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SelectMember s = new SelectMember();
                s.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                string caption = "Error!";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
               
            }
        }

        private void BooksLeftGriedView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //Request   
            int issue_ID = Convert.ToInt32(cmbIssueID.SelectedValue.ToString());

            try
            {
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();


                string query = "Insert into Return_Request (issue_id,finished) values ('" + issue_ID
                    + "','NO')";


                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string message = ex.Message.ToString();
                string caption = "Error!";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                MessageBox.Show("Return Book Requested!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CmbIssueID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Member_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}