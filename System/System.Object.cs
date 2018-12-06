using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.IO;
using System.Xml.Serialization;
using System.Web;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace System
{
    public static class ObjectConvertExtension
    {
        /// <summary>
        /// Serializes a serializable object to XML
        /// </summary>
        /// <typeparam name="T">The type of the members of values.</typeparam>
        /// <param name="anonymousObject">Serializable Object</param>
        /// <returns>XML string of the object</returns>
        public static string ToXml<T>(this object anonymousObject)
        {
            if (anonymousObject == null) return String.Empty;

            XmlSerializer xml = new XmlSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream())
            {
                xml.Serialize(ms, anonymousObject);

                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// Serializes a serializable object to XML
        /// </summary>
        /// <param name="anonymousObject">Serializable Object</param>
        /// <returns>XML string of the object</returns>
        public static string ToXml(this object anonymousObject)
        {
            if (anonymousObject == null) return String.Empty;

            XmlSerializer xml = new XmlSerializer(anonymousObject.GetType());

            using (MemoryStream ms = new MemoryStream())
            {
                xml.Serialize(ms, anonymousObject);

                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// Serializes a serializable object to JSON
        /// </summary>
        /// <param name="anonymousObject">Serializable Object</param>
        /// <returns>JSON string of the object</returns>
        public static string ToJSON(this object anonymousObject)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            return serializer.TryCatchThrow(i => i.Serialize(anonymousObject));
        }

        /// <summary>
        /// Serializes a serializable object to JSON
        /// Note: WCF JSON string. Uses DataContract Serializer.
        /// </summary>
        /// <typeparam name="T">The type of the members of values.</typeparam>
        /// <param name="anonymousObject">Serializable Object</param>
        /// <returns>JSON string of the object</returns>
        public static string ToJSON2<T>(this object anonymousObject)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(typeof(T));

            using (MemoryStream ms = new MemoryStream())
            {
                json.WriteObject(ms, anonymousObject);

                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        /// <summary>
        /// Serializes a serializable object to JSON
        /// Note: WCF JSON string. Uses DataContract Serializer.
        /// </summary>
        /// <param name="anonymousObject">Serializable Object</param>
        /// <returns>JSON string of the object</returns>
        public static string ToJSON2(this object anonymousObject)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(anonymousObject.GetType());

            using (MemoryStream ms = new MemoryStream())
            {
                json.WriteObject(ms, anonymousObject);

                return System.Text.Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
}
