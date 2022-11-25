using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.DtoModels
{
    public class ListeningRateReportModel
    {
        public int MemberShipTypeSeqID { get; set; }
        public int ProductSeqID { get; set; }
        public int CounrtySeqID { get; set; }
        public int MediaTypeSeqID { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<MemberShipTypeModel> MemberShipType { get; set; }
        public List<Products> Products { get; set; }
        public List<Counrty> Counrty { get; set; }
        public List<MediaTypeModel> MediaType { get; set; }
        public List<ListeningRateReport> ListeningRateReport { get; set; }
        public List<ListeningRateReportByUser> listeningRateReportByUser { get; set; }
        public List<listeningRateReportByUserDetail> listeningRateReportByUserDetail { get; set; }
        public bool byUser { get; set; }
        public bool ShowDetail { get; set; }
    }

    public class listeningRateReportByUserDetail
    {
        public string UserName { get; set; }
        public string ProductName { get; set; }
        public int time { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
