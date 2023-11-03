namespace Hashx.Library;

using System;
using System.IO;
using System.Xml;

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
        ArgumentNullException.ThrowIfNull(obj);

        System.Xml.Serialization.XmlSerializer serializer = new(obj.GetType());

        using StringWriter stringWriter = new();

        using XmlWriter xmlWriter = GetXmlWriter(stringWriter);

        serializer.Serialize(xmlWriter, obj);

        return stringWriter.ToString();
    }

    #endregion

    #region Private Methods

    private static XmlWriter GetXmlWriter(TextWriter textWriter)
    {
        XmlWriterSettings settings = new()
        {
            Indent = true,
        };

        return XmlWriter.Create(textWriter, settings);
    }

    #endregion
}