using GeometryTest.Models.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GeometryTest
{
    public class FigureConverter : JsonConverter<BaseShape>
    {
        private readonly Dictionary<string, Type> _concreteTypes;
        public FigureConverter(IEnumerable<Type> concreteTypes)
        {
            _concreteTypes = new Dictionary<string, Type>();
            foreach (Type type in concreteTypes)
            {
                _concreteTypes[type.Name.ToLower()] = type;
            }
        }

        // Determines if the converter can convert the specified type
        public override bool CanConvert(Type typeToConvert) =>
            typeof(BaseShape).IsAssignableFrom(typeToConvert);

        // Reads the JSON and deserializes it into an instance of BaseShape
        public override BaseShape? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Checks that the JSON is starting with an object
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            // Reads the first token after the start of the object
            reader.Read();

            // Checks that it's a property name
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            // Reads the name of the property that specifies the type of the shape being deserialized
            string? propertyType = reader.GetString();

            // If it's null or not "type", throws an exception
            if (propertyType is null || propertyType.ToLower() != "type")
            {
                throw new JsonException();
            }

            // Reads the next token, which should be the name of the concrete type of the shape being deserialized
            reader.Read();

            // If it's not a string, throws an exception
            if (reader.TokenType != JsonTokenType.String)
            {
                throw new JsonException();
            }

            // Gets the name of the concrete type of the shape being deserialized
            string? typeName = reader.GetString();

            // If it's null or the dictionary doesn't contain the type, throws an exception
            if (typeName is null || !_concreteTypes.TryGetValue(typeName.ToLower(), out Type? concreteType))
            {
                throw new JsonException();
            }

            // Creates an instance of the concrete type of the shape being deserialized
            BaseShape? baseFigure = (BaseShape?)Activator.CreateInstance(concreteType);

            // Loops through the remaining tokens in the JSON
            while (reader.Read())
            {
                // If the end of the object is reached, returns the deserialized shape
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return baseFigure;
                }

                // If it's not a property name, throws an exception
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                // Gets the name of the property being deserialized
                string? propertyName = reader.GetString();

                // If it's not null, gets the corresponding property of the concrete type
                if (propertyName is not null)
                {
                    PropertyInfo? property = concreteType.GetProperty(propertyName);

                    // If the property doesn't exist, skips the token
                    if (property == null)
                    {
                        reader.Skip();
                    }
                    // If the property exists, deserialize its value and set it on the object using reflection
                    else
                    {
                        // Deserializes the value of the property and sets it on the deserialized shape
                        object? value = JsonSerializer.Deserialize(ref reader, property.PropertyType, options);
                        property.SetValue(baseFigure, value);
                    }
                }
            }

            // If the end of the object is never reached, throw a JSON exception
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, BaseShape value, JsonSerializerOptions options)
        {
            // Get the concrete type of the object
            Type type = value.GetType();

            // Start writing the JSON object
            writer.WriteStartObject();

            // Write the "type" property with the name of the concrete type
            writer.WriteString("type", type.Name);

            // Get the properties of the concrete type and write them to the JSON object
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                // Only write properties that are both readable and writable, and do not have any index parameters
                if (property.CanRead && property.CanWrite && property.GetIndexParameters().Length == 0)
                {
                    // Write the property name
                    writer.WritePropertyName(property.Name);

                    // Get the value of the property and serialize it
                    object? propertyValue = property.GetValue(value);
                    JsonSerializer.Serialize(writer, propertyValue, property.PropertyType, options);
                }
            }

            // End the JSON object
            writer.WriteEndObject();
        }
    }
}
