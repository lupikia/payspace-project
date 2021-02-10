using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace payspace.features
{
    public class DataFormat
    {
        public Dictionary<string, object> form;

        public void Format(object data)
        {

            var temp = JsonConvert.SerializeObject(data);
            form = JsonConvert.DeserializeObject<Dictionary<string, object>>(temp);

        }

        public T Get_Format_anything<T>()
        {
            var temp = JsonConvert.SerializeObject(form);
            T t = JsonConvert.DeserializeObject<T>(temp);

            return t;
        }
    }
}