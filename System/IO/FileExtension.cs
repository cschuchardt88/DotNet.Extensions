using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace System.IO
{
    public static class FileEx
    {
        /// <summary>
        /// Deletes destFileName if exists, before moving from sourceFileName
        /// </summary>
        /// <param name="sourceFileName"></param>
        /// <param name="desFileName"></param>
        public static void MoveDelete(string sourceFileName, string desFileName)
        {
            if (String.IsNullOrEmpty(sourceFileName)) throw new NullReferenceException("sourceFileName");
            if (String.IsNullOrEmpty(desFileName)) throw new NullReferenceException("desFileName");
            if (File.Exists(sourceFileName) == false) throw new FileNotFoundException(sourceFileName);

            if (File.Exists(desFileName))
                File.Delete(desFileName);

            System.Threading.Thread.Sleep(10); // give alittle time for .NET to release file access before moving it

            try { File.Move(sourceFileName, desFileName); }
            catch { throw; }
        }
    }
}
