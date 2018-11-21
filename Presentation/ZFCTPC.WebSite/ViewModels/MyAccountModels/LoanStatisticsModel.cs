using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZFCTPC.WebSite.ViewModels.MyAccountModels
{
    public class LoanStatisticsModel
    {
        /// <summary>
        /// 已还本金
        /// </summary>
        public string already_principal { get; set; }

        /// <summary>
        /// 已还利息
        /// </summary>
        public string interest_rate { get; set; }
        /// <summary>
        /// 已还服务费
        /// </summary>
        public string serviced_charged { get; set; }
    }
}
