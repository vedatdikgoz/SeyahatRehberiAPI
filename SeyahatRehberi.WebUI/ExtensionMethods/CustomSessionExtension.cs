using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SeyahatRehberi.WebUI.ExtensionMethods
{
    public static class CustomSessionExtension
    {
        public static void SetObject(this ISession session, string key, object obj)
        {
            var jsonData = JsonConvert.SerializeObject(obj);
            session.SetString(key,jsonData);
        }

        public static T GetObject<T>(this ISession session,string key) where T:class, new()
        {
            var data=session.GetString(key);
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
