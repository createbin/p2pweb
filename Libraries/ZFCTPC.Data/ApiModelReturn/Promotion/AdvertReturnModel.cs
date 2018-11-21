using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModelReturn.Promotion
{
    public class AdvertCountReturnModel
    {
        public AdvertCountReturnModel()
        {
            AdvertisementList = new List<AdvertisementDetail>();
        }
        /// <summary>
        /// 类别ID
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }

        public int Count { get; set; }

        public IList<AdvertisementDetail> AdvertisementList { get; set; }
    }

    public class AdvertPageReturnModel
    {
        /// <summary>
        /// 类别ID
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string CategoryName { get; set; }

        public ReturnPageData<AdvertisementDetail> AdvertisementList { get; set; }
    }

    public class AdvertisementDetail
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int? AdvertisPositionId { get; set; }

        public string ImageUrl { get; set; }

        public string SkipUrl { get; set; }

        public int? Sort { get; set; }

        public string ProjectType { get; set; }

        public int? JumpPosition { get; set; }

        public string JumpInfo { get; set; }

        public int? State { get; set; }

        public DateTime? StartinTime { get; set; }

        public DateTime? EndTime { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
