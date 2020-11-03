//DEVELOPED BY : ROHAN PATEL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Librarian : Form
    {
        private SqlConnection con = new SqlConnection("Server=DESKTOP-10VIATC\\SQLEXPRESS;Database=csharp;User=rohanPatel;Password=1234");
        public Librarian()
        {
            InitializeComponent();
            FillAllGridViews();
            issueReturnDate.MinDate = DateTime.Today;
            newReturnDate.MinDate = DateTime.Today;
            cmbSearchFilter.SelectedIndex = 0;
        }
        private void FillAllGridViews()
        {
            ViewIssuedBooks();
            ViewIssueRequests();
            GenerateBAPReport();
            ViewReturnRequests();
            ViewToUpdateReturns();
        }
        private void ViewIssuedBooks()
        {
            issuedBooksGridView.DataSource = SelectQueries.GetAllIssuedBooks();
            overDueBooksGridView.DataSource = SelectQueries.GetAllOverdueBooks();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Approve
            if (cmbStatusID.SelectedIndex == 0)
            {
                int rowIndex = issueRequestGridView.CurrentCell.RowIndex;
                DataGridViewRow row = issueRequestGridView.Rows[rowIndex];
                int memberID = Convert.ToInt32(row.Cells[1].Value);
                int bookID = Convert.ToInt32(row.Cells[3].Value);
              
                int totalCurrentIssues = SelectQueries.CountCurrentIssuedBooks(memberID);
                int allowedIssues = SelectQueries.CountMemberIssueLimit(memberID);
               

                //MEMBER IS IN HIS ISSUE LIMIT

                if (totalCurrentIssues < allowedIssues)
                {
                    int bookIssueCount = SelectQueries.BookIssuedCount(memberID,bookID,"YES");
                    int bookIssueLimit = SelectQueries.BookReissueLimitCount(bookID,memberID);
                   
                    //member is in limit of reissuing current book
                    if (bookIssueCount<bookIssueLimit)
                    {
                        
                        string issueDate = DateTime.Now.Date.ToShortDateString();
                        string returnDate =issueReturnDate.Value.ToShortDateString();
                        if (SelectQueries.GetCopiesAvailable(bookID) > 0)
                        {
                            InsertQueries.IssueBook(bookID, memberID, issueDate, returnDate, "NO");
                            UpdateQueries.DecreaseBookQuantitiy(bookID);
                            UpdateQueries.FinishIssueRequest("APPROVED", Convert.ToInt32(cmbIssueRequestID.SelectedValue.ToString()));
                            MessageBox.Show("BOOK ISSUED SUCCESSFULLY", "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ViewIssueRequests();
                        }
                        else
                        {
                            MessageBox.Show("NO COPIES AVAILABLE IN THE LIBRARY \n " +
                           "PLEASE WAIT TILL COPIES BECOME AVAILABLE", "REJECTED", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    else
                    {
                        MessageBox.Show("REISSUE LIMIT OF THIS PARTICULAR BOOK REACHED \n " +
                            "CAN NO MORE ISSUE THIS SAME BOOK","REJECTED",MessageBoxButtons.OK,MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MessageBox.Show("ISSUE LIMIT OF MEMBER REACHED \n " +
                            "CAN NO MORE ISSUE ANY BOOK", "REJECTED", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            //DECLINED
            if (cmbStatusID.SelectedIndex == 1)
            {
                    UpdateQueries.FinishIssueRequest("DECLINED", Convert.ToInt32(cmbIssueRequestID.SelectedValue.ToString()));
                    ViewIssueRequests();
                MessageBox.Show("ISSUE REQUEST DECLINED\n ","DECLINED", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ViewIssueRequests()
        {
                DataTable dt = SelectQueries.GetIssueRequests();
                issueRequestGridView.DataSource = dt;
                cmbIssueRequestID.DisplayMember = "issue_request_id";
                cmbIssueRequestID.ValueMember = "issue_request_id";
                cmbIssueRequestID.DataSource = dt;

        }

        private void GenerateBAPReport()
        {
            booksReportGridView.DataSource =SelectQueries.GetAllBooks();
            authorReportGridView.DataSource = SelectQueries.GetAllAuthors();
            publisherReportGridView.DataSource = SelectQueries.GetAllPublisher();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            GenerateBAPReport();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearchBox.Text;
            //search by book title
            if (cmbSearchFilter.SelectedIndex == 0)
                bookSearchGridView.DataSource = SelectQueries.SearchBookByTitle(searchQuery);
            //search by author
            if (cmbSearchFilter.SelectedIndex == 1)
                bookSearchGridView.DataSource = SelectQueries.SearchBookByAuthor(searchQuery);
            //search by publisher
            if (cmbSearchFilter.SelectedIndex == 2)
                bookSearchGridView.DataSource = SelectQueries.SearchBookByPublisher(searchQuery);
            //search by category
            if (cmbSearchFilter.SelectedIndex == 3)
                bookSearchGridView.DataSource = SelectQueries.SearchBookByCategory(searchQuery);
            if (bookSearchGridView.Rows.Count == 1)
                MessageBox.Show("Book not found.\n Please try searching again", "NOT FOUND"
                    ,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else
                MessageBox.Show("Book Found", "FOUND",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void BookSearchGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = bookSearchGridView.Rows[rowIndex];
            int bookID = Convert.ToInt32(row.Cells[0].Value);
            try
            {
                bookIssueGridView.DataSource = SelectQueries.GetBookIssues(bookID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        private void ViewReturnRequests()
        {
            try
            {
                DataTable dt = SelectQueries.GetReturnRequests();
                returnRequestGridView.DataSource = dt;
                cmbReturnRequestID.DisplayMember = "return_request_id";
                cmbReturnRequestID.ValueMember = "return_request_id";
                cmbReturnRequestID.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void ReturnRequestGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = returnRequestGridView.Rows[rowIndex];
            DateTime returnDate = Convert.ToDateTime(row.Cells[3].Value);
            if (DateTime.Compare(DateTime.Today, returnDate) > 0)
            {
                txtOverdueAmount.Enabled = true;
                MessageBox.Show("BOOK IS OVERDUE : PLEASE ENTER THE OVERDUE CHARGE", "OVERDUE", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double dueAmount = 0;
            int rowIndex = returnRequestGridView.CurrentCell.RowIndex;
            DataGridViewRow row = returnRequestGridView.Rows[rowIndex];
            DateTime returnDate = Convert.ToDateTime(row.Cells[3].Value);
            int issueID = Convert.ToInt32(row.Cells[0].Value);

            try
            {
                if (DateTime.Compare(DateTime.Today, returnDate) > 0)
                {
                    if (txtOverdueAmount.Text.Trim() == "")
                        MessageBox.Show("AMOUNT CANNOT BE EMPTY");
                    else
                    {
                        dueAmount = Convert.ToDouble(txtOverdueAmount.Text.Trim());

                        try
                        {
                            InsertQueries.InsertIntoOverdue(issueID, dueAmount,cmbPaidStatus.SelectedValue.ToString());
                            UpdateQueries.FinishReturnRequest(Convert.ToInt32(cmbReturnRequestID.SelectedValue.ToString()));
                            UpdateQueries.UpdateIssueReturnRequest(issueID);
                            UpdateQueries.IncreaseBookQuantity(SelectQueries.GetBookidFromIssueId(issueID));
                            MessageBox.Show("Return request successfully served");
                            ViewReturnRequests();
                        }
                        catch (Exception exc)
                        {
                            Console.WriteLine(exc);
                        }
                    }
                }
                else
                {
                    try
                    {
                        InsertQueries.InsertIntoReturn(issueID, DateTime.Now.Date.ToShortDateString());
                        UpdateQueries.FinishReturnRequest(Convert.ToInt32(cmbReturnRequestID.SelectedValue.ToString()));
                        UpdateQueries.UpdateIssueReturnRequest(issueID);
                        UpdateQueries.IncreaseBookQuantity(SelectQueries.GetBookidFromIssueId(issueID));
                        MessageBox.Show("Return request successfully served");
                        ViewReturnRequests();
                    }
                    catch (Exception exc)
                    {
                        Console.WriteLine(exc);
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Due amount can only be in number");
                Console.WriteLine(ex);
            }

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            issuedBooksGridView.DataSource = SelectQueries.GetAllIssuedBooks();
            overDueBooksGridView.DataSource = SelectQueries.GetAllOverdueBooks();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
        
            int issueID = Convert.ToInt32(cmbIssueID_return.SelectedValue.ToString());
            string newDate = newReturnDate.Value.ToShortDateString();

            int bookID = SelectQueries.GetBookidFromIssueId(issueID);
            int crntIssueReq = SelectQueries.GetBookCountInIssueRequests(bookID);

            //Book issue can be extended as no issue requests are there for that book
            if (crntIssueReq == 0)
            {
                UpdateQueries.UpdateReturnDate(issueID, newDate);
                string message = "Return Date successfully changed";
                MessageBox.Show(message, "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ViewToUpdateReturns();
            }
            else
            {
                string message= "Cannot change return date as there is a issue request for same book";
                MessageBox.Show(message, "PROBIHATED", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
           
        }
        private void ViewToUpdateReturns()
        {
            DataTable dt= SelectQueries.GetAllIssuedBooks();
            updateReturnsGridView.DataSource = dt;
            cmbIssueID_return.ValueMember = "issue_id";
            cmbIssueID_return.DisplayMember = "issue_id";
            cmbIssueID_return.DataSource = dt;
        }

        private void Librarian_FormClosed(object sender, FormClosedEventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();
        }
    }
}
