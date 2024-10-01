using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motto_Vehicle_DataFeed.DAO
{
    public class DevSprintDetail
    {
        public int SprintID { get; set; }
        public string SprintCode { get; set; }
        public string ProjectCode { get; set; }
        public string JiraLink { get; set; }
        public DateTime SprintFrom { get; set; }
        public DateTime SprintTo { get; set; }
        public string EpicName { get; set; }
        public string UserStoryName { get; set; }
        public string PerformedBy { get; set; }
        public int Status { get; set; }
    }
}
