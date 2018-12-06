using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class GenericType
    {
        /// <summary>
        /// Creates a new instance of an object.
        /// </summary>
        /// <param name="fullName">The fully qualified assembly name of the type to get. Example: "SomeClass, SomeNamespace.SomeClass"</param>
        /// <returns>The object of the fully qualified assembly name of the type.</returns>
        public static object Create(string fullName)
        {
            if (String.IsNullOrEmpty(fullName)) throw new ArgumentNullException("fullName");

            try
            {
                Type LookupType = Type.GetType(fullName);

                return Activator.CreateInstance(LookupType);
            }
            catch
            {
                throw;
            }
        }

        ///// <summary>
        ///// Create a new instance of an object.
        ///// </summary>
        ///// <typeparam name="T">Type of the instance to be created.</typeparam>
        ///// <param name="fullName">The fully qualified assembly name of the type to get. Example: "SomeClass, SomeNamespace.SomeClass"</param>
        ///// <returns>The type of the fully qualified assembly name of the type.</returns>
        //public static T Create<T>(string fullName)
        //{
        //    if (String.IsNullOrEmpty(fullName)) throw new ArgumentNullException("fullName");

        //    try
        //    {
        //        Type LookupType = Type.GetType(fullName);

        //        return (T)Activator.CreateInstance(LookupType);
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        /// <summary>
        /// Create a new instance of an object.
        /// </summary>
        /// <typeparam name="T">Type of the instance to be created.</typeparam>
        /// <returns>The type of the fully qualified assembly name of the type.</returns>
        public static T Create<T>()
        {
            try
            {
                return Activator.CreateInstance<T>();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Create a new instance of an object.
        /// </summary>
        /// <param name="anonymousObject"></param>
        /// <returns>The object of the fully qualified assembly name of the type.</returns>
        public static object Create(object anonymousObject)
        {
            if (anonymousObject == null) return null;

            try
            {
                return Activator.CreateInstance(anonymousObject.GetType());
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Create a new instance of an object.
        /// </summary>
        /// <param name="anonymousType"></param>
        /// <returns>The object of the fully qualified assembly name of the type.</returns>
        public static object Create(Type anonymousType)
        {
            if (anonymousType == null) return null;

            try
            {
                return Activator.CreateInstance(anonymousType);
            }
            catch
            {
                throw;
            }
        }
    }
}
