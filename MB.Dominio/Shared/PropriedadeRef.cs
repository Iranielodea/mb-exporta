using System;
using System.Reflection;

namespace MB.Dominio.Shared
{
    public class PropriedadeRef
    {
        public void GetPropertyValues(Object obj)
        {
            Type t = obj.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (var prop in props)
            {
                if (prop.PropertyType.Name == "String" && prop.GetValue(obj) == null)
                    prop.SetValue(obj, "");
            }
        }
    }
}
