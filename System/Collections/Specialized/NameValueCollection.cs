using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections.Specialized;
using System.Collections;

namespace System.Collections.Specialized
{
    public static class NameValueCollectionExtension
    {
        /// <summary>
        /// Adds to FormCollection.Get, for getting same Key name, when using an expresion.
        /// EX: @Html.HiddenFor(model => model.Id)
        ///     int? id = FormCollection.Get(model => model.Id)
        ///     The above would return the value for hidden form data.
        /// </summary>
        /// <typeparam name="TModel">The type of the members of values.</typeparam>
        /// <param name="NameColObj">The collection</param>
        /// <param name="expression">Expression to lookup</param>
        /// <returns>value of the expression data.</returns>
        public static string Get<TModel>(this NameValueCollection NameColObj, Expression<Func<TModel, object>> expression)
        {
            if (NameColObj == null) return String.Empty;
            string strLookup = String.Empty;

            if (expression.TryCatchThrow(e => e.Body.IsInstanceOfType<MemberExpression>()) == true)
                strLookup = expression.TryCatchThrow(e => e.Body.ToTypeCast<MemberExpression>().Member.Name);
            else
                strLookup = expression.TryCatchThrow(e => e.Body.ToTypeCast<UnaryExpression>().Operand.ToTypeCast<MemberExpression>().Member.Name);

            return NameColObj.TryCatchThrow(n => n.Get(strLookup));
        }
    }
}
