using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftSimulator.DAL
{
    public class DraftTeamRowItem
    {
        public int TeamID { get; set; }
        public string TeamCity { get; set; }
        public string TeamName { get; set; }
        public string TeamAbbr { get; set; }
        public int SeqNumber { get; set; }
        public int TeamSeqNumber { get; set; }
        public string ImagePrimaryLargeURL { get; set; }
        public string ImagePrimaryNormalURL { get; set; }
        public string ImagePrimarySmallURL { get; set; }
        public string ImagePrimaryXSmallURL { get; set; }
        public string ImageAltLargeURL { get; set; }
        public string ImageAltSmallURL { get; set; }

        public DraftTeamRowItem()
        {
            return;
        }

        public DraftTeamRowItem(int Ball1, int Ball2, int Ball3, int Ball4)
        {

        }
    }
}
