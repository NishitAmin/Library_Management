using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Final_Project
{
    public partial class AdministratorPage : Form
    {
        private SqlConnection conn = new SqlConnection();
        private string conString = DbaseCon.GetConString();
        private SqlCommand cmd;
        Validator v = new Validator();
        public AdministratorPage()
        {
            InitializeComponent();
            DisplayGridViews();
            dateJoinMember.MaxDate = DateTime.Today;
        }
        private void DisplayGridViews()
        {
            viewBookData();
            displayBookID();
            viewBookIssueLimitData();
            displayMemberID();
            displayAuthorID();
            displayCategoryID();
            displayPublisherID();
            viewBookInitialData();
            viewAuthorData();
            viewCategoryData();
            viewPublisherData();
            viewLibrarianData();
            viewMemberData();
        }
        private void viewBookData()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from book";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                bookGridView.DataSource = dt;
                cmbID.DisplayMember = "Book_id";
                cmbID.ValueMember = "Book_id";
                cmbID.DataSource = dt;
                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all books!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void viewBookIssueLimitData()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from book_issue_limit";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                issueGridView.DataSource = dt;
                cmbBookIssueID.DisplayMember = "Book_id";
                cmbBookIssueID.ValueMember = "Book_id";
                cmbBookIssueID.DataSource = SelectQueries.GetAllBooks();
                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all book issue limit information!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void displayMemberID()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from Member";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                memberGridView.DataSource = dt;
                cmbBookMember.DisplayMember = "member_id";
                cmbBookMember.ValueMember = "member_id";
                cmbBookMember.DataSource = dt;

                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all books!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void displayBookID()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from Book";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                issueGridView.DataSource = dt;
                cmbBookIssueID.DisplayMember = "book_id";
                cmbBookIssueID.ValueMember = "book_id";
                cmbBookIssueID.DataSource = dt;

                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all book Ids!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void displayAuthorID()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from author";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                authorGridView.DataSource = dt;
                cmbAuthor.DisplayMember = "Author_id";
                cmbAuthor.ValueMember = "Author_id";
                cmbAuthor.DataSource = dt;

                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all books!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        private void displayPublisherID()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from publisher";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                publisherGridView.DataSource = dt;
                cmbPublisher.DisplayMember = "Publisher_id";
                cmbPublisher.ValueMember = "Publisher_id";
                cmbPublisher.DataSource = dt;

                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all books!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void displayCategoryID()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from category";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                categoryGridView.DataSource = dt;
                cmbCategory.DisplayMember = "Category_id";
                cmbCategory.ValueMember = "Category_id";
                cmbCategory.DataSource = dt;

                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all books!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void viewBookInitialData()
        {
            int fID = Convert.ToInt32(cmbID.SelectedValue);
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from book where book_id=" + fID;
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtTitle.Text = reader["title"].ToString();
                    txtCopies.Text = reader["copies_available"].ToString();
                }
                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all books!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void viewMemberData()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from Member";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                memberGridView.DataSource = dt;
                cmbMemberID.DisplayMember = "Member_id";
                cmbMemberID.ValueMember = "Member_id";
                cmbMemberID.DataSource = dt;
                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all Member Details!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void viewLibrarianData()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from Librarian";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                librarianGridView.DataSource = dt;
                cmbLibrarianID.DisplayMember = "Librarian_id";
                cmbLibrarianID.ValueMember = "Librarian_id";
                cmbLibrarianID.DataSource = dt;
                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all Librarian Details!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void viewAuthorData()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from Author";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                authorGridView.DataSource = dt;
                cmbAuthorID.DisplayMember = "Author_id";
                cmbAuthorID.ValueMember = "Author_id";
                cmbAuthorID.DataSource = dt;
                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all authors!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void viewCategoryData()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from Category";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                categoryGridView.DataSource = dt;
                cmbCategoryID.DisplayMember = "Category_ID";
                cmbCategoryID.ValueMember = "Category_ID";
                cmbCategoryID.DataSource = dt;
                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all categories!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void viewPublisherData()
        {
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from Publisher";
                cmd.CommandText = query;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                publisherGridView.DataSource = dt;
                cmbPublisherID.DisplayMember = "Publisher_ID";
                cmbPublisherID.ValueMember = "Publisher_ID";
                cmbPublisherID.DataSource = dt;
                reader.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all publishers!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void Clear_Click(object sender, EventArgs e)
        {
            txtCopies.Clear();
            txtTitle.Clear();
        }
        private void Update_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            int author = Convert.ToInt32(cmbAuthor.SelectedValue);
            int publisher = Convert.ToInt32(cmbPublisher.SelectedValue);
            int category = Convert.ToInt32(cmbCategory.SelectedValue);
            int id = Convert.ToInt32(cmbID.SelectedValue);
            string copies = (txtCopies.Text);
            if (title=="" && v.ValidateInteger(copies))
            {
                try
                {

                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Update Book Set Title='" + title + "', Author_ID='" + author + "'," +
                        "Publisher_ID='" + publisher + "', Category_ID='" + category +
                        "', Copies_Available='" + copies + "' where Book_ID=" + id;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string message = "Error while updating the books!";
                    MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Book Data Updated Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }
        private void InsertBook_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            int author = Convert.ToInt32(cmbAuthor.SelectedValue);
            int publisher = Convert.ToInt32(cmbPublisher.SelectedValue);
            int category = Convert.ToInt32(cmbCategory.SelectedValue);
            int id = Convert.ToInt32(cmbID.SelectedValue);
            string copies = txtCopies.Text.ToString();
            if (v.ValidateString(title) && v.ValidateInteger(copies))
            {


                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Insert into Book values('" + title + "', '" +
                        author + "', '" + publisher + "', '" + category + "', '" + copies + "');";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Data Inserted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DisplayGridViews();
        }
        private void CloseAdministrator(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
            this.Hide();
        }
        private void BookGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.bookGridView.Rows[e.RowIndex];
                cmbID.Text = row.Cells["Book_id"].Value.ToString();
                txtTitle.Text = row.Cells["title"].Value.ToString();
                cmbAuthor.Text = row.Cells["author_Id"].Value.ToString();
                cmbPublisher.Text = row.Cells["Publisher_id"].Value.ToString();
                cmbCategory.Text = row.Cells["Category_id"].Value.ToString();
                txtCopies.Text = row.Cells["copies_available"].Value.ToString();
            }
        }
        private void CmbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbID.SelectedValue);
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from book where book_id=" + fID;
                cmd.CommandText = query;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtTitle.Text = reader["title"].ToString();
                    txtCopies.Text = reader["copies_available"].ToString();
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all books!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void InsertAuthor_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text.ToString();
            if (v.ValidateString(fname) && v.ValidateInteger(lname))
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Insert into Author values('" + fname + "', '" + lname + "');";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string errorMsg = "Error while inserting the author!";
                    MessageBox.Show(errorMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Author Data Inserted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }
        private void UpdateAuthor_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName.Text;
            string lname = txtLastName.Text.ToString();
            int id = Convert.ToInt32(cmbAuthorID.SelectedValue);
            if (v.ValidateString(fname) && v.ValidateInteger(lname))
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Update Author Set First_Name='" + fname + "',  Last_Name='" + lname + "' where author_ID=" + id;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string message = "Error while updating the Author!";
                    MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Author Data Updated Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }
        private void ClearAuthor_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
        }
        private void AuthorGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.authorGridView.Rows[e.RowIndex];
                cmbAuthorID.Text = row.Cells["author_id"].Value.ToString();
                txtFirstName.Text = row.Cells["First_Name"].Value.ToString();
                txtLastName.Text = row.Cells["Last_Name"].Value.ToString();
            }
        }
        private void CmbAuthorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbAuthorID.SelectedValue);
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from author where author_id=" + fID;
                cmd.CommandText = query;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtFirstName.Text = reader["First_Name"].ToString();
                    txtLastName.Text = reader["Last_Name"].ToString();
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all Authors!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void InsertPublisher_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName_Publisher.Text;
            string lname = txtLastName_Publisher.Text;
            if (v.ValidateString(fname) && v.ValidateInteger(lname))
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Insert into Publisher values ('" + fname + "','" + lname + "');";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string errorMsg = "Error while inserting the publisher!";
                    MessageBox.Show(errorMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Publisher Data Inserted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }
        private void UpdatePublisher_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName_Publisher.Text;
            string lname = txtLastName_Publisher.Text;
            int id = Convert.ToInt32(cmbPublisherID.SelectedValue);
            if (v.ValidateString(fname) && v.ValidateInteger(lname))
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Update Publisher Set First_Name='" + fname + "',  Last_Name='" + lname + "' where publisher_ID=" + id;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string message = "Error while updating the Publisher!";
                    MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Publisher Data Updated Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }
        private void ClearPublisher_Click(object sender, EventArgs e)
        {
            txtFirstName_Publisher.Clear();
            txtLastName_Publisher.Clear();
        }
        private void PublisherGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.publisherGridView.Rows[e.RowIndex];
                cmbPublisherID.Text = row.Cells["publisher_id"].Value.ToString();
                txtFirstName_Publisher.Text = row.Cells["First_Name"].Value.ToString();
                txtLastName_Publisher.Text = row.Cells["Last_Name"].Value.ToString();
            }
        }
        private void CmbPublisherID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbPublisherID.SelectedValue);
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from publisher where Publisher_id=" + fID;
                cmd.CommandText = query;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtFirstName_Publisher.Text = reader["First_Name"].ToString();
                    txtLastName_Publisher.Text = reader["Last_Name"].ToString();
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all Publishers!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void InsertCategory_Click(object sender, EventArgs e)
        {
            string fname = txtCategoryName.Text;

            if (v.ValidateString(fname))
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Insert into Category values ('" + fname + "');";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string errorMsg = "Error while inserting the Category of Book!";
                    MessageBox.Show(errorMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Book Category Data Inserted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }
        private void UpdateCategory_Click(object sender, EventArgs e)
        {
            string fname = txtCategoryName.Text;
            int id = Convert.ToInt32(cmbCategoryID.SelectedValue);
            if (v.ValidateString(fname))
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Update Category Set Name='" + fname + "' where Category_ID=" + id;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string message = "Error while updating the Category of book!";
                    MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Book Category Data Updated Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }
        private void ClearCategory_Click(object sender, EventArgs e)
        {
            txtCategoryName.Clear();
        }
        private void CategoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.categoryGridView.Rows[e.RowIndex];
                cmbCategoryID.Text = row.Cells["Category_id"].Value.ToString();
                txtCategoryName.Text = row.Cells["Name"].Value.ToString();
            }
        }
        private void CmbCategoryID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbCategoryID.SelectedValue);
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from Category where Category_id=" + fID;
                cmd.CommandText = query;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtCategoryName.Text = reader["Name"].ToString();
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all Category of books!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void InsertLibrarian_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName_Lib.Text;
            string lname = txtLastName_Lib.Text;
            string phn = txtPhone_Lib.Text;
            string email = txtEmail_Lib.Text;
            string address = txtAddress_Lib.Text;
            if (v.ValidateString(fname) && dateJoinLibrarian.Value.ToString() == "" && v.ValidateString(lname)
           && v.ValidateInteger(phn) && v.ValidateString(email) && address == "")
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Insert into Librarian values('" + dateJoinLibrarian.Text + "', '" +
                        fname + "', '" + lname + "', '" + phn + "', '" + email + "','" + address + "');";
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
                    MessageBox.Show("Librarian Data Inserted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }
        private void ClearLib_Click(object sender, EventArgs e)
        {
            txtAddress_Lib.Clear();
            txtEmail_Lib.Clear();
            txtFirstName_Lib.Clear();
            txtLastName_Lib.Clear();
            dateJoinLibrarian.Text = "";
            txtPhone_Lib.Clear();
        }
        private void CmbLibrarianID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbLibrarianID.SelectedValue);
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from Librarian where Librarian_id=" + fID;
                cmd.CommandText = query;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dateJoinLibrarian.Text = reader["Join_date"].ToString();
                    txtFirstName_Lib.Text = reader["First_Name"].ToString();
                    txtLastName_Lib.Text = reader["Last_Name"].ToString();
                    txtPhone_Lib.Text = reader["phone_number"].ToString();
                    txtEmail_Lib.Text = reader["email"].ToString();
                    txtAddress_Lib.Text = reader["address"].ToString();
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all Librarian Details!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void UpdateLibrarian_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName_Lib.Text;
            string lname = txtLastName_Lib.Text;
            string phn = txtPhone_Lib.Text;
            string email = txtEmail_Lib.Text;
            string address = txtAddress_Lib.Text;
            int id = Convert.ToInt32(cmbLibrarianID.SelectedValue);
            if (v.ValidateString(fname) && dateJoinLibrarian.Value.ToString() == "" && v.ValidateString(lname)
           && v.ValidateInteger(phn) && v.ValidateString(email) && address == "")
            {
                
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Update Librarian Set Join_Date='" + dateJoinLibrarian.Text + "',First_Name='" + fname + "',  Last_Name='" + lname + "',Phone_Number='" + phn + "',Email='" + email + "',Address = '" + address + "' where Librarian_ID=" + id;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string message = "Error while updating the Librarian Details!";
                    MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Librarian Data Updated Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }
        private void ClearMem_Click(object sender, EventArgs e)
        {
            txtFirstName_Mem.Clear();
            txtLastName_Mem.Clear();
            txtPhone_Mem.Clear();
            txtProfileImage.Clear();
            txtEmail_Mem.Clear();
            txtBookIssueLimit.Clear();
            txtAddress_Mem.Clear();
        }
        private void InsertMem_Click(object sender, EventArgs e)
        {
            int issueLimit = Convert.ToInt32(txtBookIssueLimit.Text);
            string fname = txtFirstName_Mem.Text;
            string lname = txtLastName_Mem.Text;
            string phn = txtPhone_Mem.Text;
            string email = txtEmail_Mem.Text;
            string address = txtAddress_Mem.Text;
            string proIma = txtProfileImage.Text;
            
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Insert into Member values('" + dateJoinMember.Text + "', '" +
                        fname + "', '" + lname + "', '" + phn + "', '" + email + "','" + address + "','" + proIma + "','" + issueLimit + "');";
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
                    MessageBox.Show("New Member Data Inserted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            DisplayGridViews();
        
            
        }
        private void CmbMemberID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbMemberID.SelectedValue);
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select * from Member where Member_id=" + fID;
                cmd.CommandText = query;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dateJoinMember.Text = reader["Join_date"].ToString();
                    txtFirstName_Mem.Text = reader["First_Name"].ToString();
                    txtLastName_Mem.Text = reader["Last_Name"].ToString();
                    txtPhone_Mem.Text = reader["phone_number"].ToString();
                    txtEmail_Mem.Text = reader["email"].ToString();
                    txtAddress_Mem.Text = reader["address"].ToString();
                    txtProfileImage.Text = reader["Profile_Image"].ToString();
                    txtBookIssueLimit.Text = reader["Issue_limit"].ToString();
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all Member Details!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private void UpdateMem_Click(object sender, EventArgs e)
        {
            string fname = txtFirstName_Mem.Text;
            string proIma = txtProfileImage.Text;
            string lname = txtLastName_Mem.Text;
            string phn = txtPhone_Mem.Text;
            string email = txtEmail_Mem.Text;
            string address = txtAddress_Mem.Text;
            int id = Convert.ToInt32(cmbMemberID.SelectedValue);
            string issueLimit = txtBookIssueLimit.Text;
            if (v.ValidateString(fname) && dateJoinLibrarian.Value.ToString() == "" && v.ValidateString(lname)
         && v.ValidateInteger(phn) && v.ValidateString(email) && address == "" && v.ValidateInteger(issueLimit))
                {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Update Member Set Join_Date='" + dateJoinMember.Text + "',First_Name='" + fname + "',  Last_Name='" + lname + "',Phone_Number='" + phn + "',Email='" + email + "',Address = '" + address + "',Profile_Image = '" + proIma + "',Issue_Limit='" + issueLimit + "' where Member_ID=" + id;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string message = "Error while updating the Librarian Details!";
                    MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Librarian Data Updated Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }
        private void BtnExitAuthor_Click(object sender, EventArgs e)
        {
            ExitAdministrator();
        }
        private void BtnExitPublisher_Click(object sender, EventArgs e)
        {
            ExitAdministrator();
        }
        private void ExitAdministrator()
        {
            HomePage hp = new HomePage();
            hp.Show();
            this.Hide();
        }
        private void BtnExitCategory_Click(object sender, EventArgs e)
        {
            ExitAdministrator();
        }
        private void BtnExitLibrarian_Click(object sender, EventArgs e)
        {
            ExitAdministrator();
        }
        private void BtnExitMember_Click(object sender, EventArgs e)
        {
            ExitAdministrator();
        }

        private void DeleteBookBtn_Click(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbID.SelectedValue);
            try
            {
                bool bookCurrentlyIssued = false;
                conn.ConnectionString = conString;
                string sql = "SELECT issue_id FROM ISSUE_details WHERE BOOK_ID=" + fID + " AND RETURNED='NO'";
                conn.Open();
                SqlDataReader dr = new SqlCommand(sql, conn).ExecuteReader();
                while (dr.Read())
                    bookCurrentlyIssued = true ;
                dr.Close();
                conn.Close();

                if (!bookCurrentlyIssued)
                {
                    cmd = conn.CreateCommand();
                    string query = "Delete from book where book_id=" + fID;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Book Deleted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Book issued, cannot delete");
                }
            }
            catch (Exception)
            {
                string message = "Error while deleting the book!";
                MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                
            }
            viewBookData();
        }

        private void DeleteAuthorBtn_Click(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbAuthorID.SelectedValue);
            try
            {
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                string query = "Delete from author where author_id=" + fID;
                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                string message = "Error while deleting the Author!";
                MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                MessageBox.Show("Author Deleted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            viewAuthorData();
        }

        private void DeletePublisherBtn_Click(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbPublisherID.SelectedValue);
            try
            {
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                string query = "Delete from publisher where publisher_id=" + fID;
                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                string message = "Error while deleting the Publisher!";
                MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                MessageBox.Show("Publihser Deleted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            viewPublisherData();
        }

        private void DeleteCategoryBtn_Click(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbCategoryID.SelectedValue);
            try
            {
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                string query = "Delete from category where category_id=" + fID;
                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                string message = "Error while deleting the Category!";
                MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                MessageBox.Show("Category Deleted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            viewCategoryData();
        }

        private void DeleteLibBtn_Click(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbLibrarianID.SelectedValue);
            try
            {
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                string query = "Delete from librarian where librarian_id=" + fID;
                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                string message = "Error while deleting the Librarian!";
                MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                MessageBox.Show("Librarian Deleted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            viewLibrarianData();
        }
        private void DeleteMemBtn_Click(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbMemberID.SelectedValue);
            try
            {
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
                string query = "Delete from Member where member_id=" + fID;
                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                string message = "Error while deleting the Member!";
                MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                MessageBox.Show("Member Deleted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            viewMemberData();
        }
        private void ClearIssue_Click(object sender, EventArgs e)
        {
            txtLimit.Clear();
        }

        private void InsertLimit_Click(object sender, EventArgs e)
        {
            string limit = txtLimit.Text;
            int bookID = Convert.ToInt32(cmbBookIssueID.SelectedValue);
            int memID = Convert.ToInt32(cmbBookMember.SelectedValue);
            if (v.ValidateInteger(limit))
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Insert into Book_Issue_Limit values ('" + bookID + "','" + memID + "','" + limit + "');";
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string errorMsg = "Error while inserting the book limit!";
                    MessageBox.Show(errorMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Book Limit Data Inserted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }

        private void UpdateLimit_Click(object sender, EventArgs e)
        {
            string limit = txtLimit.Text;
            int memID = Convert.ToInt32(cmbBookMember.SelectedValue);
            int id = Convert.ToInt32(cmbBookIssueID.SelectedValue);
            if (v.ValidateInteger(limit))
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Update Book_Issue_Limit Set book_Id='" + id + "',Limit = '" + limit + "' where member_ID=" + memID;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string message = "Error while updating the book issue limit!";
                    MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Book Issue Limit Data Updated Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }

        private void DeleteBtnBookIssue_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cmbBookIssueID.SelectedValue);
            int member = Convert.ToInt32(cmbBookMember.SelectedValue);
            {
                try
                {
                    conn.ConnectionString = conString;
                    cmd = conn.CreateCommand();
                    string query = "Delete from Book_Issue_Limit where Book_ID=" + id + " AND MEMBER_ID=" + member;
                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    string message = "Error while  deleting the book issue limit!";
                    MessageBox.Show(message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                    MessageBox.Show("Book Issue Limit Data Deleted Successfully!", "Confirm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            DisplayGridViews();
        }

        private void CmbBookIssueID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int fID = Convert.ToInt32(cmbBookIssueID.SelectedValue);
            cmd = conn.CreateCommand();
            try
            {
                string query = "Select limit from book_issue_limit where book_id=" + fID;
                cmd.CommandText = query;
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtLimit.Text = reader["limit"].ToString();
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception)
            {
                string errorMessage = "Error occured while retrieving all Book Issue Details!";
                MessageBox.Show(errorMessage, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Dispose();
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void AdministratorPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
        }
    }
    public class Validator
    {
        public bool ValidateString(string name)
        {
            //if (!string.IsNullOrEmpty(name))
            //{
            //    if (Regex.IsMatch(name, "^[a-zA-Z][a-zA-Z]*$"))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid Data in the Fields", "Validating...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Fields can not be Empty", "Validating...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            return true;
        }

        public bool ValidateInteger(string num)
        {
            //if (!string.IsNullOrEmpty(num))
            //{
            //    if (Regex.IsMatch(num, "^[0-9]"))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid Data in the Fields", "Validating...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Fields can not be Empty", "Validating...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            return true;
        }
    }
}



