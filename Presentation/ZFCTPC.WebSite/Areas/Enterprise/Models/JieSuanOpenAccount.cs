
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZFCTPC.WebSite.Areas.Enterprise.Models
{
    public class JieSuanOpenAccount
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string companyName { get; set; }
        /// <summary>
        /// 法人姓名
        /// </summary>
        public string realName { get; set; }
        /// <summary>
        /// 法人身份证
        /// </summary>
        public string realCard { get; set; }
        /// <summary>
        /// 开户类型
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// 三证号
        /// </summary>
        public string idCard { get; set; }
        /// <summary>
        /// 营业执照号
        /// </summary>
        public string licenseCode { get; set; }
        /// <summary>
        /// 税务登记号
        /// </summary>
        public string taxId { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string contactUser { get; set; }
        /// <summary>
        /// 联系人手机号
        /// </summary>
        public string contactPhone { get; set; }
    }

    public class BoHainOpenAccount
    {
        /// <summary>
        /// 对公帐号
        /// </summary>
        public string accountNo { get; set; }
        /// <summary>
        /// 对公银行
        /// </summary>
        public string accountBank { get; set; }
        /// <summary>
        /// 户名
        /// </summary>
        public string accountName { get; set; }
    }
}
