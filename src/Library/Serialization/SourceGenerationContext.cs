using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hashx.Library;

/// <summary>
/// Defines the source generation context for <see cref="JsonSerializer"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[JsonSerializable(typeof(ExportableResult))]
[JsonSourceGenerationOptions(WriteIndented = true, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
public sealed partial class SourceGenerationContext : JsonSerializerContext;