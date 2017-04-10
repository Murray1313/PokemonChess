using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

namespace Entities
{
  [AttributeUsage(AttributeTargets.Property)]
  public class SkipSerialize : Attribute { }

  [Serializable]
  public abstract class SettingsBase : IXmlSerializable
  {
    #region " Properties "
    [SkipSerialize]
    private BindingFlags GetBindings
    {
      get { return BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance; }
    }
    #endregion

    #region " Public Methods "

    /// <summary>
    /// Load the settings from the XML file into the current object. This method will suppress any exceptions that occur while reading the Xml.
    /// </summary>
    /// <param name="filePath">The path of the XML file being deserialized.</param>
    /// <remarks>This will overwrite the current properties of the current object.</remarks>
    public void LoadSettings(string filePath)
    {
      LoadSettings(filePath, true);
    }

    /// <summary>
    /// Load the settings from a stream into the current object. This method will suppress any exceptions that occur while reading the Stream.
    /// </summary>
    /// <param name="stream">A stream containing the settings values.</param>
    /// <remarks>This will overwrite the current properties of the current object.</remarks>
    public void LoadSettings(System.IO.Stream stream)
    {
      LoadSettings(stream, true);
    }

    /// <summary>
    /// Load the settings from the XML file into the current object.
    /// </summary>
    /// <param name="filePath">The path of the XML file being deserialized.</param>
    /// <param name="suppressException">Indicates whether the code should suppress any exceptions that occur while reading the Xml.</param>
    /// <remarks>This will overwrite the current properties of the current object.</remarks>
    public void LoadSettings(string filePath, bool suppressException)
    {
      try
      {
        using (System.IO.FileStream oFileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Open))
        {
          LoadSettings(oFileStream, suppressException);
        }
      }
      catch (Exception)
      {
        if (!suppressException) { throw; }
        // Otherwise... nom nom
      }
    }

    /// <summary>
    /// Load the settings from a stream into the current object.
    /// </summary>
    /// <param name="stream">A stream containing the settings values.</param>
    /// <param name="suppressException">Indicates whether the code should suppress any exceptions that occur while reading the Stream.</param>
    /// <remarks>This will overwrite the current properties of the current object.</remarks>
    public void LoadSettings(System.IO.Stream stream, bool suppressException)
    {
      try
      {
        System.Xml.XmlReader oXMLReader = System.Xml.XmlReader.Create(stream);
        ReadXml(oXMLReader);
      }
      catch (Exception)
      {
        if (!suppressException) { throw; }
        // Otherwise... nom nom
      }
    }

    /// <summary>
    /// Save the settings to the XML file from its current object.
    /// </summary>
    /// <param name="filePath">The path of the XML file to be serialized.</param>
    public void SaveSettings(string filePath)
    {
      string tempFile = string.Format("{0}.bak", filePath);
      using (System.IO.FileStream fileStream = new System.IO.FileStream(tempFile, System.IO.FileMode.Create))
      {
        SaveSettings(fileStream);
      }
      if ((System.IO.File.Exists(tempFile) && new System.IO.FileInfo(tempFile).Length > 0))
      {
        System.IO.File.Copy(tempFile, filePath, true);
        System.IO.File.Delete(tempFile);
      }
    }

    /// <summary>
    /// Save the settings to a stream.
    /// </summary>
    /// <param name="stream">The stream to serialize the settings to.</param>
    public void SaveSettings(System.IO.Stream stream)
    {
      XmlSerializer oXMLSerializer = new XmlSerializer(this.GetType());
      oXMLSerializer.Serialize(stream, this);
    }

    /// <summary>
    /// I'm not sure the point of this method. Looks like its something for IXmlSerializable
    /// </summary>
    /// <returns></returns>
    public System.Xml.Schema.XmlSchema GetSchema()
    {
      return null;
    }

    /// <summary>
    /// Defines how the XML file will be read into the object.
    /// </summary>
    /// <param name="reader"></param>
    public void ReadXml(System.Xml.XmlReader reader)
    {
      ReadObj(reader, this);
    }

    /// <summary>
    /// Defines how the object will be written to the XML file.
    /// </summary>
    /// <param name="writer"></param>
    public void WriteXml(System.Xml.XmlWriter writer)
    {
      WriteObj(writer, this);
    }
    #endregion

