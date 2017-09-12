using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DraftSimulator.ServerLogic;
using System.Configuration;

namespace DraftSimulator.DAL
{
    public class DraftRun
    {
        public int Ball1 { get; set; }
        public int Ball2 { get; set; }
        public int Ball3 { get; set; }
        public int Ball4 { get; set; }
        public List<DraftTeamRowItem> TeamList1 { get; set; }
        public List<DraftTeamRowItem> TeamList2 { get; set; }
        public List<DraftTeamRowItem> TeamList3 { get; set; }
        public List<DraftTeamRowItem> TeamList4 { get; set; }
        private static string Season = "2016/2017";

        //*************************
        // CHANGE LeagueID TO CHANGE THE LEAGUE THE DRAFT SIMULATION RUNS IN (IF HARDCODING)
        // Default:  LeagueId = "2"
        // If you have multiple leagues in the database (tblLeague), then you should set the LeagueID environment
        // variable to the ID of the league in the table you want to use.
        // Get the League to do the simulation on from environment settings in the Azure Web App service.
        private string LeagueID = ConfigurationManager.AppSettings["LeagueID"];

        // Get the database connection string from environment settings in the Azure Web App service.
        private string DBCnxn = ConfigurationManager.ConnectionStrings["SQLAZURECONNSTR_draftlottery"].ConnectionString;
        
       


        public DraftRun()
        {
            DraftRunLocation drl = new DraftRunLocation();
            drl.Country = "";
            drl.City = "";
            drl.Latitude = 0;
            drl.Longitude = 0;

            DraftBall draftball = new DraftBall(4);
            this.Ball1 = draftball.DraftBallNumber[0];
            this.Ball2 = draftball.DraftBallNumber[1];
            this.Ball3 = draftball.DraftBallNumber[2];
            this.Ball4 = draftball.DraftBallNumber[3];

            DoDraftRun(Ball1, Ball2, Ball3, Ball4, drl);
        }

        public DraftRun(decimal latitude, decimal longitude)
        {
            DraftBall draftball = new DraftBall(4);
            this.Ball1 = draftball.DraftBallNumber[0];
            this.Ball2 = draftball.DraftBallNumber[1];
            this.Ball3 = draftball.DraftBallNumber[2];
            this.Ball4 = draftball.DraftBallNumber[3];

            DraftRunLocation drl = new DraftRunLocation(latitude, longitude);
            DoDraftRun(Ball1, Ball2, Ball3, Ball4, drl);

        }
        public DraftRun(DraftRunLocation drl)
        {
            DraftBall draftball = new DraftBall(4);
            this.Ball1 = draftball.DraftBallNumber[0];
            this.Ball2 = draftball.DraftBallNumber[1];
            this.Ball3 = draftball.DraftBallNumber[2];
            this.Ball4 = draftball.DraftBallNumber[3];

            DoDraftRun(Ball1, Ball2, Ball3, Ball4, drl);
        }

