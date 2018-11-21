using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModel.Promotion
{
    public class AdvertisementCountRequestModel : BaseRequestModel
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 条数
        /// </summary>
        public int Count { get; set; }
    }

    public class AdvertisementPageRequestModel : RequestPageModel
    {
        /// <summary>
        /// 关键字
        /// </summary>
        public string Code { get; set; }
    }

    public class NewsDetailRequestModel: RequestPageModel
    {
        public int Id { get; set; }
    }

    public class ManagizeCountRequestModel : RequestPageModel
    {

        public int Year { get; set; }

        public int Count { get; set; }
        /// <summary>
        /// 企业内刊1,运营报告2
        /// </summary>
        public int Category { get; set; }
    }

    public class tbInternalMagazine
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public string Skiplinks { get; set; }

        public int? Sort { get; set; }

        public bool IsDel { get; set; }

        public int State { get; set; }

        public int? Creater { get; set; }

        public DateTime CreateDate { get; set; }

        public int? Category { get; set; }

        public DateTime? PublishTime { get; set; }
    }
}
