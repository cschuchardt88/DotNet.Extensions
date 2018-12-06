using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.IO;

namespace System.Runtime.InteropServices
{
    public static class MarshalExtensions
    {
        public static byte[] ToBytes<TSource>(this TSource anonymousObject) where TSource : struct
        {
            IntPtr iptr = Marshal.AllocHGlobal(Marshal.SizeOf<TSource>());

            byte[] TmpBuf = new byte[Marshal.SizeOf<TSource>()];

            Marshal.StructureToPtr(anonymousObject, iptr, false);
            Marshal.Copy(iptr, TmpBuf, 0, Marshal.SizeOf<TSource>());

            return TmpBuf;
        }

        public static TResult ToStructure<TResult>(this byte[] anonymousObjects) where TResult : struct
        {
            if (anonymousObjects == null) throw new NullReferenceException();
            if (anonymousObjects.Length == 0) throw new NullReferenceException();

            GCHandle gh = GCHandle.Alloc(anonymousObjects, GCHandleType.Pinned);

            TResult tnewType = Marshal.PtrToStructure(gh.AddrOfPinnedObject(), typeof(TResult)).ToTypeCast<TResult>();

            gh.Free();

            return tnewType;
        }
    }
}
