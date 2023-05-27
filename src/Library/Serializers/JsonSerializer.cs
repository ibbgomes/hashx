namespace Hashx.Library;

using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Defines a JSON serializer.
/// </summary>
public sealed class JsonSerializer
{
    #region Public Methods

    /// <summary>
    /// Serializes the specified object.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>The serialized object.</returns>
    public static string Serialize(object obj)
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true,
        };

        options.Converters.Add(new JsonStringEnumConverter());

        return System.Text.Json.JsonSerializer.Serialize(obj, options);
    }

    #endregion
}