using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.IO;

public class DataManager : MonoBehaviour {

	// Use this for initialization
	void Awake () 
    {
        setupFile();
	}

    void setupFile()
    {
        if (!File.Exists("./settingsData.xml"))
        {
            string[] lines = 
            {
                "<settingsData>",
                "<volume value=\"5\">",
                "</volume>",
                "<quality value=\"5\">",
                "</quality>",
                "<subtitles value=\"false\">",
                "</subtitles>",
                "</settingsData>"
            };

            File.WriteAllLines("./settingsData.xml", lines);
        }
    }

    public int getVolume()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("./settingsData.xml");

        XmlNode node = xmlDoc.SelectSingleNode("settingsData/volume");

        return XmlConvert.ToInt16(node.Attributes[0].Value);
    }

    public void setVolume(int _volume)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("./settingsData.xml");

        XmlNode node = xmlDoc.SelectSingleNode("settingsData/volume");

        node.Attributes[0].Value = _volume.ToString();

        xmlDoc.Save("./settingsData.xml");
    }

    public int getQuality()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("./settingsData.xml");

        XmlNode node = xmlDoc.SelectSingleNode("settingsData/quality");

        return XmlConvert.ToInt16(node.Attributes[0].Value);
    }

    public void setQuality(int _quality)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("./settingsData.xml");

        XmlNode node = xmlDoc.SelectSingleNode("settingsData/quality");

        node.Attributes[0].Value = _quality.ToString();

        xmlDoc.Save("./settingsData.xml");
    }

    public bool getSubtitles()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("./settingsData.xml");

        XmlNode node = xmlDoc.SelectSingleNode("settingsData/subtitles");

        return XmlConvert.ToBoolean(node.Attributes[0].Value);
    }

    public void setSubtitles(bool _subtitles)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("./settingsData.xml");

        XmlNode node = xmlDoc.SelectSingleNode("settingsData/subtitles");

        if (_subtitles == true)
        {
            node.Attributes[0].Value = "true";
        }
        else
            node.Attributes[0].Value = "false";
        

        xmlDoc.Save("./settingsData.xml");
    }
}
