using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System.Binding
{
    public enum ClassBinding
    {
        Properties,
        Fields,
        PropertiesToFields,
        FieldsToProperties,
        Both,
        All
    }

    public static class SystemObjectBindingExtenions
    {
        /// <summary>
        /// Sets values from one class object to another one of a different type. Only with the same Class "Properties" or "Fields" names.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="anonymousObject"></param>
        /// <param name="anonymouseObjectToBind"></param>
        /// <param name="IgnoreCase"></param>
        /// <param name="WhichBinding"></param>
        /// <returns></returns>
        public static TResult ToType<TSource, TResult>(this TSource anonymousObject, TResult anonymouseObjectToBind, bool IgnoreCase = true, ClassBinding WhichBinding = ClassBinding.Both) where TSource: class where TResult: class
        {
            if (anonymousObject == null) throw new ArgumentNullException("TSource object is null");
            if (anonymouseObjectToBind == null) throw new ArgumentNullException("TResult object is null");

            switch(WhichBinding)
            {
                case ClassBinding.Properties:
                    anonymouseObjectToBind = CopyProperties(anonymousObject, anonymouseObjectToBind).ToTypeCast<TResult>();
                    break;
                case ClassBinding.Fields:
                    anonymouseObjectToBind = CopyFields(anonymousObject, anonymouseObjectToBind).ToTypeCast<TResult>();
                    break;
                case ClassBinding.Both:
            CopyALL:
                    anonymouseObjectToBind = CopyProperties(anonymousObject, anonymouseObjectToBind).ToTypeCast<TResult>();
                    anonymouseObjectToBind = CopyFields(anonymousObject, anonymouseObjectToBind).ToTypeCast<TResult>();
                    break;
                case ClassBinding.PropertiesToFields:
                    anonymouseObjectToBind = CopyPropertiesToFields(anonymousObject, anonymouseObjectToBind).ToTypeCast<TResult>();
                    break;
                case ClassBinding.FieldsToProperties:
                    anonymouseObjectToBind = CopyFieldsToProperties(anonymousObject, anonymouseObjectToBind).ToTypeCast<TResult>();
                    break;
                case ClassBinding.All:
                    anonymouseObjectToBind = CopyPropertiesToFields(anonymousObject, anonymouseObjectToBind).ToTypeCast<TResult>();
                    anonymouseObjectToBind = CopyFieldsToProperties(anonymousObject, anonymouseObjectToBind).ToTypeCast<TResult>();
                    goto CopyALL;
                default:
                    anonymouseObjectToBind = CopyProperties(anonymousObject, anonymouseObjectToBind).ToTypeCast<TResult>();
                    anonymouseObjectToBind = CopyFields(anonymousObject, anonymouseObjectToBind).ToTypeCast<TResult>();
                    break;
            }

            return anonymouseObjectToBind;
        }

        internal static object CopyFieldsToProperties<TSource>(this TSource anonymousObject, object anonymouseObjectToBind, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException();
            if (anonymouseObjectToBind == null) throw new ArgumentNullException();

            Type tsObjectType = anonymousObject.GetType();
            Type tbObjectType = anonymouseObjectToBind.GetType();

            FieldInfo[] fiSrcObject = tsObjectType.GetFields();
            PropertyInfo[] pfDstObject = tbObjectType.GetProperties();

            //if (fiSrcObject == null) throw new NullReferenceException();
            //if (pfDstObject == null) throw new NullReferenceException();
            //if (fiSrcObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} doesnt not have any fields.", tsObjectType.ToString()));
            //if (pfDstObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} doesnt not have any properties.", tbObjectType.ToString()));

            fiSrcObject.TryCatch(
                pd =>
                {
                    pd.ForEach(
                        d =>
                        {
                            var s = pfDstObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(d.Name, StringComparison.OrdinalIgnoreCase) : p.Name.Equals(d.Name)) == true &&
                                        p.CanWrite == true &&
                                        p.MemberType == MemberTypes.Property
                            ).FirstOrDefault();

                            if (s != null)
                            {
                                try { s.SetValue(anonymouseObjectToBind, Convert.ChangeType(d.GetValue(anonymousObject), s.PropertyType)); }
                                catch
                                {
                                    // Polymorphism needs to be fixed for Structures and Classes (Disabled for now)
                                    //try { d.SetValue(anonymouseObjectToBind, CopyFields(s.GetValue(anonymousObject), d.GetValue(anonymouseObjectToBind), d.FieldType)); }
                                    //catch { }
                                }
                            }
                        });
                });

            return anonymouseObjectToBind;
        }

        internal static object CopyPropertiesToFields<TSource>(this TSource anonymousObject, object anonymouseObjectToBind, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException();
            if (anonymouseObjectToBind == null) throw new ArgumentNullException();

            Type tsObjectType = anonymousObject.GetType();
            Type tbObjectType = anonymouseObjectToBind.GetType();

            PropertyInfo[] pfSrcObject = tsObjectType.GetProperties();
            FieldInfo[] fiDstObject = tbObjectType.GetFields();

            //if (pfSrcObject == null) throw new NullReferenceException();
            //if (fiDstObject == null) throw new NullReferenceException();
            //if (pfSrcObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any properties.", tsObjectType.ToString()));
            //if (fiDstObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any fields.", tbObjectType.ToString()));

            pfSrcObject.TryCatch(
                pd =>
                {
                    pd.ForEach(
                        d =>
                        {
                            var s = fiDstObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(d.Name, StringComparison.OrdinalIgnoreCase) : p.Name.Equals(d.Name)) == true &&
                                        p.IsPrivate == false &&
                                        p.MemberType == MemberTypes.Field
                            ).FirstOrDefault();

                            if (s != null)
                            {
                                try { s.SetValue(anonymouseObjectToBind, Convert.ChangeType(d.GetValue(anonymousObject), s.FieldType)); }
                                catch
                                {
                                    // Polymorphism needs to be fixed for Structures and Classes (Disabled for now)
                                    //try { d.SetValue(anonymouseObjectToBind, CopyFields(s.GetValue(anonymousObject), d.GetValue(anonymouseObjectToBind), d.FieldType)); }
                                    //catch { }
                                }
                            }
                        });
                });

            return anonymouseObjectToBind;
        }

        /// <summary>
        /// Sets values from one class object to another one of a different type. Allows a mapping profile for different class types of same Property or Field data types.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="anonymousObject"></param>
        /// <param name="anonymouseObjectToBind"></param>
        /// <param name="BindingMap"></param>
        /// <param name="IgnoreCase"></param>
        /// <param name="WhichBinding"></param>
        /// <returns></returns>
        public static TResult ToType<TSource, TResult>(this TSource anonymousObject, TResult anonymouseObjectToBind, ClassBindingMap BindingMap, ClassBinding WhichBinding = ClassBinding.All, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException("TSource object is null");
            if (anonymouseObjectToBind == null) throw new ArgumentNullException("TBind object is null");
            if (BindingMap == null) throw new ArgumentNullException("Class binding map is null");

            switch(WhichBinding)
            {
                case ClassBinding.Properties:
                    anonymouseObjectToBind = CopyProperties(anonymousObject, anonymouseObjectToBind, BindingMap.PropertiesMapping, IgnoreCase).ToTypeCast<TResult>();
                    break;
                case ClassBinding.Fields:
                    anonymouseObjectToBind = CopyFields(anonymousObject, anonymouseObjectToBind, BindingMap.VariableMapping, IgnoreCase).ToTypeCast<TResult>();
                    break;
                case ClassBinding.Both:
            ClassBindingBoth:
                    anonymouseObjectToBind = CopyProperties(anonymousObject, anonymouseObjectToBind, BindingMap.PropertiesMapping, IgnoreCase).ToTypeCast<TResult>();
                    anonymouseObjectToBind = CopyFields(anonymousObject, anonymouseObjectToBind, BindingMap.VariableMapping, IgnoreCase).ToTypeCast<TResult>();
                    break;
                case ClassBinding.FieldsToProperties:
                    anonymouseObjectToBind = CopyFieldsToProperties(anonymousObject, anonymouseObjectToBind, BindingMap.PropertiesMapping, IgnoreCase).ToTypeCast<TResult>();
                    break;
                case ClassBinding.PropertiesToFields:
                    anonymouseObjectToBind = CopyPropertiesToFields(anonymousObject, anonymouseObjectToBind, BindingMap.VariableMapping, IgnoreCase).ToTypeCast<TResult>();
                    break;
                case ClassBinding.All:
                    anonymouseObjectToBind = CopyPropertiesToFields(anonymousObject, anonymouseObjectToBind, BindingMap.PropertiesMapping, IgnoreCase).ToTypeCast<TResult>();
                    anonymouseObjectToBind = CopyFieldsToProperties(anonymousObject, anonymouseObjectToBind, BindingMap.VariableMapping, IgnoreCase).ToTypeCast<TResult>();
                    goto ClassBindingBoth;
            }

            return anonymouseObjectToBind;
        }

        internal static object CopyPropertiesToFields(this object anonymousObject, object anonymouseObjectToBind, IDictionary<string, string> VarMapping, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException();
            if (anonymouseObjectToBind == null) throw new ArgumentNullException();
            if (VarMapping == null) throw new ArgumentNullException();
            if (VarMapping.Count == 0) throw new ArgumentOutOfRangeException();

            Type tsObjectType = anonymousObject.GetType();
            Type tbObjectType = anonymouseObjectToBind.GetType();

            PropertyInfo[] pfSrcObject = tsObjectType.GetProperties();
            FieldInfo[] fiDstObject = tbObjectType.GetFields();

            //if (pfSrcObject == null) throw new NullReferenceException();
            //if (fiDstObject == null) throw new NullReferenceException();
            //if (pfSrcObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} does not have any properties.", tsObjectType.ToString()));
            //if (fiDstObject.Length == 0) throw new MissingFieldException(String.Format("Object {0} does not have any fields.", tbObjectType.ToString()));

            VarMapping.TryCatch(
                kp =>
                {
                    kp.ForEach(
                        kpn =>
                        {
                            var s = pfSrcObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(kpn.Key, StringComparison.OrdinalIgnoreCase) == true : p.Name.Equals(kpn.Key) == true) &&
                                        p.CanWrite == true &&
                                        p.MemberType == MemberTypes.Property
                            ).FirstOrDefault();

                            var d = fiDstObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(kpn.Value, StringComparison.OrdinalIgnoreCase) == true : p.Name.Equals(kpn.Value) == true) &&
                                        p.IsPrivate == false &&
                                        p.MemberType == MemberTypes.Field
                            ).FirstOrDefault();

                            if (d == null) throw new KeyNotFoundException(kpn.Key);

                            d.SetValue(anonymouseObjectToBind, Convert.ChangeType(s.GetValue(anonymousObject), d.FieldType));
                        });
                });

            return anonymouseObjectToBind;
        }

        internal static object CopyFieldsToProperties(this object anonymousObject, object anonymouseObjectToBind, IDictionary<string, string> VarMapping, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException();
            if (anonymouseObjectToBind == null) throw new ArgumentNullException();
            if (VarMapping == null) throw new ArgumentNullException();
            if (VarMapping.Count == 0) throw new ArgumentOutOfRangeException();

            Type tsObjectType = anonymousObject.GetType();
            Type tbObjectType = anonymouseObjectToBind.GetType();

            FieldInfo[] fiSrcObject = tsObjectType.GetFields();
            PropertyInfo[] pfDstObject = tbObjectType.GetProperties();

            //if (fiSrcObject == null) throw new NullReferenceException();
            //if (pfDstObject == null) throw new NullReferenceException();
            //if (fiSrcObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} does not have any fields.", tsObjectType.ToString()));
            //if (pfDstObject.Length == 0) throw new MissingFieldException(String.Format("Object {0} does not have any properties.", tbObjectType.ToString()));

            VarMapping.TryCatch(
                kp =>
                {
                    kp.ForEach(
                        kpn =>
                        {
                            var s = fiSrcObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(kpn.Key, StringComparison.OrdinalIgnoreCase) == true : p.Name.Equals(kpn.Key) == true) &&
                                        p.IsPrivate == false &&
                                        p.MemberType == MemberTypes.Field
                            ).FirstOrDefault();

                            var d = pfDstObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(kpn.Value, StringComparison.OrdinalIgnoreCase) == true : p.Name.Equals(kpn.Value) == true) &&
                                        p.CanWrite == true &&
                                        p.MemberType == MemberTypes.Property
                            ).FirstOrDefault();

                            if (d == null) throw new KeyNotFoundException(kpn.Key);
                            
                            d.SetValue(anonymouseObjectToBind, Convert.ChangeType(s.GetValue(anonymousObject), d.PropertyType));
                        });
                });

            return anonymouseObjectToBind;
        }


        internal static object CopyFields(this object anonymousObject, object anonymouseObjectToBind, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException();
            if (anonymouseObjectToBind == null) throw new ArgumentNullException();

            Type tsObjectType = anonymousObject.GetType();
            Type tbObjectType = anonymouseObjectToBind.GetType();

            FieldInfo[] fiSrcObject = tsObjectType.GetFields();
            FieldInfo[] fiDstObject = tbObjectType.GetFields();

            //if (fiSrcObject == null) throw new NullReferenceException();
            //if (fiDstObject == null) throw new NullReferenceException();
            //if (fiSrcObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any fields.", tsObjectType.ToString()));
            //if (fiDstObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any fields.", tbObjectType.ToString()));

            fiDstObject.TryCatch(
                pd =>
                {
                    pd.ForEach(
                        d =>
                        {
                            var s = fiSrcObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(d.Name, StringComparison.OrdinalIgnoreCase) : p.Name.Equals(d.Name)) == true &&
                                        p.IsPrivate == false &&
                                        p.MemberType == MemberTypes.Field
                            ).FirstOrDefault();

                            if (s != null)
                            {
                                try { d.SetValue(anonymouseObjectToBind, Convert.ChangeType(s.GetValue(anonymousObject), d.FieldType)); }
                                catch
                                {
                                    // Polymorphism needs to be fixed for Structures and Classes (Disabled for now)
                                    //try { d.SetValue(anonymouseObjectToBind, CopyFields(s.GetValue(anonymousObject), d.GetValue(anonymouseObjectToBind), d.FieldType)); }
                                    //catch { }
                                }
                            }
                        });
            });

            return anonymouseObjectToBind;
        }

        /// <summary>
        /// for Polymorphism creation of classes and structures. UnStable
        /// </summary>
        /// <param name="anonymousObject"></param>
        /// <param name="anonymouseObjectToBind"></param>
        /// <param name="BindFieldType"></param>
        /// <param name="IgnoreCase"></param>
        /// <returns></returns>
        /// TODO: fix the Polymorphism of Classes->Classes->Classes etc
        internal static object CopyFields(this object anonymousObject, object anonymouseObjectToBind, Type BindFieldType, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException();
            if (BindFieldType == null) return anonymousObject;

            if (anonymouseObjectToBind == null)
                anonymouseObjectToBind = GenericType.Create(BindFieldType);

            Type tsObjectType = anonymousObject.GetType();
            Type tbObjectType = anonymouseObjectToBind.GetType();

            FieldInfo[] fiSrcObject = tsObjectType.GetFields();
            FieldInfo[] fiDstObject = tbObjectType.GetFields();

            //if (fiSrcObject == null) throw new NullReferenceException();
            //if (fiDstObject == null) throw new NullReferenceException();
            //if (fiSrcObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any fields.", tsObjectType.ToString()));
            //if (fiDstObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any fields.", tbObjectType.ToString()));

            fiDstObject.TryCatch(
                pd =>
                {
                    pd.ForEach(
                        d =>
                        {
                            var s = fiSrcObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(d.Name, StringComparison.OrdinalIgnoreCase) : p.Name.Equals(d.Name)) == true &&
                                        p.IsPrivate == false &&
                                        p.MemberType == MemberTypes.Field
                            ).FirstOrDefault();

                            if (s != null)
                            {
                                //So it does not break out of the for each loop
                                d.TryCatch(
                                    p => p.SetValue(anonymouseObjectToBind, Convert.ChangeType(s.GetValue(anonymousObject), d.FieldType)),
                                    p => p.SetValue(anonymouseObjectToBind, CopyFields(s.GetValue(anonymousObject), d.GetValue(anonymouseObjectToBind), d.FieldType))
                                );
                            }
                        });
                });

            return anonymouseObjectToBind;
        }

        internal static object CopyFields(this object anonymousObject, object anonymouseObjectToBind, IDictionary<string, string> VarMapping, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException();
            if (anonymouseObjectToBind == null) throw new ArgumentNullException();
            if (VarMapping == null) throw new ArgumentNullException();
            if (VarMapping.Count == 0) throw new ArgumentOutOfRangeException();

            Type tsObjectType = anonymousObject.GetType();
            Type tbObjectType = anonymouseObjectToBind.GetType();

            FieldInfo[] fiSrcObject = tsObjectType.GetFields();
            FieldInfo[] fiDstObject = tbObjectType.GetFields();

            //if (fiSrcObject == null) throw new NullReferenceException();
            //if (fiDstObject == null) throw new NullReferenceException();
            //if (fiSrcObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any fields.", tsObjectType.ToString()));
            //if (fiDstObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any fields.", tbObjectType.ToString()));

            VarMapping.TryCatchThrow(
                kp =>
                {
                    kp.ForEach(
                        kpn =>
                        {
                            var s = fiSrcObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(kpn.Key, StringComparison.OrdinalIgnoreCase) == true : p.Name.Equals(kpn.Key) == true) &&
                                        p.IsPrivate == false &&
                                        p.MemberType == MemberTypes.Field
                            ).FirstOrDefault();

                            var d = fiDstObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(kpn.Value, StringComparison.OrdinalIgnoreCase) == true : p.Name.Equals(kpn.Value) == true) &&
                                        p.IsPrivate == false &&
                                        p.MemberType == MemberTypes.Field
                            ).FirstOrDefault();

                            if (d == null) throw new KeyNotFoundException(kpn.Key);

                            if (s != null)
                            {
                                //So it does not break out of the for each loop
                                d.TryCatch(p => p.SetValue(anonymouseObjectToBind, Convert.ChangeType(s.GetValue(anonymousObject), d.FieldType)));
                            }
                        });
                });

            return anonymouseObjectToBind;
        }

        internal static object CopyProperties(this object anonymousObject, object anonymouseObjectToBind, IDictionary<string, string> VarMapping, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException();
            if (anonymouseObjectToBind == null) throw new ArgumentNullException();
            if (VarMapping == null) throw new ArgumentNullException();
            if (VarMapping.Count == 0) throw new ArgumentOutOfRangeException();

            Type tsObjectType = anonymousObject.GetType();
            Type tbObjectType = anonymouseObjectToBind.GetType();

            PropertyInfo[] pfSrcObject = tsObjectType.GetProperties();
            PropertyInfo[] pfDstObject = tbObjectType.GetProperties();

            //if (pfSrcObject == null) throw new NullReferenceException();
            //if (pfDstObject == null) throw new NullReferenceException();
            //if (pfSrcObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any properties.", tsObjectType.ToString()));
            //if (pfDstObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any properties.", tbObjectType.ToString()));

            VarMapping.TryCatchThrow(
                kp =>
                {
                    kp.ForEach(
                        kpn =>
                        {
                            var s = pfSrcObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(kpn.Key, StringComparison.OrdinalIgnoreCase) == true : p.Name.Equals(kpn.Key) == true) &&
                                        p.CanWrite == true &&
                                        p.MemberType == MemberTypes.Property
                            ).FirstOrDefault();

                            var d = pfDstObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(kpn.Value, StringComparison.OrdinalIgnoreCase) == true : p.Name.Equals(kpn.Value) == true) &&
                                        p.CanWrite == true &&
                                        p.MemberType == MemberTypes.Property
                            ).FirstOrDefault();

                            if (d == null) throw new KeyNotFoundException(kpn.Key);

                            if (s != null)
                            {
                                //So it does not break out of the for each loop
                                d.TryCatch(p => p.SetValue(anonymouseObjectToBind, Convert.ChangeType(s.GetValue(anonymousObject, null), p.PropertyType)));
                            }
                        });
                });

            return anonymouseObjectToBind;
        }

        internal static object CopyProperties(this object anonymousObject, object anonymouseObjectToBind, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException("TSource object is null");
            if (anonymouseObjectToBind == null) throw new ArgumentNullException("TBind object is null");

            Type tsObjectType = anonymousObject.GetType();
            Type tbObjectType = anonymouseObjectToBind.GetType();

            PropertyInfo[] pfSrcObject = tsObjectType.GetProperties();
            PropertyInfo[] pfDstObject = tbObjectType.GetProperties();

            //if (pfSrcObject == null) throw new NullReferenceException();
            //if (pfDstObject == null) throw new NullReferenceException();
            //if (pfSrcObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any properties.", tsObjectType.ToString()));
            //if (pfDstObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any properties.", tbObjectType.ToString()));

             pfDstObject.TryCatch(
                pd =>
                {
                    pd.ForEach(
                        d =>
                        {
                            var s = pfSrcObject.Where(
                                    p =>
                                        (IgnoreCase == true ? p.Name.Equals(d.Name, StringComparison.OrdinalIgnoreCase) : p.Name.Equals(d.Name)) == true &&
                                        p.CanWrite == true &&
                                        p.MemberType == MemberTypes.Property
                            ).FirstOrDefault();

                            if (s != null)
                            {
                                try { d.SetValue(anonymouseObjectToBind, Convert.ChangeType(s.GetValue(anonymousObject, null), d.PropertyType)); }
                                catch
                                {
                                    // Polymorphism needs to be fixed for Structures and Classes (Disabled for now)
                                    //try { d.SetValue(anonymouseObjectToBind, CopyProperties(s.GetValue(anonymousObject, null), d.GetValue(anonymouseObjectToBind, null), d.PropertyType)); }
                                    //catch { }
                                }
                            }
                    });
            });

             return anonymouseObjectToBind;
        }

        internal static object CopyProperties(this object anonymousObject, object anonymouseObjectToBind, Type BindObjectCastType, bool IgnoreCase = true)
        {
            if (anonymousObject == null) throw new ArgumentNullException("TSource object is null");
            if (BindObjectCastType == null) return anonymousObject;

            if (anonymouseObjectToBind == null)
                anonymouseObjectToBind = GenericType.Create(BindObjectCastType);

            Type tsObjectType = anonymousObject.GetType();
            Type tbObjectType = anonymouseObjectToBind.GetType();

            PropertyInfo[] pfSrcObject = tsObjectType.GetProperties();
            PropertyInfo[] pfDstObject = tbObjectType.GetProperties();

            //if (pfSrcObject == null) throw new NullReferenceException();
            //if (pfDstObject == null) throw new NullReferenceException();
            //if (pfSrcObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any properties.", tsObjectType.ToString()));
            //if (pfDstObject.Length == 0) throw new MissingMemberException(String.Format("Object {0} is doesnt not have any properties.", tbObjectType.ToString()));

            pfDstObject.TryCatch(
               pd =>
               {
                   pd.ForEach(
                       d =>
                       {
                           var s = pfSrcObject.Where(
                                   p =>
                                       (IgnoreCase == true ? p.Name.Equals(d.Name, StringComparison.OrdinalIgnoreCase) : p.Name.Equals(d.Name)) == true &&
                                       p.CanWrite == true &&
                                       p.MemberType == MemberTypes.Property
                           ).FirstOrDefault();

                           if (s != null)
                           {
                               d.TryCatch(
                                   p => p.SetValue(anonymouseObjectToBind, Convert.ChangeType(s.GetValue(anonymousObject, null), p.PropertyType)),
                                   p => p.SetValue(anonymouseObjectToBind, CopyProperties(s.GetValue(anonymousObject, null), p.GetValue(anonymouseObjectToBind, null), p.PropertyType))
                                );
                           }
                       });
               });

            return anonymouseObjectToBind;
        }
    }
}
