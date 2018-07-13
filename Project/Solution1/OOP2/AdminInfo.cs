using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
     public class AdminInfo
    {
        private string uName;
        private int aID;
        private string pword;

        public string UName
        {
            set { this.uName = value; }
            get { return this.uName; }
        }
        public string Pword
        {
            set { this.pword = value; }
            get { return this.pword; }
        }
        public int AID
        {
            set { this.aID = value; }
            get { return this.aID; }
        }
    }
}
