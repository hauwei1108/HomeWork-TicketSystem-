using ApplicationCore.BusinessModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Util
{
    public class Util
    {
        private IServiceProvider _services;
        private IConfiguration _config;
        private string LocalIp;

        public Util(IServiceProvider services, IConfiguration config)
        {
            _services = services;
            _config = config;
        }

        /// <summary>
        /// 取得本機IP
        /// </summary>
        /// <returns></returns>
        public string GetLocalIp(string clientIp)
        {
            if (string.IsNullOrEmpty(LocalIp) == false)
                return LocalIp;

            // 取得本機HostName
            string strHostName = Dns.GetHostName();

            // 取得本機的IpHostEntry實體
            IPHostEntry iPHostEntry = Dns.GetHostEntry(strHostName);

            //Client IP拆解
            string[] clientIpSplit = clientIp.Split('.');

            string localIP = string.Empty;

            // 取得所有IP位址
            foreach (IPAddress iPAddress in iPHostEntry.AddressList)
            {
                //Local IP 拆解
                string[] loaclIpSplit = iPAddress.ToString().Split('.');

                // 只取得IP V4位址
                bool isIpV4 = iPAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork;
                //判斷網段 前兩區是否相同
                if (isIpV4 &&
                    string.Equals(clientIpSplit[0], loaclIpSplit[0]) &&
                    string.Equals(clientIpSplit[1], loaclIpSplit[1]))
                {
                    return iPAddress.ToString();
                }
                else if (isIpV4)
                {
                    localIP = iPAddress.ToString();
                }
            }

            LocalIp = localIP;
            return localIP;
        }

        /// <summary>
        /// 取得遠端請求 IP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetRemoteIp(HttpContext context)
        {
            string result;

            if (context.Request.Headers.ContainsKey("X-Real-IP"))
            {
                result = context.Request.Headers["X-Real-IP"].ToString();
            }
            else if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                result = context.Request.Headers["X-Forwarded-For"].ToString();
            }
            else
            {
                result = context.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }

            return result;
        }

        /// <summary>
        /// 檢查第一個 IP 是否大於等於第二個 IP
        /// </summary>
        /// <param name="firstIp"></param>
        /// <param name="secondIp"></param>
        /// <returns></returns>
        public bool IsIpGreatThan(string firstIp, string secondIp)
        {
            long firstIpNumTotal = ConvertIpToInt(firstIp);
            long secondIpNumTotal = ConvertIpToInt(secondIp);

            if (firstIpNumTotal >= secondIpNumTotal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 檢查第一個 IP 是否小於等於第二個 IP
        /// </summary>
        /// <param name="firstIp"></param>
        /// <param name="secondIp"></param>
        /// <returns></returns>
        public bool IsIpLessThan(string firstIp, string secondIp)
        {
            long firstIpNumTotal = ConvertIpToInt(firstIp);
            long secondIpNumTotal = ConvertIpToInt(secondIp);

            if (firstIpNumTotal <= secondIpNumTotal)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public long ConvertIpToInt(string ipAddress)
        {
            long result = 0;

            string[] ipArray = ipAddress.Split('.');

            long[] ipNumber = new long[4];
            for (int i = 0; i < 4; i++)
            {
                ipNumber[i] = long.Parse(ipArray[i].Trim());
            }

            result = ipNumber[0] * 256 * 256 * 256 + ipNumber[1] * 256 * 256 + ipNumber[2] * 256 + ipNumber[3];

            return result;
        }

        /// <summary>
        /// 阿拉伯數字轉中文
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public string NumToChinese(string number)
        {
            if (number == "0")
            {
                return "零";
            }

            string[] pArrayNum = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            //為數字位數建立一個位數組  
            string[] pArrayDigit = { "", "十", "百", "千" };
            //為數字位數建立一個單位數組  
            string[] pArrayUnits = { "", "萬", "億", "萬億" };
            var pStrReturnValue = ""; //返回值  
            var finger = 0; //字符位置指針
            var pIntM = number.Length % 4; //取模  
            int pIntK;
            if (pIntM > 0)
                pIntK = number.Length / 4 + 1;
            else
                pIntK = number.Length / 4;
            //外層循環,四位一組,每組最後加上單位: ",萬億,",",億,",",萬,"  
            for (var i = pIntK; i > 0; i--)
            {
                var pIntL = 4;
                if (i == pIntK && pIntM != 0)
                    pIntL = pIntM;
                //得到一組四位數
                var four = number.Substring(finger, pIntL);
                var P_int_l = four.Length;
                //內層循環在該組中的每一位數上循環  
                for (int j = 0; j < P_int_l; j++)
                {
                    //處理組中的每一位數加上所在位
                    int n = Convert.ToInt32(four.Substring(j, 1));
                    if (n == 0)
                    {
                        if (j < P_int_l - 1 && Convert.ToInt32(four.Substring(j + 1, 1)) > 0 && !pStrReturnValue.EndsWith(pArrayNum[n]))
                            pStrReturnValue += pArrayNum[n];
                    }
                    else
                    {
                        if (!(n == 1 && (pStrReturnValue.EndsWith(pArrayNum[0]) | pStrReturnValue.Length == 0) && j == P_int_l - 2))
                            pStrReturnValue += pArrayNum[n];
                        pStrReturnValue += pArrayDigit[P_int_l - j - 1];
                    }
                }
                finger += pIntL;
                //每組最後加上一個單位:",萬,",",億," 等  
                if (i < pIntK) //如果不是最高位的一組  
                {
                    if (Convert.ToInt32(four) != 0)
                        //如果所有4位不全是0則加上單位",萬,",",億,"等  
                        pStrReturnValue += pArrayUnits[i - 1];
                }
                else
                {
                    //處理最高位的一組,最後必須加上單位  
                    pStrReturnValue += pArrayUnits[i - 1];
                }
            }
            return pStrReturnValue;
        }

        /// <summary>
        /// BaeBo加IP
        /// </summary>
        /// <param name="targetObj"></param>
        /// <param name="clientIp"></param>
        public void AddIp(BaseBo targetObj, string clientIp)
        {
            targetObj.ClientIp = clientIp;
            targetObj.ServerIp = GetLocalIp(clientIp);
        }

        public IEnumerable<List<T>> SplitList<T>(List<T> source, int splitCount)
        {
            List<List<T>> result = new List<List<T>>();

            int indexFrom;
            int dataCount = source.Count();
            int loopCount = dataCount / splitCount;
            int plus = (dataCount % splitCount) != 0 ? 1 : 0;
            int getCount = splitCount;

            for (int i = 0; i < loopCount + plus; i++)
            {
                indexFrom = (splitCount * i);
                getCount = (dataCount - indexFrom) >= splitCount ? splitCount : (dataCount - indexFrom);

                result.Add(source.GetRange(indexFrom, getCount));
            }

            return result;
        }

        public void RandomList<T>(IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = list.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                T value = list[rnd];
                list[rnd] = list[i];
                list[i] = value;
            }
        }
    }
}
