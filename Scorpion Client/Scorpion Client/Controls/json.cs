namespace Scorpion_Client.Controls
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class Json
    {
        public static string Parse(string json, string parse)
        {
            try
            {
                dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
                string @out = DataBinder.Eval(data, parse);
                return @out;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a problem reading '{json}' | ", ex);
            }
        }

        public static JObject ParseObject(string json, string parse)
        {
            try
            {
                dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
                JObject @out = DataBinder.Eval(data, parse);
                return @out;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a problem reading '{json}' | ", ex);
            }
        }

        public static JArray ParseArray(string json, string parse = "")
        {
            try
            {
                if (parse != "")
                {
                    dynamic data = JsonConvert.DeserializeObject<dynamic>(json);
                    JArray @out = DataBinder.Eval(data, parse);
                    return @out;
                }
                else
                {
                    return JsonConvert.DeserializeObject<dynamic>(json);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a problem reading '{json}' | ", ex);
            }
        }

        public static JArray AddToArray(JArray array, string newObject)
        {
            try
            {
                JArray obj = array;
                obj.Add(JObject.Parse(newObject));
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a problem reading '{array.ToString()}' or '{newObject}' | ", ex);
            }
        }

        public static JObject GetLastJArrayObject(string json)
        {
            try
            {
                dynamic something = JsonConvert.DeserializeObject<dynamic>(json);
                JArray obj = something.channel_messages;
                return JObject.Parse(obj.Last().ToString());
            }
            catch (Exception ex)
            {
                throw new Exception($"There was a problem reading '{json}' | ", ex);
            }
        }
    }
}