        public DraftRun(int B1, int B2, int B3, int B4)
        {
            DraftRunLocation drl = new DraftRunLocation();
            drl.Country = "";
            drl.City = "";
            drl.Latitude = 0;
            drl.Longitude = 0;

            DoDraftRun(B1, B2, B3, B4, drl);
        }
        public int DoDraftRun(int B1, int B2, int B3, int B4, DraftRunLocation drl)
        {
            int TeamID = 0;
            int TeamSeqNumber = 0;

            Ball1 = B1;
            Ball2 = B2;
            Ball3 = B3;
            Ball4 = B4;

            TeamList1 = new List<DraftTeamRowItem>();
            TeamList2 = new List<DraftTeamRowItem>();
            TeamList3 = new List<DraftTeamRowItem>();
            TeamList4 = new List<DraftTeamRowItem>();

            if (LeagueID == null)
            {
                LeagueID = "1";
            }



            DataConnection dataConnection = new DataConnection(DBCnxn);

            // Get the list of teams still eligible for the first pick after Ball #1
            string queryString = "EXEC spShowDraftTeamCombos 1, " + Ball1.ToString() + ", " + Ball2.ToString() + ", " + Ball3.ToString() + ", " + Ball4.ToString() + ", " + LeagueID;
            DataTable queryResult = dataConnection.ExecuteQuery(queryString);

            foreach (DataRow row in queryResult.Rows)
            {
                DraftTeamRowItem draftrow = new DraftTeamRowItem();
                draftrow.TeamID = int.Parse(row["TeamID"].ToString());
                draftrow.TeamCity = row["TeamCity"].ToString();
                draftrow.TeamName = row["TeamName"].ToString();
                draftrow.TeamAbbr = row["TeamAbbr"].ToString();
                draftrow.ImagePrimaryLargeURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Large/" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimaryNormalURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Normal/" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimarySmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Small/s" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimaryXSmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/XSmall/xs" + row["TeamID"].ToString() + ".png";
                draftrow.ImageAltLargeURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Alternate/Large/alt" + row["TeamID"].ToString() + ".png";
                draftrow.ImageAltSmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Alternate/Small/alts" + row["TeamID"].ToString() + ".png";
                TeamList1.Add(draftrow);
            }
            
            // Get the list of teams still eligible for the first pick after Ball #2
            queryString = "EXEC spShowDraftTeamCombos 2, " + Ball1.ToString() + ", " + Ball2.ToString() + ", " + Ball3.ToString() + ", " + Ball4.ToString() + ", " + LeagueID;
            queryResult = dataConnection.ExecuteQuery(queryString);

            foreach (DataRow row in queryResult.Rows)
            {
                DraftTeamRowItem draftrow = new DraftTeamRowItem();
                draftrow.TeamID = int.Parse(row["TeamID"].ToString());
                draftrow.TeamCity = row["TeamCity"].ToString();
                draftrow.TeamName = row["TeamName"].ToString();
                draftrow.TeamAbbr = row["TeamAbbr"].ToString();
                draftrow.ImagePrimaryLargeURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Large/" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimaryNormalURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Normal/" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimarySmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Small/s" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimaryXSmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/XSmall/xs" + row["TeamID"].ToString() + ".png";
                draftrow.ImageAltLargeURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Alternate/Large/alt" + row["TeamID"].ToString() + ".png";
                draftrow.ImageAltSmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Alternate/Small/alts" + row["TeamID"].ToString() + ".png";
                TeamList2.Add(draftrow);
            }

            // Get the list of teams still eligible for the first pick after Ball #3
            queryString = "EXEC spShowDraftTeamCombos 3, " + Ball1.ToString() + ", " + Ball2.ToString() + ", " + Ball3.ToString() + ", " + Ball4.ToString() + ", " + LeagueID;
            queryResult = dataConnection.ExecuteQuery(queryString);

            foreach (DataRow row in queryResult.Rows)
            {
                DraftTeamRowItem draftrow = new DraftTeamRowItem();
                draftrow.TeamID = int.Parse(row["TeamID"].ToString());
                draftrow.TeamCity = row["TeamCity"].ToString();
                draftrow.TeamName = row["TeamName"].ToString();
                draftrow.TeamAbbr = row["TeamAbbr"].ToString();
                draftrow.ImagePrimaryLargeURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Large/" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimaryNormalURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Normal/" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimarySmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Small/s" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimaryXSmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/XSmall/xs" + row["TeamID"].ToString() + ".png";
                draftrow.ImageAltLargeURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Alternate/Large/alt" + row["TeamID"].ToString() + ".png";
                //draftrow.ImageAltSmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Alternate/Small/alts" + row["TeamID"].ToString() + ".png";
                TeamList3.Add(draftrow);
            }


            // Get the list of teams still eligible for the first pick after Ball #4
            queryString = "EXEC spShowDraftTeamCombos 4, " + Ball1.ToString() + ", " + Ball2.ToString() + ", " + Ball3.ToString() + ", " + Ball4.ToString() + ", " + LeagueID;
            queryResult = dataConnection.ExecuteQuery(queryString);

            foreach (DataRow row in queryResult.Rows)
            {
                DraftTeamRowItem draftrow = new DraftTeamRowItem();
                draftrow.TeamID = int.Parse(row["TeamID"].ToString());
                TeamID = int.Parse(row["TeamID"].ToString());
                draftrow.TeamCity = row["TeamCity"].ToString();
                draftrow.TeamName = row["TeamName"].ToString();
                draftrow.TeamAbbr = row["TeamAbbr"].ToString();
                TeamSeqNumber = int.Parse(row["TeamDraftChance"].ToString());
                draftrow.TeamSeqNumber = int.Parse(row["TeamDraftChance"].ToString());
                draftrow.SeqNumber = int.Parse(row["DraftBallRow"].ToString());
                draftrow.ImagePrimaryLargeURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Large/" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimaryNormalURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Normal/" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimarySmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/Small/s" + row["TeamID"].ToString() + ".png";
                draftrow.ImagePrimaryXSmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Primary/XSmall/xs" + row["TeamID"].ToString() + ".png";
                draftrow.ImageAltLargeURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Alternate/Large/alt" + row["TeamID"].ToString() + ".png";
                draftrow.ImageAltSmallURL = "https://draftsimulatorstorage.blob.core.windows.net/logos/Alternate/Small/alts" + row["TeamID"].ToString() + ".png";
                TeamList4.Add(draftrow);
            }


            queryString = "EXEC spLogDraftRun " + TeamSeqNumber.ToString() + ", " + TeamID.ToString() + ", 0, " + "'Web', '" + drl.Country + "', '" + drl.City + "', " + drl.Latitude + ", " + drl.Longitude + ", '" + Season + "'";
            queryResult = dataConnection.ExecuteQuery(queryString);

            return 0;
        }
        
    }
}
