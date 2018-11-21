using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Core.Enums
{
    public enum ProjectStateEnum
    {
        /// <summary>
        /// 招标中
        /// </summary>
        Tender = 20,

        /// <summary>
        /// 满标待审
        /// </summary>
        FullScalePending=21,

        /// <summary>
        /// 待划转
        /// </summary>
        StayTransfer=23,

        /// <summary>
        /// 还款中
        /// </summary>
        Repayment=24,

        /// <summary>
        /// 已结清
        /// </summary>
        Settled=25,

        /// <summary>
        /// 已逾期
        /// </summary>
        Overdue=734,
        /// <summary>
        /// 初审已通过
        /// </summary>
        HasThrough = 109,
        /// <summary>
        /// 已划转
        /// </summary>
        HasTransfer=113
    }
}
