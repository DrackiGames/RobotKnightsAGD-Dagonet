using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class SettingsData {

    [XmlAttribute("Setting")]
    public string settingID;
    [XmlElement("Volume")]
    public int volumeValue;
    [XmlElement("Quality")]
    public int qualityValue;
    [XmlElement("Subtitles")]
    public bool subtitlesEnabled;
}
