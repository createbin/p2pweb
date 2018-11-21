using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZFCTPC.WebSite.ViewModels.MyAccountModels
{
    public class IndexModel
    {
        /// <summary>
        /// 用户等级
        /// </summary>
        public string userLevel { get; set; }
        /// <summary>
        /// 等级图片
        /// </summary>
        public string userLevelPic { get; set; }
        /// <summary>
        /// 总资产
        /// </summary>
        public string general_assets { get; set; }
        /// <summary>
        /// 今日待收
        /// </summary>
        public string collecting_today { get; set; }
        /// <summary>
        /// 冻结金额
        /// </summary>
        public string freezing_amount { get; set; }
        /// <summary>
        /// 待收本金
        /// </summary>
        public string principal_amount { get; set; }
        /// <summary>
        /// 可用余额
        /// </summary>
        public string enable_amount { get; set; }
        /// <summary>
        /// 累计收益
        /// </summary>
        public string earned_interest { get; set; }
        /// <summary>
        /// 待还罚息
        /// </summary>
        public string punitive_interest { get; set; }
        /// <summary>
        /// 今日待还
        /// </summary>
        public string total_samount { get; set; }
        /// <summary>
        /// 待还利息
        /// </summary>
        public string still_interest { get; set; }
        /// <summary>
        /// 待还本金
        /// </summary>
        public string also_principal { get; set; }
        /// <summary>
        /// 待还服务费
        /// </summary>
        public string service_charge { get; set; }
        /// <summary>
        /// 可用红包总金额
        /// </summary>
        public string redused_money { get; set; }
        /// <summary>
        /// 累计借款数量
        /// </summary>
        public int loan_count { get; set; }
        /// <summary>
        /// 累计借款金额
        /// </summary>
        public string loan_money { get; set; }
        /// <summary>
        /// 借款招标中
        /// </summary>
        public int loan_tendercount { get; set; }
        /// <summary>
        /// 借款还款中
        /// </summary>
        public int loan_repaycount { get; set; }
        /// <summary>
        /// 借款满标中
        /// </summary>
        public int loan_stayrepaycount { get; set; }
        /// <summary>
        /// 借款已结清
        /// </summary>
        public int loan_settledcount { get; set; }
        /// <summary>
        /// 累计投资数量
        /// </summary>
        public int invest_count { get; set; }
        /// <summary>
        /// 累计投资金额
        /// </summary>
        public string invest_money { get; set; }
        /// <summary>
        /// 投资投标中
        /// </summary>
        public int invest_tendercount { get; set; }
        /// <summary>
        /// 投资还款中
        /// </summary>
        public int invest_repaycount { get; set; }
        /// <summary>
        /// 投资已结清
        /// </summary>
        public int invest_settledcount { get; set; }
        /// <summary>
        /// 债权可转让
        /// </summary>
        public int transfer_cancount { get; set; }
        /// <summary>
        /// 债权转出中
        /// </summary>
        public int transfer_tendercount { get; set; }
        /// <summary>
        /// 债权已转让
        /// </summary>
        public int transfer_tenderedcount { get; set; }
        /// <summary>
        /// 债权可转入
        /// </summary>
        public int transfer_settledcount { get; set; }
        /// <summary>
        /// 是否开户
        /// </summary>
        public string OtherAccount { get; set; }
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

        /// <summary>
        /// 待收利息
        /// </summary>
        public string collect_interest { get; set; }
        /// <summary>
        /// 已收回本金
        /// </summary>
        public string recovered_principal { get; set; }
        /// <summary>
        /// 净收益
        /// </summary>
        public string net_earning { get; set; }

    }
}
