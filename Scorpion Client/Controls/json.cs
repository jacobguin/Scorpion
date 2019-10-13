using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Scorpion_Client.Controls
{
    public class json
    {
        public static string Parse(string JSON, string Parse)
        {
            try
            {
                dynamic Data = JsonConvert.DeserializeObject<dynamic>(JSON);
                string Out = DataBinder.Eval(Data, Parse);
                return Out;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a proplem reading '{JSON}' | ", ex);
            }
        }

        public static JObject ParseObject(string JSON, string Parse)
        {
            try
            {
                dynamic Data = JsonConvert.DeserializeObject<dynamic>(JSON);
                JObject Out = DataBinder.Eval(Data, Parse);
                return Out;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a proplem reading '{JSON}' | ", ex);
            }
        }

        public static JArray ParseArray(string JSON, string Parse = "")
        {
            try
            {
                if (Parse != "")
                {
                    dynamic Data = JsonConvert.DeserializeObject<dynamic>(JSON);
                    JArray Out = DataBinder.Eval(Data, Parse);
                    return Out;
                }
                else
                {
                    return JsonConvert.DeserializeObject<dynamic>(JSON);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a proplem reading '{JSON}' | ", ex);
            }
        }

        public static JArray AddToArray(JArray array, string NewObject)
        {
            try
            {
                JArray obj = array;
                obj.Add(JObject.Parse(NewObject));
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a proplem reading '{array.ToString()}' or '{NewObject}' | ", ex);
            }
        }

        public static JObject GetLastJArrayObject(string JSON)
        {
            try
            {
                dynamic something = JsonConvert.DeserializeObject<dynamic>(JSON);
                JArray obj = something.channel_messages;
                return JObject.Parse(obj[int.Parse((obj.Count() - 1).ToString())].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a proplem reading '{JSON}' | ", ex);
            }
        }
    }
}
