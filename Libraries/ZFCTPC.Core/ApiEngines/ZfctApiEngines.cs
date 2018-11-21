using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ZFCTPC.Core.Caching;

namespace ZFCTPC.Core.ApiEngines
{
    public class ZfctApiEngines
    {
        #region

        private static ZfctApiConfig _zfctApiConfig;
        private const string XmlPath = "/App_Data/ZfctApi.json";
        #endregion


        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public static ZfctApiConfig Instance()
        {
            if (_zfctApiConfig == null)
            {
               var path = System.AppContext.BaseDirectory;
               var current = path;
               if (path.IndexOf("bin", StringComparison.Ordinal) >= 0)
               {
                   var indexSrc = path.IndexOf("bin");
                   current = path.Substring(0, indexSrc);
               }
               Initialize(current + XmlPath);
            }
            return _zfctApiConfig;
        }


        /// <summary>
        /// 解析json
        /// </summary>
        /// <param name="configFile"></param>
        public static void Initialize(string configFile)
        {
            var jsons = File.ReadAllText(configFile);
            var result = JsonConvert.DeserializeObject<ZfctApiConfig>(jsons);
            _zfctApiConfig = result;
        }

        #region 打印日志
        public static void WriteLog(string strLog)
        {
            string sFilePath = "I:\\发布\\Logs" + "\\" + DateTime.Now.ToString("yyyyMMdd");
            string sFileName = DateTime.Now.ToString("ddHH") + ".log";
            sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
            if (!System.IO.Directory.Exists(sFilePath))//验证路径是否存在
            {
                System.IO.Directory.CreateDirectory(sFilePath);
                //不存在则创建
            }
            FileStream fs;
            StreamWriter sw;
            if (File.Exists(sFileName))
                //验证文件是否存在，有则追加，无则创建
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
            }
            sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "   ---   " + strLog);
            sw.Dispose();
            fs.Dispose();

        }

        #endregion

    }
}
