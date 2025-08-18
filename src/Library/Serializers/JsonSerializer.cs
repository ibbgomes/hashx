namespace Hashx.Library;

using System.Text.Json;

/// <summary>
/// Defines a JSON serializer.
/// </summary>
public static class JsonSerializer
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    /// <summary>
    /// Serializes the specified object.
    /// </summary>
    /// <param name="obj">The object.</param>
    /// <returns>The serialized object.</returns>
    public static string Serialize(object obj) => System.Text.Json.JsonSerializer.Serialize(obj, Options);
}