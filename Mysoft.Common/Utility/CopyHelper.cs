using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mysoft.Common.Utility
{
    public class CopyHelper
    {
        public static T CopyGenericType<T>(T obj)
        {
            Type type = typeof(T);

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                T t = (T)Activator.CreateInstance(obj.GetType());
                int count = Convert.ToInt32(type.GetProperty("Count", BindingFlags.Public | BindingFlags.Instance).GetValue(obj, null));
                for (int i = 0; i < count; i++)
                {
                    object oa = type.GetProperty("Item").GetValue(obj, new object[] {i});
                    object ob = CopyClass(oa);

                    MethodInfo add = type.GetMethod("Add");
                    add.Invoke(t, new object[] {ob});
                }
                return t;
            }
            else
            {
                throw new NotSupportedException("不支持非泛型类");
            }
        }

        public static T CopyClass<T>(T obj)
        {
            Type type = obj.GetType();
            T t = (T)Activator.CreateInstance(type);

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var val = property.GetValue(obj, null);
                if(property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    //若是泛型，则拷贝一个副本
                    var newVal = CopyGenericType(val);
                    //给返回值的该成员赋值
                    property.SetValue(t, newVal, null);
                }
                else if (property.PropertyType.IsClass && property.PropertyType.FullName != null && !property.PropertyType.FullName.ToLowerInvariant().Equals("system.string"))
                {
                    //引用类型   
                    var newVal = CopyClass(val);
                    property.SetValue(t, newVal, null);
                }
                else
                {
                    //值类型
                    property.SetValue(t, val, null);
                }
            }
            
            return t;
        }
    }
}
