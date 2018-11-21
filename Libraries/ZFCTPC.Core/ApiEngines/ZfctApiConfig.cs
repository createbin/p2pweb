using System;
using System.Collections.Generic;
using System.Text;

namespace ZFCTPC.Core.ApiEngines
{
    public partial class ZfctApiConfig
    {
        public CoInfo CoInfo { get; set; }
    }

    public class CoInfo
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Code { get; set; }
        public string Url { get; set; }
        public string ApiAddress { get; set; }
        public string StatisticApiAddress { get; set; }
        public string BhApiAddress { get; set; }
        public string IsTest { get; set; }
        public List<Interfaces> Interfaces { get; set; }
    }

    public class Interfaces
    {
        public string Name { get; set; }

        public string ActionUrl { get; set; }

        public string IsHtml { get; set; }

        public string Desc { get; set; }
    }
}
