using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace TabBlazor
{
    public static class EnumHelper
    {
        public static List<TEnum> GetList<TEnum>() where TEnum : struct, Enum
        {
            if (!typeof(TEnum).IsEnum) throw new InvalidOperationException();
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToList();
        }

        public static List<TEnum?> GetNullableList<TEnum>() where TEnum : struct, Enum
        {
            return Enum.GetValues(Nullable.GetUnderlyingType(typeof(TEnum)) ?? typeof(TEnum)).Cast<TEnum?>().ToList();
        }

        public static List<SelectItem> GetEnumSelectItems<TEnum>() where TEnum : struct, Enum
        {
            return Enum.GetValues(typeof(TEnum))
                .Cast<TEnum>()
                .Select(e => new SelectItem
                {
                    Value = Convert.ToInt32(e),
                    Text = GetDisplayName(e)
                }).ToList();
        }

        private static string GetDisplayName(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var displayAttribute = fieldInfo?.GetCustomAttribute<DisplayAttribute>();
            return displayAttribute != null ? displayAttribute.Name : value.ToString();
        }

        public class SelectItem
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }
    }
}
