using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("SettingsCollection")]
public class SettingsContainer {

    [XmlArray("Settings"), XmlArrayItem("SettingsData")]
    public List<SettingsData> gameSettings = new List<SettingsData>();

    public void saveSettings(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SettingsContainer));
        FileStream stream = new FileStream(path, FileMode.Create);
        serializer.Serialize(stream, this);
        stream.Close();
    }

    public static SettingsContainer loadSettings(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(SettingsContainer));
        FileStream stream = new FileStream(path, FileMode.Open);
        SettingsContainer settings = serializer.Deserialize(stream) as SettingsContainer;
        stream.Close();
        return settings;
    }

}
