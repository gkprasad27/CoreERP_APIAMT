//using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CoreERP.BussinessLogic.Common
{
    class JsonValueConvertor<T> : JsonConverter<T>
    {
       

        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {

            try
            {
                //if (typeToConvert.FullName == "System.Decimal")
                //    return new Decimal();

                //return reader.GetString().ToString();

                return (T)Convert.ChangeType(reader.GetString(), typeof(T));
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            try
            {
                //if (typeof(T).Equals(typeof(decimal?)))
                //    writer.WriteNumberValue(Convert.ToDecimal(value));

                //if (typeof(T).Equals(typeof(decimal)))
                //    writer.WriteNumberValue(Convert.ToDecimal(value));

                //if (typeof(T).Equals(typeof(string)))
                    writer.WriteStringValue(value.ToString());

                //if (typeof(T).Equals(typeof(int)))
                //    writer.WriteNumberValue(Convert.ToInt32(value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static T ConvertValue<T>(string value)
        //{
        //    return (T)Convert.ChangeType(value, typeof(T));
        //}

        //public override void WriteJson(JsonWriter writer, T value, Newtonsoft.Json.JsonSerializer serializer)
        //{
        //    writer.WriteValue(value);
        //}

        //public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        //{
        //    if(reader.Value !=null)
        //    return (T)Convert.ChangeType(reader.Value, typeof(T));

        //   return default(T);
        //}
    }
}
