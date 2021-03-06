namespace Hashx.Library.Serializers
{
    using System;
    using System.Text.Json;

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
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            JsonSerializerOptions options = new ()
            {
                WriteIndented = true,
            };

            return System.Text.Json.JsonSerializer.Serialize(obj, options);
        }

        #endregion
    }
}