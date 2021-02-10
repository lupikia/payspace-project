using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;

namespace payspace.features
{
    public class Response_handler
    {

        public string Message;
        public object response_data = null;
        public Boolean response_with_data;

        private int message_code;

        public Response_handler(int code, Object data, Boolean response = false)
        {
            if (response)
            {
                response_with_data = response;
                response_data = data;
            }

            message_code = code;
        }

        public Object Response_handler_full_message()
        {

            Response_message message = new Response_message();

            Type myTypeB = typeof(Response_message);
            FieldInfo myFieldInfo1 = myTypeB.GetField("response_message_" + message_code, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            Message = myFieldInfo1.GetValue(message).ToString();
            Debug.WriteLine("The response message is ", myFieldInfo1.GetValue(message));

            return new { message = Message, data = response_data };
        }
    }
}