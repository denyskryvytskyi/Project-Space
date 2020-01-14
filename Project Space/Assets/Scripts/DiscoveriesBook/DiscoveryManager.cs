using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;
using System.IO;


public class DiscoveryManager : MonoBehaviour
{
    public DescriptionComponent discoveryDescriptionPrefab; // текст с описание выбранного открытия
    public ButtonComponent discoveryPrefab; // кнопка-элемнт списка открытий
    public ScrollRect discoveryScrollRect; // UI список открытий
    public ScrollRect textArea; // UI описание открытия

    private string fileName, lastName;
    private List<Discovery> discoveries; // временное решение (для реализации одноступенчатой иерархии)
    private List<Section> node; // !!! для многоуровневой иерархии (пока не используем)
    private Section section;
    private Discovery discovery;

    private bool isFirstDiscovery = true;

    public static DiscoveryManager Internal { get; set; }

    void Awake()
    {
        Internal = this;
    }

    public void DiscoveryBookOpen(string _fileName)
    {
        if (fileName == string.Empty)
            return;
        fileName = _fileName;
        Debug.Log("Test0");
        Load();
    }

    void Load()
    {
        Debug.Log("Test1");
        Debug.Log(lastName);
        Debug.Log(fileName);
        // нужно загрузить только названия открытий
        // сейчас реализовано только 1этажная иерархия открытий
        // то-есть слева список открытий - справа описание
        // поэтому подгружаем весь список открытий и их описание в массивы
        //if (fileName != null) // проверка, чтобы не загружать уже загруженный файл
        //{
            Debug.Log("Test2");
            discoveries = new List<Discovery>();

            try // чтение элементов XML и загрузка значений атрибутов в массивы
            {
                TextAsset binary = Resources.Load<TextAsset>(fileName);
                XmlTextReader reader = new XmlTextReader(new StringReader(binary.text));

                int index = 0;
                while (reader.Read())
                {
                    if (reader.IsStartElement("section"))
                    {
                        section = new Section();
                        section.name = reader.GetAttribute("name");
                        section.discoveries = new List<Discovery>();
                        // !!! node.Add(section);

                        XmlReader inner = reader.ReadSubtree();
                        while (inner.ReadToFollowing("discovery"))
                        {
                            discovery = new Discovery();
                            discovery.name = inner.GetAttribute("name");
                            discovery.text = inner.GetAttribute("text");

                            // !!! node[index].discoveries.Add(discovery);
                            discoveries.Add(discovery); // временно 
                            Debug.Log("Discovery added.");
                        }
                        inner.Close();

                        index++;
                    }
                }

                lastName = fileName;
                reader.Close();
            }
            catch (System.Exception error)
            {
                Debug.Log(this + " Ошибка чтения файла книги открытий: " + fileName + ".xml >> Error: " + error.Message);
                //scrollRect.gameObject.SetActive(false);
                lastName = string.Empty;
            }
        //}

        BuildBook();
    }

    void BuildElement(Discovery discovery)
    {
        ButtonComponent cloneObj = Instantiate(discoveryPrefab) as ButtonComponent;
        DescriptionComponent desc = Instantiate(discoveryDescriptionPrefab) as DescriptionComponent;

        cloneObj.text.text = discovery.name;
        cloneObj.rect.SetParent(discoveryScrollRect.content);
        
        if(isFirstDiscovery)
        {
            Debug.Log(discovery.name);
            Debug.Log("DESCRIPTION");
            desc.text.text = discovery.text;
            desc.rect.SetParent(textArea.content);
            isFirstDiscovery = false;
        }

    }

    void BuildBook()
    {
        foreach (Discovery discovery in discoveries)
        {
            BuildElement(discovery);
        }
    }
}



class Section
{
    public string name;
    public List<Discovery> discoveries;
}


class Discovery
{
    public string name;
    public string text;
}