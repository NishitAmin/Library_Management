using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Final_Project
{
    class MemberClass
    {
        public MemberClass()
        {

        }

        private int memberID;
        private DateTime joinDate;
        private string fName;
        private string lName;
        private string number;
        private string email;
        private string address;
        private string profileImage;
        private int issueLimit;

        public MemberClass(int memberID, DateTime joinDate, string fName, string lName, string number, string email, string address, string profileImage, int issueLimit)
        {
            this.memberID = memberID;
            this.joinDate = joinDate;
            this.fName = fName;
            this.lName = lName;
            this.number = number;
            this.email = email;
            this.address = address;
            this.profileImage = profileImage;
            this.issueLimit = issueLimit;
        }

        public int MemberID { get => memberID; set => memberID = value; }

        public DateTime JoinDate { get => joinDate; set => joinDate = value; }

        public string FName { get => fName; set => fName = value; }

        public string LName { get => lName; set => lName = value; }

        public string Number { get => number; set => number = value; }

        public string Email { get => email; set => email = value; }

        public string Address { get => address; set => address = value; }

        public string ProfileImage { get => profileImage; set => profileImage = value; }

        public int IssueLimit { get => issueLimit; set => issueLimit = value; }

    }
}