    #region " Private Methods "
    /// <summary>
    /// Defines how the object will be written to the XML file.
    /// </summary>
    /// <param name="writer">The current XMLWriter.</param>
    /// <param name="obj">The current object to write to XML.</param>
    private void WriteObj(System.Xml.XmlWriter writer, object obj)
    {
      object propertyValue = null;
      Type myType = obj.GetType();
      //int iIndex = 0;
      ICollection collection = null;

      if (myType.FullName.Equals("System.String") || (myType.IsValueType && myType.GetProperties().Count() == 0))
      {
        writer.WriteValue(obj);
      }
      else if (myType.GetInterface("ICollection") != null)
      {
        collection = (ICollection)obj;

        foreach (object innerObject in collection)
        {
          writer.WriteStartElement("Item");
          if (!innerObject.GetType().FullName.StartsWith("System."))
          {
            writer.WriteAttributeString("type", innerObject.GetType().FullName);
          }
          WriteObj(writer, innerObject);
          writer.WriteEndElement();
        }
      }
      else
      {
        foreach (PropertyInfo property in myType.GetProperties(GetBindings))
        {
          // If the property type is the same as the current object, we don't want to infinitely recurse.
          if (property.PropertyType.Equals(myType)) { continue; }
          // If the SkipSerialize attribute has been defined, don't serialize this property.
          if (property.IsDefined(typeof(SkipSerialize), true)) { continue; }

          propertyValue = property.GetValue(obj, null);
          // if the value of the property is nothing, skip it.
          if (propertyValue == null) { continue; }

          if (property.PropertyType.FullName.Equals("System.String") || property.PropertyType.IsValueType)
          {
            writer.WriteStartElement(property.Name);

            try
            {
              if (property.PropertyType.IsEnum)
              {
                writer.WriteValue(Convert.ChangeType(propertyValue, property.PropertyType.GetEnumUnderlyingType()));
              }
              else if (property.PropertyType == typeof(char))
              {
                writer.WriteString(propertyValue.ToString());
              }
              else
              {
                writer.WriteValue(propertyValue);
              }
            }
            catch (Exception)
            {
              // eat it. we don't need to write out something if they don't want us to.
            }

            writer.WriteEndElement();
          }
          else
          {
            writer.WriteStartElement(property.Name);

            // this is just a hack for now to get the iterations of a Collection based object
            if (property.PropertyType.GetInterface("ICollection") != null)
            {
              collection = (ICollection)propertyValue;
              // this is a hack for now to make sure that a stack is serialized and deserialized in the correct order.
              if (property.PropertyType.GetMethod("Pop") != null)
              {
                // since we have no access to an indexer, we need to create a backwards list of the items in the stack.
                // then we can simply iterate through the list instead of the collection object.
                List<object> list = new List<object>();

                foreach (object innerObject in collection) { list.Insert(0, innerObject); }

                foreach (object innerObject in list)
                {
                  writer.WriteStartElement("Item");
                  if (!innerObject.GetType().FullName.StartsWith("System."))
                  {
                    writer.WriteAttributeString("type", innerObject.GetType().FullName);
                  }
                  WriteObj(writer, innerObject);
                  writer.WriteEndElement();
                }
              }
              else
              {
                foreach (object innerObject in collection)
                {
                  writer.WriteStartElement("Item");
                  if (!innerObject.GetType().FullName.StartsWith("System."))
                  {
                    writer.WriteAttributeString("type", innerObject.GetType().FullName);
                  }
                  WriteObj(writer, innerObject);
                  writer.WriteEndElement();
                }
              }
            }
            else
            {
              WriteObj(writer, propertyValue);
            }
            writer.WriteEndElement();
          }

        }
      }
    }

