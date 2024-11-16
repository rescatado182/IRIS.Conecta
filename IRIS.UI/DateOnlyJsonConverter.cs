using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IRIS.UI
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var dateTimeString = reader.GetString();

            // Si el valor de la fecha es nulo o vacío, se maneja como valor predeterminado
            if (string.IsNullOrWhiteSpace(dateTimeString))
            {
                return DateOnly.MinValue; // O puedes devolver null si prefieres
            }

            // Intentamos analizar la cadena en formato DateTime
            if (DateTime.TryParse(dateTimeString, out DateTime dateTime))
            {
                return DateOnly.FromDateTime(dateTime); // Extraemos solo la parte de la fecha
            }

            // Si no podemos convertirla, lanzamos una excepción
            throw new JsonException($"Unable to convert \"{dateTimeString}\" to DateOnly.");
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd")); // Escribimos solo la parte de la fecha
        }
    }

}
