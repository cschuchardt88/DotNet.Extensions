using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class SystemTypeExtension
    {

        /// <summary>
        /// The type you want to cast too. Object must match casting type passed. Otherwise
        /// returns a new object of TResult, if cast is invaild.
        /// </summary>
        /// <typeparam name="TResult">The type to cast the object to.</typeparam>
        /// <param name="anonymousObject">Current object. Can not be null.</param>
        /// <returns>Casted object of the TResult</returns>
        public static TResult ToTypeCast<TResult>(this object anonymousObject)
        {
            if (anonymousObject == null) throw new NullReferenceException();

            try
            {
                return (TResult)anonymousObject;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Determines whether the specified object is an instance of the current System.Type.
        /// </summary>
        /// <param name="anonymousObject">The source object to compare with the current type.</param>
        /// <param name="ObjectToCompare">The object to compare with the current type.</param>
        /// <returns>
        ///     true if the current Type is in the inheritance hierarchy of the object represented
        ///     by o, or if the current Type is an interface that o supports. false if neither
        ///     of these conditions is the case, or if o is null, or if the current Type
        ///     is an open generic type (that is, System.Type.ContainsGenericParameters returns
        ///     true).
        //// </returns>
        public static bool IsInstanceOfType(this object anonymousObject, object ObjectToCompare)
        {
            if (anonymousObject == null) return false;
            if (ObjectToCompare == null) return false;

            try
            {
                return anonymousObject.GetType().IsInstanceOfType(ObjectToCompare);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified object is an instance of the current System.Type.
        /// </summary>
        /// <param name="anonymousObject">The source object to compare with the current type.</param>
        /// <param name="T">The object to compare with the current type.</param>
        /// <returns>
        ///     true if the current Type is in the inheritance hierarchy of the object represented
        ///     by o, or if the current Type is an interface that o supports. false if neither
        ///     of these conditions is the case, or if o is null, or if the current Type
        ///     is an open generic type (that is, System.Type.ContainsGenericParameters returns
        ///     true).
        //// </returns>
        public static bool IsInstanceOfType<T>(this object anonymousObject)
        {
            if (anonymousObject == null) return false;

            try
            {
                T typeobj = Activator.CreateInstance<T>();

                return anonymousObject.GetType().IsInstanceOfType(typeobj);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified object is an instance of the current System.Type.
        /// </summary>
        /// <param name="anonymousObject">The source object to compare with the current type.</param>
        /// <param name="FullName">The fully qualified assembly name of the type.</param>
        /// <returns>
        ///     true if the current Type is in the inheritance hierarchy of the object represented
        ///     by o, or if the current Type is an interface that o supports. false if neither
        ///     of these conditions is the case, or if o is null, or if the current Type
        ///     is an open generic type (that is, System.Type.ContainsGenericParameters returns
        ///     true).
        //// </returns>
        public static bool IsInstanceOfType(this object anonymousObject, string FullName)
        {
            if (anonymousObject == null) return false;

            try
            {
                Type tType = Type.GetType(FullName);
                object typeobj = Activator.CreateInstance(tType);

                return anonymousObject.GetType().IsInstanceOfType(typeobj);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified object is an instance of the current System.Type.
        /// </summary>
        /// <param name="anonymousObject">The source object to compare with the current type.</param>
        /// <param name="anonymousType">The object to compare with the current type.</param>
        /// <returns>
        ///     true if the current Type is in the inheritance hierarchy of the object represented
        ///     by o, or if the current Type is an interface that o supports. false if neither
        ///     of these conditions is the case, or if o is null, or if the current Type
        ///     is an open generic type (that is, System.Type.ContainsGenericParameters returns
        ///     true).
        //// </returns>
        public static bool IsInstanceOfType(this object anonymousObject, Type anonymousType)
        {
            if (anonymousObject == null) return false;
            if (anonymousType == null) return false;

            try
            {
                object objJunk = Activator.CreateInstance(anonymousType);

                return anonymousObject.GetType().IsInstanceOfType(objJunk);
            }
            catch
            {
                return false;
            }
        }
    }
}
