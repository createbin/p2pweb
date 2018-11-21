using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModelReturn.News
{
    public class NewsReturnModel
    {
        public NewsReturnModel()
        {
            NewsList = new List<NewsDescription>();
        }
        /// <summary>
        /// 新闻类别ID
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类别描述
        /// </summary>
        public string Description { get; set; }

        public int Count { get; set; }

        public List<NewsDescription> NewsList { get; set; }
    }
    public class NewsDescription
    {
        /// <summary>
        /// 新闻ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 简单描述
        /// </summary>
        public string Short { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string SkipLink { get; set; }

        public string Details { get; set; }
    }
}
