using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
    public static class ObjectExtensions
    {
        public static Guid GetGuid(this object anonymousObject)
        {
            if (anonymousObject == null) return Guid.Empty;

            return anonymousObject.GetType().GUID;
        }
    }
}
