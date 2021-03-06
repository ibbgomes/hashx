namespace Hashx.Library.Serializers
{
    using System;
    using System.IO;

    /// <summary>
    /// Defines a XML serializer.
    /// </summary>
    public sealed class XmlSerializer
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

            System.Xml.Serialization.XmlSerializer serializer = new (obj.GetType());

            using StringWriter writer = new ();

            serializer.Serialize(writer, obj);

            return writer.ToString();
        }

        #endregion
    }
}