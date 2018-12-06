using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Binding
{
    public sealed class ClassBindingMap :  IDisposable
    {
        public IDictionary<string, string> VariableMapping { get; internal set; }
        public IDictionary<string, string> PropertiesMapping { get; internal set; }

        public ClassBindingMap(IDictionary<string, string> ClassListMap, ClassBinding WhichBinding = ClassBinding.Properties)
        {
            if (ClassListMap == null) throw new ArgumentNullException();
            if (ClassListMap.Count == 0) throw new IndexOutOfRangeException();

            switch(WhichBinding)
            {
                case ClassBinding.Properties:
                    PropertiesMapping = ClassListMap;
                    break;
                case ClassBinding.Fields:
                    VariableMapping = ClassListMap;
                    break;
                case ClassBinding.All:
                    PropertiesMapping = ClassListMap;
                    VariableMapping = ClassListMap;
                    break;
                default:
                    throw new NotImplementedException("ClassBinding enum is not known.");
            }
        }

        public ClassBindingMap(IDictionary<string, string> ClassPropertiesList, IDictionary<string, string> ClassVariableList)
        {
            if (ClassPropertiesList == null) throw new ArgumentNullException();
            if (ClassPropertiesList.Count == 0) throw new IndexOutOfRangeException();
            if (ClassVariableList == null) throw new ArgumentNullException();
            if (ClassVariableList.Count == 0) throw new IndexOutOfRangeException();

            PropertiesMapping = ClassPropertiesList;
            VariableMapping = ClassVariableList;
        }

        public void Dispose()
        {
            VariableMapping.TryCatch(p => p.Clear());
            PropertiesMapping.TryCatch(p => p.Clear());

            VariableMapping = null;
            PropertiesMapping = null;
        }
    }
}
