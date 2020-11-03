using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    class Administration
    {

        public Administration()
        {

        }

        private int BookID;
        private string bookTitle;
        private int authorID;
        private int publisherID;
        private int categoryID;
        private int copies;

        public Administration(int BookID, string bookTitle, int authorID,int publisherID,int categoryID,  int copies)
        {
            this.BookID = BookID;
            this.bookTitle = bookTitle;
            this.authorID = authorID;
            this.publisherID = publisherID;
            this.categoryID = categoryID;
            this.copies = copies;
        }

        public int Book_ID{ get => BookID; set => BookID = value; }

        public string Title { get => bookTitle; set => bookTitle = value; }

        public int Author_ID { get => authorID; set => authorID = value; }

        public int Publisher_ID  { get => publisherID; set => publisherID = value; }

        public int Category_ID { get => categoryID; set => categoryID = value; }

        public int Copies { get => copies; set => copies = value; }

    }
}

