using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTemplateWeb.Init.Cache
{
    public class RedisCacheProvider : ICacheProvider
    {
        public IDistributedCache _distributedCache { get; set; }
        public RedisCacheProvider(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        /// <summary>
        /// 將資料轉換為byte[]後存入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cacheSeconds"></param>
        public void Set(string key, object value, int cacheSeconds)
        {
            _distributedCache.Set(
                this.HashKey(key),
                this.ObjectToByteArray(value),
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheSeconds) }
                );
        }

        /// <summary>
        /// 依照傳入的型別回傳
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            var value = ByteArrayToObject<T>(_distributedCache.Get(this.HashKey(key)));

            return value;
        }

        /// <summary>
        /// 直接回傳byte[]型別
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            var value = _distributedCache.Get(this.HashKey(key));

            return value;
        }

        public bool IsSet(string key)
        {
            return _distributedCache.Get(this.HashKey(key)) != null;
        }

        public void Invalidate(string key)
        {
            _distributedCache.Remove(this.HashKey(key));
        }

        private byte[] ObjectToByteArray(object obj)
        {
            if (obj.GetType() == typeof(byte[]))
            {
                return (byte[])obj;
            }
            var objStr = JsonConvert.SerializeObject(obj);

            byte[] result = Encoding.UTF8.GetBytes(objStr);

            return result;
        }

        private T ByteArrayToObject<T>(byte[] bytes)
        {
            if (bytes != null)
            {
                string objStr = Encoding.UTF8.GetString(bytes);
                var obj = JsonConvert.DeserializeObject<T>(objStr);

                return obj;
            }
            else
            {
                return default(T);
            }
        }

        #region Hash
        private string HashKey(string key)
        {
            using (var sha = new System.Security.Cryptography.SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(key);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
        #endregion
    }
}
