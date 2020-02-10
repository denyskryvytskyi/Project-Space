using UnityEngine;
using System.Xml;

public class DiscoveryGenerator : MonoBehaviour
{
    public string fileName; // имя генерируемого файла (без разрешения)
    public DiscoverySection[] node;

    public void Generate()
    {
        string path = Application.dataPath + "/Resources/" + fileName + ".xml";

        XmlNode userNode;
        XmlElement element;

        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = xmlDoc.CreateElement("book");
        XmlAttribute attribute = xmlDoc.CreateAttribute("name");
        attribute.Value = fileName;
        rootNode.Attributes.Append(attribute);
        xmlDoc.AppendChild(rootNode);

        for (int j = 0; j < node.Length; j++)
        {
            userNode = xmlDoc.CreateElement("section");
            attribute = xmlDoc.CreateAttribute("id");
            attribute.Value = j.ToString();
            userNode.Attributes.Append(attribute);
            attribute = xmlDoc.CreateAttribute("name");
            attribute.Value = node[j].sectionName;
            userNode.Attributes.Append(attribute);

            for (int i = 0; i < node[j].discoveryItems.Length; i++)
            {
                element = xmlDoc.CreateElement("discovery");
                element.SetAttribute("name", node[j].discoveryItems[i].discoveryName);
                element.SetAttribute("text", node[j].discoveryItems[i].discoveryText);

                //if (node[j].playerAnswer[i].toNode > 0) element.SetAttribute("toNode", node[j].playerAnswer[i].toNode.ToString());
                //if (node[j].playerAnswer[i].exit) element.SetAttribute("exit", node[j].playerAnswer[i].exit.ToString());
                userNode.AppendChild(element);
            }

            rootNode.AppendChild(userNode);
        }

        xmlDoc.Save(path);
        Debug.Log(this + " Создан XML файл книги открытий [ " + fileName + " ] по адресу: " + path);
    }
}

[System.Serializable]
public class DiscoverySection
{
    public string sectionName;
    public DiscoveryItem[] discoveryItems;
}

[System.Serializable]
public class DiscoveryItem
{
    public string discoveryName;
    public string discoveryText;
}