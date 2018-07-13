using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class Userinfo
    {
        private string uName;
        private int uID;
        private string pword;
        private string em;
        private int igc;
        private string abouts;
        private string picpath;

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
        public string Em
        {
            set { this.em = value; }
            get { return this.em; }
        }
        public string Abouts
        {
            set { this.abouts = value; }
            get { return this.abouts; }
        }
        public string Picpath
        {
            set { this.picpath = value; }
            get { return this.picpath; }
        }
        public int UID
        {
            set { this.uID = value; }
            get { return this.uID; }
        }
        public int Igc
        {
            set { this.igc = value; }
            get { return this.igc; }
        }
    }
}
