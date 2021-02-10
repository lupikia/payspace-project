using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace payspace.features
{
  class Validations :Exception
    {

        private string regx = null;
        public IDictionary<string,string> erros = new Dictionary<string, string>();
        private DataFormat clean_format = new DataFormat();

        public void Validate_form(Dictionary<string,dynamic> form)
        {

            foreach(string key_name in form.Keys.ToList())
            {
                regx = Get_regx(key_name);
                
                if (!Validate_field(form[key_name].ToString()))
                {
                    erros.Add(key_name, "is invalid");
                }
            }

            //-->check if there is no erros
          //  throw new Exception_handler(1,null);
            if (erros.Count>=1)
            {
                throw new Exception_handler(0, erros, true);

               // txt.Email = "lo";
            }
        }

        public Boolean Validate_field(string fied_value)
        {
            Regex rg = new Regex(regx);
            if (rg.Match(fied_value).Success)
            {
                return true;
            }
            return false;
        }

        private string Get_regx(string field_name)
        {
            SortedList<string,List<string>> expression = new SortedList<string, List<string>>()
            {
                {@"^([a-zA-Z0-9]){0,4}$",new List<string>(){"postal_code"}},
                {@"^[0-9]{0,}(.)[0-9]{0,}$",new List<string>(){"income"}} 
            };

            foreach(KeyValuePair<string,List<string>> express_item in expression)
            {
                if (express_item.Value.Contains(field_name))
                {
                    return express_item.Key.ToString();
                }
            }
            Debug.WriteLine("Regx field check "+ field_name);
            throw new Exception_handler(1,null,false);
            
        }
    }
}
