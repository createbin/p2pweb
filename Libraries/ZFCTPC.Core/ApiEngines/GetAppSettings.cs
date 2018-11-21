using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZFCTPC.Core.ApiEngines
{
    public class ApiEngineToConfiguration
    {
        public static string GetAppSettingsUrl(string key)
        {
            var coinfo = ZfctApiEngines.Instance().CoInfo;
            var action = coinfo.ApiAddress;
            var result = ZfctApiEngines.Instance().CoInfo.Interfaces.First(p => p.Name == key).ActionUrl;
            return action + result;
        }

        public static string GetStatisticAppSettingUrl(string key)
        {
            var coinfo = ZfctApiEngines.Instance().CoInfo;
            var action = coinfo.StatisticApiAddress;
            var result = ZfctApiEngines.Instance().CoInfo.Interfaces.First(p => p.Name == key).ActionUrl;
            return action + result;
        }

        public static string GetZfctUrl()
        {
            var coinfo = ZfctApiEngines.Instance().CoInfo;
            var Url = coinfo.Url;
            return Url;
        }

        public static string GetBhApiAddress()
        {
            var coinfo = ZfctApiEngines.Instance().CoInfo;
            var action = coinfo.BhApiAddress;
            return action;
        }

        public static string GetBhAppSettingsUrl(string key)
        {
            var coinfo = ZfctApiEngines.Instance().CoInfo;
            var action = coinfo.BhApiAddress;
            var result = ZfctApiEngines.Instance().CoInfo.Interfaces.First(p => p.Name == key).ActionUrl;
            return action + result;
        }

        public static string GetCurrentEnv()
        {
            var result = ZfctApiEngines.Instance().CoInfo.IsTest;
            return result;
        }
    }
}
