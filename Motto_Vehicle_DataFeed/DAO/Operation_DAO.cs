using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motto_Vehicle_DataFeed.DAO
{
    public class Status_Type
    {
        public int StatusTypeID { get; set; }
        public string StatusName { get; set; }
        public string StatusName_TH { get; set; }
        public string StatusType { get; set; }
    }

    public class Transport_ATS_Log
    {
        public int id { get; set; }
        public int TxnType { get; set; }
        public DateTime TxnDate { get; set; }
        public string TxnTime{ get; set; }
        public string VehicleNumber { get; set; }
        public string TxnLocation { get; set; }
        public int StatusUpdateBy { get; set; }
    }
}
