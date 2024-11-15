using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace IRIS.UI
{
    public static class EnumExtensions
    {

        public static List<EnumItem<T>> GetList<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .Cast<T>()
                .Select(e => new EnumItem<T>
                {
                    Value = e,
                    DisplayName = GetDisplayName(e)
                })
                .ToList();
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            var displayAttribute = enumValue.GetType()
                .GetField(enumValue.ToString())
                ?.GetCustomAttributes(typeof(DisplayAttribute), false)
                .Cast<DisplayAttribute>()
                .FirstOrDefault();

            return displayAttribute?.Name ?? enumValue.ToString();
        }

        public static string GetDisplayNameStatus(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = field?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name ?? value.ToString();
        }

        public static string GetDisplayName<T>(T enumValue) where T : Enum
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            var attribute = field.GetCustomAttributes(typeof(DisplayAttribute), false)
                                 .Cast<DisplayAttribute>()
                                 .SingleOrDefault();
            return attribute?.Name ?? enumValue.ToString(); // Devolver el nombre para mostrar
        }

        public class EnumItem<T>
        {
            public T Value { get; set; }
            public string DisplayName { get; set; }
        }
    }
}
