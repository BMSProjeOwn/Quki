using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quki.Entity.Models;

namespace Quki.Entity.ViewModel
{
    public class ProducerDetailModel
    {
        public int ProducerSeqID { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string ImageThumpPath { get; set; }
        public string History { get; set; }
        public string Remark { get; set; }
        public string Phone { get; set; }
        public string SocialMedia { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public List<Products> Products { get; set; }
    }
}