    /// <summary>
    /// Defines how this object will be populated from the XML file.
    /// </summary>
    /// <param name="reader">The current XMLReader.</param>
    /// <param name="obj">The object that will populated from the current XMLReader.</param>
    private void ReadObj(System.Xml.XmlReader reader, object obj)
    {
      PropertyInfo property = null;
      Type myType = obj.GetType();
      Type oCollValueType = null;
      Type oCollKeyType = null;
      object key = null;
      object value = null;
      ConstructorInfo constructor = null;
      MethodInfo method = null;

      if (myType.GetInterface("ICollection") != null) { reader.ReadStartElement(); }

      do
      {
        if (reader.NodeType == System.Xml.XmlNodeType.Element)
        {
          if (myType.GetInterface("ICollection") != null)
          {
            try
            {
              oCollValueType = null;
              oCollKeyType = null;
              key = null;
              value = null;
              constructor = null;
              method = null;

              switch (myType.GetGenericArguments().Count())
              {
                case 0:

                  if (myType.BaseType.GetInterface("ICollection") != null && myType.BaseType.GetGenericArguments().Count() > 0 && GetAddMethod(myType, Type.EmptyTypes) == null)
                  {
                    switch (myType.BaseType.GetGenericArguments().Count())
                    {
                      case 1:
                        // ICollection
                        oCollValueType = myType.BaseType.GetGenericArguments().ElementAt(0);
                        break;
                      case 2:
                        // ICollection but also IDictionary
                        oCollKeyType = myType.BaseType.GetGenericArguments().ElementAt(0);
                        oCollValueType = myType.BaseType.GetGenericArguments().ElementAt(1);
                        break;
                      default:
                        break;
                    }
                  }
                  break;
                case 1:
                  // ICollection
                  oCollValueType = myType.GetGenericArguments().ElementAt(0);
                  break;
                case 2:
                  // ICollection but also IDictionary
                  oCollKeyType = myType.GetGenericArguments().ElementAt(0);
                  oCollValueType = myType.GetGenericArguments().ElementAt(1);
                  break;
                default:
                  break;
                // ??
              }
              if (oCollKeyType != null)
              {
                constructor = oCollKeyType.GetConstructor(Type.EmptyTypes);
                if (constructor != null) { key = constructor.Invoke(null); }

                constructor = oCollValueType.GetConstructor(Type.EmptyTypes);
                if (constructor != null) { value = constructor.Invoke(null); }

                method = GetAddMethod(myType, oCollKeyType, oCollValueType);

                if (method != null)
                {
                  if (key != null)
                  {
                    reader.ReadStartElement();
                    ReadBeyondWhiteSpace(reader);
                    ReadObj(reader.ReadSubtree(), key);
                    reader.ReadEndElement();
                  }
                  else
                  {
                    reader.ReadStartElement();
                    ReadBeyondWhiteSpace(reader);
                    key = reader.ReadElementContentAs(oCollKeyType, null);
                  }
                  if (value != null)
                  {
                    ReadBeyondWhiteSpace(reader);
                    ReadObj(reader.ReadSubtree(), value);
                  }
                  else
                  {
                    ReadBeyondWhiteSpace(reader);
                    value = reader.ReadElementContentAs(oCollValueType, null);
                  }
                  method.Invoke(obj, new object[] { key, value });

                }
              }
              else if (oCollValueType != null)
              {
                // ICollection, not IDictionary
                constructor = oCollValueType.GetConstructor(Type.EmptyTypes);
                if (constructor != null)
                {
                  value = constructor.Invoke(null);
                }
                else if (reader.GetAttribute("type") != null)
                {
                  // This deals with the situation where a collection may be of type interface, and you need to know what type of
                  // object was serialized in order to properly deserialize it.
                  Type otherType = null;
                  string typeString = reader.GetAttribute("type");
                  Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
                  if (assembly != null)
                  {
                    otherType = assembly.GetType(typeString);
                  }

                  if (otherType == null)
                  {
                    string[] namespaces = reader.GetAttribute("type").Split('.');
                    int namespaceCount = namespaces.Count();

                    string assemblyName = string.Empty;

                    for (int index = 0; index < namespaceCount; index++)
                    {
                      if (assemblyName.Length == 0) { assemblyName = namespaces[index]; }
                      else { assemblyName += string.Format(".{0}", namespaces[index]); }

                      otherType = Type.GetType(string.Format("{0}, {1}", typeString, assemblyName));

                      if (otherType != null) { break; }
                    }
                  }

                  if (otherType != null)
                  {
                    constructor = otherType.GetConstructor(Type.EmptyTypes);
                    value = constructor.Invoke(null);
                  }
                }

                method = GetAddMethod(myType, oCollValueType);

                if (method != null)
                {
                  if (value != null)
                  {
                    ReadObj(reader.ReadSubtree(), value);
                  }
                  else
                  {
                    value = reader.ReadElementContentAs(oCollValueType, null);
                  }
                  method.Invoke(obj, new object[] { value });
                }
              }
            }
            catch (Exception) { /* nom nom */ }
          }
          else
          {
            property = myType.GetProperty(reader.Name, GetBindings);
            if (property != null)
            {
              if (property.PropertyType.GetInterface("ICollection") != null)
              {
                object info = property.GetValue(obj, null);
                Console.WriteLine(info.GetType().ToString());
                ReadObj(reader.ReadSubtree(), property.GetValue(obj, null));
              }
              else if (property.PropertyType.FullName.Equals("System.String") || property.PropertyType.IsValueType)
              {
                try
                {
                  if (property.PropertyType.IsEnum)
                  {
                    property.SetValue(obj, reader.ReadElementContentAs(property.PropertyType.GetEnumUnderlyingType(), null), null);
                  }
                  else if (property.PropertyType == typeof(char))
                  {
                    property.SetValue(obj, reader.ReadElementContentAsString().ToCharArray()[0], null);
                  }
                  else
                  {
                    property.SetValue(obj, reader.ReadElementContentAs(property.PropertyType, null), null);
                  }
                }
                catch (Exception ex)
                {
                  //' nom nom
                  System.Diagnostics.Debug.Print("nom nom 2..." + ex.ToString());
                }
              }
              else
              {
                ReadObj(reader.ReadSubtree(), property.GetValue(obj, null));
              }
            }
          }
        }
      } while (reader.Read());
    }

    private void ReadBeyondWhiteSpace(System.Xml.XmlReader reader)
    {
      while (reader.NodeType == System.Xml.XmlNodeType.Whitespace)
      {
        reader.Read();
      }
    }

    private MethodInfo GetAddMethod(Type type, params Type[] objType)
    {
      MethodInfo oMethod = null;

      oMethod = type.GetMethod("Add", objType);
      if (oMethod == null) { oMethod = type.GetMethod("Enqueue", objType); }
      if (oMethod == null) { oMethod = type.GetMethod("Push", objType); }
      if (oMethod == null) { oMethod = type.GetMethod("AddLast", objType); }

      return oMethod;
    }
    #endregion
  }
}
