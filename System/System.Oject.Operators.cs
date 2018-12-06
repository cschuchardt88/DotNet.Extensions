using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class OperatorsExtensions
    {

        ////public static ExpandoObject AddTypes(this object anonymousObject, object BindToObject)
        ////{
        ////    if (anonymousObject == null) return null;
        ////    if (BindToObject == null) return null;
        ////    //if (anonymousObject.IsInstanceOfType(BindToObject) == false) return null;

        ////    Type SrcType = anonymousObject.GetType();
        ////    Type DstType = BindToObject.GetType();

        ////    PropertyInfo[] pfSrcObjs = SrcType.GetProperties();
        ////    PropertyInfo[] pfDstObjs = DstType.GetProperties();

        ////    FieldInfo[] fiSrcObjs = SrcType.GetFields();
        ////    FieldInfo[] fiDstOobjs = DstType.GetFields();

        ////    IDictionary<string, object> MasterObject = new Dictionary<string, object>();

        ////    pfSrcObjs.TryCatch(w.ForEach(p => MasterObject.Add(p.Name, p.GetValue(anonymousObject, null))));
        ////    pfDstObjs.TryCatch(w.ForEach(p => MasterObject.Add(p.Name, p.GetValue(BindToObject, null))));
        ////    fiSrcObjs.TryCatch(w.ForEach(p => MasterObject.Add(p.Name, p.GetValue(anonymousObject))));
        ////    fiDstOobjs.TryCatch(w.ForEach(p => MasterObject.Add(p.Name, p.GetValue(BindToObject))));

        ////    return MasterObject.ToExpando();
        ////}

        //public static T AddTypes<T>(this object anonymousObject, T BindToObject)
        //{

        //    if (anonymousObject == null) return null;
        //    if (BindToObject == null) return null;
        //    //if (anonymousObject.IsInstanceOfType(BindToObject) == false) return null;

        //    Type SrcType = anonymousObject.GetType();
        //    Type DstType = typeof(T);

        //    PropertyInfo[] pfSrcObjs = SrcType.GetProperties();
        //    PropertyInfo[] pfDstObjs = DstType.GetProperties();

        //    FieldInfo[] fiSrcObjs = SrcType.GetFields();
        //    FieldInfo[] fiDstObjs = DstType.GetFields();

        //    IDictionary<string, object> MasterObject = new Dictionary<string, object>();

        //    pfSrcObjs.TryCatch(
        //        w =>
        //        {
        //            if (w.CanWrite == true)
        //                w.ForEach(p => MasterObject.Add(p.Name, p.GetValue(anonymousObject, null)));
        //        }
        //    );

        //    pfDstObjs.TryCatch(
        //        w =>
        //        {
        //            if (w.CanWrite == true)
        //                w.ForEach(p => MasterObject.Add(p.Name, p.GetValue(BindToObject, null)));
        //        }
        //    );

        //    fiSrcObjs.TryCatch(
        //        w =>
        //        {
        //            if (w.IsPrivate == false)
        //                w.ForEach(p => MasterObject.Add(p.Name, p.GetValue(anonymousObject)));
        //        }
        //    );

        //    fiDstObjs.TryCatch(
        //        w =>
        //        {
        //            if (w.IsPrivate == false)
        //                w.ForEach(p => MasterObject.Add(p.Name, p.GetValue(BindToObject)));
        //        }
        //    );

        //    return MasterObject;
        //}

        ////TODO: Complete code
        //public static object SubtractTypeFrom(this object anonymousObject, object RemoveFromType)
        //{
        //    if (anonymousObject == null) return null;
        //    if (RemoveFromType == null) return null;
        //    if (anonymousObject.IsInstanceOfType(RemoveFromType) == false) return null;

        //    Type SrcType = anonymousObject.GetType();
        //    Type DstType = RemoveFromType.GetType();

        //    PropertyInfo[] pfSrcObjs = SrcType.GetProperties();
        //    PropertyInfo[] pfDstObjs = DstType.GetProperties();

        //    FieldInfo[] fiSrcObjs = SrcType.GetFields();
        //    FieldInfo[] fiDstOobjs = DstType.GetFields();

        //    IDictionary<string, object> MasterObject = new Dictionary<string, object>();

        //    pfDstObjs.TryCatch(w.ForEach(p => pfSrcObjs.Where(i => i.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) == false).ForEach(i => MasterObject.Add(i.Name, i.GetValue(RemoveFromType, null)))));
        //    fiDstOobjs.TryCatch(w.ForEach(p => fiSrcObjs.Where(i => i.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) == false).Select(i => MasterObject.Add(i.Name, i.GetValue(RemoveFromType)))));

        //    return MasterObject.ToExpando();
        //    //return null;
        //}

        //public static object SubtractTypeFrom<TBind>(this object anonymousObject, TBind RemoveFromType)
        //{
        //    if (anonymousObject == null) return null;
        //    if (RemoveFromType == null) return null;
        //    if (anonymousObject.IsInstanceOfType(RemoveFromType) == false) return null;

        //    Type SrcType = anonymousObject.GetType();
        //    Type DstType = RemoveFromType.GetType();

        //    PropertyInfo[] pfSrcObjs = SrcType.GetProperties();
        //    PropertyInfo[] pfDstObjs = DstType.GetProperties();

        //    FieldInfo[] fiSrcObjs = SrcType.GetFields();
        //    FieldInfo[] fiDstOobjs = DstType.GetFields();

        //    IDictionary<string, object> MasterObject = new Dictionary<string, object>();

        //    pfDstObjs.ForEach(p => pfSrcObjs.Where(i => i.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) == false).ForEach(i => MasterObject.Add(i.Name, i.GetValue(RemoveFromType, null))););
        //    fiDstOobjs.ForEach(p => fiSrcObjs.Where(i => i.Name.Equals(p.Name, StringComparison.OrdinalIgnoreCase) == false).Select(i => MasterObject.Add(i.Name, i.GetValue(RemoveFromType))));

        //    return MasterObject.ToExpando();
        //    //return null;
        //}

        // c_tor(); // override? no more NULL Refs exceptions

        // TODO: in the future... Add this to .NET Framework
        //public static explicit operator +<TSource>(this TSource someObj)
        //{
        //}

        //public static explicit operator -<TSource>(this TSource someObj)
        //{
        //}

        //public static explicit operator =<TSource>(this TSource someObj)
        //{
        //}

        //public static T SubtractTypeFrom<TSource, T>(this TSource anonymousObject, T RemoveFromType)
        //{

        //}
    }
}
