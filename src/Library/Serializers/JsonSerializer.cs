namespace Hashx.Library;

using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Defines a JSON serializer.
/// </summary>
public sealed class JsonSerializer
{
    #region Fields

    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
    };

    #endregion

    #region Public Methods

    /// <summary>
    /// Serializes the specified object.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>The serialized object.</returns>
    public static string Serialize(object obj)
    {
        Options.Converters.Add(new JsonStringEnumConverter());

        return System.Text.Json.JsonSerializer.Serialize(obj, Options);
    }

    #endregion
}