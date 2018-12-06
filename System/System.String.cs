using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace System
{
    public static class SystemStringExtension
    {
        /// <summary>
        /// Takes a xml string and deserializes it back to a object of a type.
        /// </summary>
        /// <typeparam name="TResult">The type of the members of values.</typeparam>
        /// <param name="strValue">Current String</param>
        /// <returns>returns a deserialized object of the type of T.</returns>
        public static TResult FromXML<TResult>(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue) == false) return GenericType.Create<TResult>();

            using (TextReader textReader = new StringReader(strValue))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TResult));
                return xmlSerializer.Deserialize(textReader).ToTypeCast<TResult>();
            }
        }

        /// <summary>
        /// Takes a JSON string and deserializes it back to a object of a type.
        /// </summary>
        /// <typeparam name="TResult">The type of the members of values.</typeparam>
        /// <param name="strValue">Current String</param>
        /// <returns>return a deserialized object of the type of T.</returns>
        public static TResult FromJSON<TResult>(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue) == false) return GenericType.Create<TResult>();

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.Deserialize<TResult>(strValue);
        }

        /// <summary>
        /// Takes a JSON2 string and deserializes it back to a object of a type.
        /// </summary>
        /// <typeparam name="TResult">The type of the members of values.</typeparam>
        /// <param name="strValue">Current String</param>
        /// <returns>returns a deserialized object of the type of T.</returns>
        public static TResult FromJSON2<TResult>(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue) == false) return GenericType.Create<TResult>();

            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(TResult));

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(Encoding.UTF8.GetBytes(strValue), 0, strValue.Length);

                return json.ReadObject(ms).ToTypeCast<TResult>();
            }
        }

        /// <summary>
        /// Takes a string and encodes it to a Base64 string.
        /// </summary>
        /// <param name="strValue">Current String</param>
        /// <returns>Base64 encode string.</returns>
        public static string ToBase64(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue) == false) return String.Empty;

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(strValue));
        }

        /// <summary>
        /// Takes a Base64 string and decodes it to a string.
        /// </summary>
        /// <param name="strValue">Current String</param>
        /// <returns>string of the decoded string.</returns>
        public static string FromBase64(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue) == false) return String.Empty;

            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(strValue));
            }
            catch
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Takes a Base64 string and decodes it to a string.
        /// </summary>
        /// <param name="strValue">Current String</param>
        /// <returns>string of the decoded string.</returns>
        public static TResult FromBase64<TResult>(this string strValue)
        {
            if (String.IsNullOrEmpty(strValue) == false) return GenericType.Create<TResult>();

            try
            {
                return Convert.FromBase64String(strValue).ToTypeCast<TResult>();
            }
            catch
            {
                return GenericType.Create<TResult>();
            }
        }
    }
}
