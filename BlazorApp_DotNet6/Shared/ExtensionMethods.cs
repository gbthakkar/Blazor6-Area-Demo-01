using System.Reflection;

namespace BlazorApp_DotNet6.Shared;

public static class ExtensionMethods
{
    public static T TrimStringFields<T>(this T obj) where T : class
    {
        foreach (var prop in obj.GetType().GetFields(
                     BindingFlags.Instance | BindingFlags.Public))
        {
            if (prop.FieldType == typeof(string))
            {
                var propertyValue = prop.GetValue(obj);
                if (propertyValue == null)
                {
                    prop.SetValue(obj, "");
                }
                else
                {
                    prop.SetValue(obj, prop.GetValue(obj)?.ToString()?.Trim());
                }
            }
        }
        foreach (var prop in obj.GetType().GetProperties(
                     BindingFlags.Instance | BindingFlags.Public))
        {
            if (prop.PropertyType == typeof(string))
            {
                var propertyValue = prop.GetValue(obj);
                if (propertyValue == null)
                {
                    prop.SetValue(obj, "");
                }
                else
                {
                    prop.SetValue(obj, prop.GetValue(obj)?.ToString()?.Trim());
                }
            }
        }

        return obj;
    }
}
