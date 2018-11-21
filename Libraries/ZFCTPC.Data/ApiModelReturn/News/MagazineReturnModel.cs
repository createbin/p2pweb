using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Data.ApiModelReturn.News
{
    public class ManagizeModel
    {
        public ManagizeModel()
        {
            ManagizeList = new List<MagazineReturnModel>();
        }

        public int Count { get; set; }

        public List<MagazineReturnModel> ManagizeList { get; set; }
    }

    public class MagazineReturnModel
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
    }
}
