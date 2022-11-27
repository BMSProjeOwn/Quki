using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quki.Entity.Models
{
    public class SP_BANK
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(2)]
        public string STATUS { get; set; }

        public int? PRIORTY { get; set; }
        [MaxLength(20)]
        public string BANK_CODE { get; set; }
        [MaxLength(20)]
        public string BANK_NAME { get; set; }
        [MaxLength(250)]
        public string SERVER_ADDRESS { get; set; }
        [MaxLength(5)]
        public string SERVER_PORT { get; set; }

        [MaxLength(250)]
        public string SERVER_NAME { get; set; }
        [MaxLength(250)]
        public string SERVER_PATH { get; set; }
        [MaxLength(250)]
        public string VPOS_2D_URL { get; set; }
        [MaxLength(250)]
        public string VPOS_3D_URL { get; set; }
        [MaxLength(20)]
        public string EOD_TIME { get; set; }

        public bool? RECON_TYPE { get; set; }
        [MaxLength(20)]
        public string RECON_START_TIME { get; set; }
        [MaxLength(20)]
        public string RECON_FINISH_TIME { get; set; }
        [MaxLength(250)]
        public string MERCHANT_ID { get; set; }
        [MaxLength(250)]
        public string TERMINAL_ID { get; set; }
        [MaxLength(250)]
        public string PASS { get; set; }
        [MaxLength(250)]
        public string CURRENCY_CODE { get; set; }
        [MaxLength(250)]
        public string MODIFIED_BY { get; set; }

        public DateTime? MODIFIED_DATE { get; set; }
        [MaxLength(250)]
        public string USERNAME { get; set; }
        [MaxLength(250)]
        public string UserID { get; set; }
        [MaxLength(250)]
        public string MERCHANT_MODEL { get; set; }
        [MaxLength(250)]
        public string SuccessUrl { get; set; }
        [MaxLength(250)]
        public string FAILUREURL { get; set; }
        [MaxLength(250)]
        public string Storekey { get; set; }

        public bool? Test_Mode { get; set; }

        public bool? DebugMode { get; set; }

        public int? ResponseTimeOut { get; set; }

        public int? GroupID { get; set; }
        [MaxLength(250)]
        public string GoupName { get; set; }
        [MaxLength(250)]
        public string GroupImagePath { get; set; }
        [MaxLength(250)]

        public string ApiKey { get; set; }
        [MaxLength(250)]
        public string SecretKey { get; set; }
        [MaxLength(250)]
        public string BaseUrl { get; set; }

    }
}
