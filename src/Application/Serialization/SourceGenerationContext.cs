namespace Hashx.Application;

using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

/// <summary>
/// Defines the source generation context for <see cref="JsonSerializer"/>.
/// </summary>
[ExcludeFromCodeCoverage]
[JsonSerializable(typeof(HashingReport))]
internal sealed partial class SourceGenerationContext : JsonSerializerContext;