using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace OOP2
{
    class UpdateDBLin
    {
        MyDBDataContext cntx;
        

        public UpdateDBLin()
        {
            this.cntx= new MyDBDataContext(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Important Documents\Project\Solution1\OOP2\DotaDB.mdf;Integrated Security=True;Connect Timeout=30");
        }

        public string InsertHero(string x)
        {
            string r;
            try
            {
                var str = from a in cntx.Heros
                          where a.Name==x
                          select a;

                Hero test = str.First();
                r = "Hero Already Exist";
            }
            catch
            {
                Hero h = new Hero();
                h.Name = x;

                cntx.Heros.InsertOnSubmit(h);
                cntx.SubmitChanges();
                r = "Hero Inserted";

            }
            return r;
 
        }
        public string InsertTeam(string x, string y)
        {
            string r;
            try
            {
                var str = from a in cntx.Teams
                          where a.Name == x
                          select a;

                Team test = str.First();
                r = "Team Already Exist";

               

            }
            catch
            {
                try
                {
                    var str = from a in cntx.Teams
                              where a.IconPath == y
                              select a;
                    Team test = str.First();
                    r = "The Icon Already In use Exist";
                }
                catch
                {



                    Team t = new Team();
                    t.Name = x;
                    t.IconPath = y;

                    cntx.Teams.InsertOnSubmit(t);
                    cntx.SubmitChanges();
                    r = "Team Inserted";
                }
            }
            return r;
        }
        
        public string DeleteTeam(string x)
        {
            string y;
            try
            {
                var str = from a in cntx.Teams
                          where a.Name == x
                          select a;
                Team t = str.First();
                cntx.Teams.DeleteOnSubmit(t);
                cntx.SubmitChanges();
                y = "Successful";
            }
            catch
            {
                y = "Wrong Team Name";
            }

            return y;
        }
        public void InsertMatch(string x, string y,DateTime d)
        {
            Match m = new Match();
            m.Radient = x;
            m.Dire = y;
            m.Time = d;

            cntx.Matches.InsertOnSubmit(m);
            cntx.SubmitChanges();

        }
        public List<string>  getTeam()
        {
           
            var str= from a in cntx.Teams
                     select a.Name;
            List<string> li = str.ToList();
          
            return li;
        }

        public List<string> getHero()
        {

            var str = from a in cntx.Heros
                      select a.Name;
            List<string> li = str.ToList();

            return li;
        }
        public int MatchCount()
        {   
            DateTime ct= DateTime.Now;
            var str=from a in cntx.Matches
                    where a.Time>=ct
                    select a;
            int x= str.Count();

            return x;
        }

        public List<string>[] getMatch()

        {   DateTime ct= DateTime.Now;
        var str = from a in cntx.Matches
                  where a.Time >= ct
                  orderby a.Time descending
                  select a.Radient;
        var st = from a in cntx.Matches
                 where a.Time >= ct
                 orderby a.Time descending
                 select a.Dire;
        List<string>[] li = new List<string>[2];
            li[0]= new List<string>();
            li[0]=str.ToList();
            li[1] = new List<string>();
            li[1]= st.ToList();

            return li;
        }

        public string getIconPath(string x)
        {
            var str = from a in cntx.Teams
                      where a.Name == x
                      select a;
            Team t = str.First();
            return t.IconPath;
        }

        public List<DateTime> getTime()
        {  
            DateTime ct= DateTime.Now;
            var str = from a in cntx.Matches
                      where a.Time>=ct
                      select a.Time;
            List<DateTime> li = str.ToList();

            return li;
        }

        public string getPassword(string x)
        {
            User u= new User();
            try
            {
               var str = from a in cntx.Users
                      where a.UserName == x
                      select a;
               u = str.First();
            }
            catch
            {
                u.Password = null;
            }
            
            return u.Password; 
        }

        public string getAdminPass(string x)
        {
            Admin ax = new Admin();
            try
            {
                var str = from a in cntx.Admins
                          where a.UserName == x
                          select a;
                ax = str.First();
            }
            catch
            {
                ax.Password = null;
            }

            return ax.Password;
        }
        public Userinfo getUser(string x)
        {   
            User u=new User();
            Userinfo ui = new Userinfo();
            try
            {
                var str = from a in cntx.Users
                          where a.UserName == x
                          select a;
                u = str.First();
                ui.UName = u.UserName;
                ui.Pword = u.Password;
                ui.Igc = u.IGC;
                ui.UID = u.UserId;
                ui.Em = u.Email;
                ui.Picpath = u.Picture;
                ui.Abouts = u.AboutSelf;
            }
            catch
            {
                ui.UName = null;
            }

            return ui;
        }

        public AdminInfo getAdmin(string x)
        {   
            Admin a= new Admin();
            AdminInfo ai= new AdminInfo();
            try{
                var str = from u in cntx.Admins
                          where u.UserName==x
                          select u;
                a = str.First();
                ai.UName=a.UserName;
                ai.Pword=a.Password;
                ai.AID=a.AdminId;
            }
            catch{
                ai.UName = null;
            }


            return ai;
        }

        public void UpdateUP(string x,string y)
        {
            User u = new User();
            var str = from a in cntx.Users
                      where a.UserName == x
                      select a;
            u = str.First();
            u.Password = y;
            cntx.SubmitChanges();
        }
        public void UpdateAP(string x, string y)
        {
            Admin u = new Admin();
            var str = from a in cntx.Admins
                      where a.UserName == x
                      select a;
            u = str.First();
            u.Password = y;
            cntx.SubmitChanges();
        }
        public void UpdateU(string x, string y,string z)
        {
            User u = new User();
            var str = from a in cntx.Users
                      where a.UserName == x
                      select a;
            u = str.First();
            u.AboutSelf = y;
            u.Picture = z;
            cntx.SubmitChanges();
        }
        public void UpdateU(string x, string y)
        {
            User u = new User();
            var str = from a in cntx.Users
                      where a.UserName == x
                      select a;
            u = str.First();
            u.AboutSelf = y;
            cntx.SubmitChanges();

        }
        public void UpdateIGC(string x,int y)
        {
            User u = new User();
            var str = from a in cntx.Users
                      where a.UserName == x
                      select a;
            u = str.First();
            u.IGC = y;
            cntx.SubmitChanges();
        }


        public void InsertUser(Userinfo ui)
        {
            User u = new User();
            u.UserName = ui.UName;
            u.Password = ui.Pword;
            u.IGC = ui.Igc;
            u.Email = ui.Em;

            cntx.Users.InsertOnSubmit(u);
            cntx.SubmitChanges();
        }
        public void InsertAdmin(string x,string y)
        {
            Admin a = new Admin();
            a.UserName = x;
            a.Password = y;

            cntx.Admins.InsertOnSubmit(a);
            cntx.SubmitChanges();
        }

        public int getMatchID(string x, string y, DateTime d)
        {
            var str = from a in cntx.Matches
                      where a.Radient == x && a.Dire == y && a.Time == d
                      select a;

            Match m = str.First();

            return m.MatchId;
        }
        public void InsertBet(string u, int m, int x, int y, int z)
        {
            Bet b = new Bet();
            b.Username = u;
            b.MatchId = m;
            b.Section1 = x;
            b.Section2 = y;
            b.Section3 = z;

            cntx.Bets.InsertOnSubmit(b);
            cntx.SubmitChanges();
        }
        public void InsertPrediction(string u, int m,string w, string[] h, int r, int d)
        {
            MatchP mp = new MatchP();
            mp.Username = u;
            mp.MatchId = m;
            mp.Hero1 = h[0];
            mp.Hero2 = h[1];
            mp.Hero3 = h[2];
            mp.Hero4 = h[3];
            mp.Hero5 = h[4];
            mp.Hero6 = h[5];
            mp.Hero7 = h[6];
            mp.Hero8 = h[7];
            mp.Hero9 = h[8];
            mp.Hero10 = h[9];
            mp.Win = w;
            mp.RadientScore = r;
            mp.DireScore = d;

            cntx.MatchPs.InsertOnSubmit(mp);
            cntx.SubmitChanges();

        }

        public string UpdateHero(string x,string y)
        {  
            string r;
            try{ 
            Hero h= new Hero();
            var str= from a in cntx.Heros
                     where a.Name==x
                     select a;
            h=str.First();
            h.Name=y;
            cntx.SubmitChanges();
                r="Successfull";
            }
            catch{
                r="Cant Find Hero";
            }

            return r;
        }
        public string UpdateTeam(string x, string y)
        {
            string r;
            try
            {
                Team t = new Team();
                var str = from a in cntx.Teams
                          where a.Name == x
                          select a;
                t = str.First();
                t.Name = y;
                cntx.SubmitChanges();
                r = "Successfull";
            }
            catch
            {
                r = "Cant Find Team";
            }

            return r;
        }
        public int getPreCount(string x)
        {
            
            var str = from a in cntx.MatchPs
                      where a.Username == x
                      select a;

            int c = str.Count();
            return c;
        }
        public List<int> getPredID(string x)
        {
            var str = from a in cntx.MatchPs
                      where a.Username == x
                      select a.MatchId;

            List<int> li = str.ToList();
            return li;
        }
        public string[] getPredTeam(int x)
        {   
            Match m= new Match();
            var str = from a in cntx.Matches
                      where a.MatchId == x
                      select a;
            m=str.First();

            string[] s = new string[2];
            s[0] = m.Radient;
            s[1] = m.Dire;

            return s;
        }

        public MResult getResult(int x)
        {
            MResult m = new MResult();

            try
            {
                var str = from a in cntx.MResults
                          where a.MatchId == x
                          select a;
                
                m = str.First();
            }
            catch
            {
                createResult(x);
                m=getResult(x);
            }

            return m;
        }

        public int LastHero()
        {
            var str = from a in cntx.Heros
                      select a.Id;

            List<int> li = new List<int>();
            li = str.ToList();

            return li.Last();
        }
        public string getHeroName(int x)
        {
            string he;
            
                var str = from a in cntx.Heros
                          where a.Id == x
                          select a;
                Hero h = new Hero();
                h = str.First();
                he = h.Name;


            return he;
        }
        public DateTime getMatchTime(int x)
        {
            var str = from a in cntx.Matches
                      where a.MatchId == x
                      select a;
            Match m = new Match();
            m = str.First();

            return m.Time;
        }
        public MatchP getMatchPred(int x,string y)
        {
            var str = from a in cntx.MatchPs
                      where a.MatchId == x && a.Username==y
                      select a;
            MatchP mp = new MatchP();
            mp = str.First();
            return mp;
        }
        public Bet getBets(int x,string y)
        {
            var str=from a in cntx.Bets
                    where a.MatchId==x && a.Username==y
                    select a;
            Bet b = new Bet();
            b = str.First();
            return b;
        }
        public bool HeroMatchRad(string x,int y)
        {   
            bool b;
            try
            {
                var str = from a in cntx.MResults
                          where a.MatchId==y && ( a.Hero1 == x || a.Hero2 == x || a.Hero3 == x || a.Hero4 == x || a.Hero5 == x)
                          select a;
                MResult mr = str.First();
                b = true;
            }
            catch
            {
                b = false;
            }
            
            return b;
        }
        
        public bool HeroMatchDir(string x,int y)
        {
            bool b;
            try
            {
                var str = from a in cntx.MResults
                          where a.MatchId == y && (a.Hero6 == x || a.Hero7 == x || a.Hero8 == x || a.Hero9 == x || a.Hero10 == x)
                          select a;

                MResult mr = str.First();
                b = true;
            }
            catch
            {
                b = false;
            }
                
            return b;
        
        }

        public void DeletePred(string x, int y)
        {
            var str = from a in cntx.MatchPs
                      where a.Username == x && a.MatchId == y
                      select a;
            MatchP mp = str.First();

            cntx.MatchPs.DeleteOnSubmit(mp);
            cntx.SubmitChanges();
        }
        public void createResult(int x)
        {
            string win;
            string[] hero = new string[10];
            int rads;
            int ds;
            Random rnd = new Random();
            int w = rnd.Next(1);
            if (w == 0)
            {
                win = "Radient";
            }
            else
            {
                win = "Dire";
            }
            List<int> li = new List<int>();
            for (int i = 0; li.Count() < 10; i++)
            {
                int h = rnd.Next(1007, LastHero());
                if (!li.Contains(h))
                {
                    li.Add(h);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                hero[i] = getHeroName(li.ElementAt(i));
            }
            rads = rnd.Next(5, 60);
            ds = rnd.Next(5, 60);

            MResult mr = new MResult();
            mr.MatchId = x;
            mr.Win = win;
            mr.RadientScore = rads;
            mr.DireScore = ds;
            mr.Hero1 = hero[0];
            mr.Hero2 = hero[1];
            mr.Hero3 = hero[2];
            mr.Hero4 = hero[3];
            mr.Hero5 = hero[4];
            mr.Hero6 = hero[5];
            mr.Hero7 = hero[6];
            mr.Hero8 = hero[7];
            mr.Hero9 = hero[8];
            mr.Hero10 = hero[9];

            cntx.MResults.InsertOnSubmit(mr);
            cntx.SubmitChanges();
        }

        public void InsertUserPrediction(MatchP mp,int bs1,int bs2,int bs3,int w1,int w2,int w3)
        {
            UserPrediction up = new UserPrediction();
            up.MatchId = mp.MatchId;
            up.Username = mp.Username;
            up.Win = mp.Win;
            up.Hero1 = mp.Hero1;
            up.Hero2 = mp.Hero2;
            up.Hero3 = mp.Hero3;
            up.Hero4 = mp.Hero4;
            up.Hero5 = mp.Hero5;
            up.Hero6 = mp.Hero6;
            up.Hero7 = mp.Hero7;
            up.Hero8 = mp.Hero8;
            up.Hero9 = mp.Hero9;
            up.Hero10 = mp.Hero10;
            up.RadientScore = Convert.ToInt32(mp.RadientScore);
            up.DireScore = Convert.ToInt32(mp.DireScore);
            up.S1_Bet_Won = bs1.ToString() + "-" + w1.ToString();
            up.S2_Bet_Won = bs2.ToString() + "-" + w2.ToString();
            up.S3_Bet_Won = bs3.ToString() + "-" + w3.ToString();

            cntx.UserPredictions.InsertOnSubmit(up);
            cntx.SubmitChanges();

        }
        public void DeleteUserPrediction(string x, int y)
        {
            var str = from a in cntx.UserPredictions
                      where a.Username == x && a.MatchId == y
                      select a;
            UserPrediction up = str.First();

            cntx.UserPredictions.DeleteOnSubmit(up);
            cntx.SubmitChanges();
        }
        public bool detetcPred(string x, int y)
        {
            bool b;
            try
            {
                var str = from a in cntx.MatchPs
                          where a.Username == x && a.MatchId == y
                          select a;
                MatchP mp = str.First();
                b = true;

            }
            catch
            {
                b = false;
            }
            return b;
        }
        public User AdminGetUser(string x)
        {
            User u = new User();
            try
            {
                var str = from a in cntx.Users
                          where a.UserName == x
                          select a;
                 u = str.First();
            }
            catch
            {
                u.UserName = null;
            }
            return u;
        }

        public List<string> getAllUser()
        {
            var str = from a in cntx.Users
                      select a.UserName;

            List<string> li = str.ToList();

            return li;
        }
        
    }
}
