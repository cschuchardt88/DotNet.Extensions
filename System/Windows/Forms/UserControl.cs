using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms
{
    public static class UserControlExtensions
    {
        public static void InvokeIfRequired<TSource>(this TSource control, Action<TSource> action) where TSource : ISynchronizeInvoke
        {
            if (control.InvokeRequired)
            {
                control.TryCatch(a => a.Invoke(new Action(() => action(control)), null));
            }
            else
            {
                action(control);
            }
        }
    }
}
