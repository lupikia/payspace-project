using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace payspace.features
{
    
    public class Exception_handler : Exception
    {


        public string Message;
        public object response_data = null;
        public Boolean response_with_data;

        private int error_code;

        public Exception_handler() { 

        }
        public Exception_handler(int code, Object data,Boolean response=false)
        {
            if (response)
            {
                response_with_data= response;
                response_data = data;
            }


            error_code = code;
            Exception_handler_get_error();
         
        }

        private void Exception_handler_get_error()
        {

            Error_message error = new Error_message();

            Type myTypeB = typeof(Error_message);
            FieldInfo myFieldInfo1 = myTypeB.GetField("error_code_"+ error_code, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            Message = myFieldInfo1.GetValue(error).ToString() + ", error code:" + error_code + ". Please contact support";
            Debug.WriteLine("The value of the private field is: '{0}'", myFieldInfo1.GetValue(error));
        }

        public string Exception_handler_general_error(string journey= "unidentified")
        {

            return  "Error_code: 10111, view: "+ journey + ". Please contact support";
        }

        public Object Exception_handler_full_error()
        {

            return new { message = Message, data = response_data };
        }

    }
}