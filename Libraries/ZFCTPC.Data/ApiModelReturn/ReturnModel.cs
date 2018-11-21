using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModelReturn
{
    #region 返回数据类型
    /// <summary>
    ///返回数据类型
    /// </summary>
    /// <typeparam name="T">返回数据主体类型</typeparam>
    /// <typeparam name="S">Token类型</typeparam>
    public class ReturnModel<T, S>
    {
        //返回码
        public int ReturnCode { get; set; }
        //返回数据
        public T ReturnData { get; set; }
        //token
        public S Token { get; set; }
        //签名
        public string Signature { get; set; }
        //提示信息
        public string Message { get; set; }
        /// 加密前数据
        public string Extra1 { get; set; }
        /// 加密后数据
        public string Extra2 { get; set; }
        /// <summary>
        /// 网站号码
        /// </summary>
        public string WebPhone { get; set; }
    }

    public class ReturnPageData<T>
    {
        //分页的数据
        public IEnumerable<T> PagingData { get; set; }
        //总数据条数
        public int Total { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCount { get; set; }

        /// <summary>
        /// 额外数据1
        /// </summary>
        public string Extra1 { get; set; }

        /// <summary>
        /// 额外数据2
        /// </summary>
        public string Extra2 { get; set; }
    }

    /// <summary>
    /// 充值  投资 绑卡 提现返回model 
    /// </summary>
    public class ReLoanModel<T>
    {
        //是否跳转
        public bool IsJump { get; set; }
        //提交地址
        public string SubmitUrl { get; set; }
        //提交跳转页的数据
        public T SubData { get; set; }
    }

    public class RToPage
    {
        /// <summary>
        /// 跳转链接
        /// </summary>
        public string Url { get; set; }
    }

    public class RVerifyInfo
    {
        public string Type { get; set; }

        public bool IsExit { get; set; }
    }

    public class RToInvestResult
    {
        public string ErrorInfo { get; set; }

        public string ErrorCode { get; set; }
    }
    #endregion

    /// <summary>
    /// 用户交易记录
    /// </summary>
    public class RToTradingModel
    {
        //主键id
        public int id;

        //交易类型
        public string TradingType { get; set; }

        //交易金额
        public decimal TradingMoney { get; set; }

        //交易时间
        public string TradingDate { get; set; }

        //交易状态
        public string TradingStatus { get; set; }

        //交易流水号
        public string TradingOrderNo { get; set; }

        //项目名称
        public string TradingName { get; set; }

        //交易后账户余额
        public decimal TrandingAccountMoney { get; set; }
        /// <summary>
        /// 手续费金额
        /// </summary>
        public string FeeAmt { get; set; }
        /// <summary>
        /// 失败原因
        /// </summary>
        public string FailedReson { get; set; }
    }
}
