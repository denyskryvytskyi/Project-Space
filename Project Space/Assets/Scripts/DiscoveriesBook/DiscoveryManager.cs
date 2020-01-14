using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Xml;
using System.IO;


public class DiscoveryManager : MonoBehaviour
{

	private string _fileName, lastName;
	private List<Discovery> node;
	private Section section;
	private Answer answer;

    public static DiscoveryManager Internal { get; set; }

	void Awake()
	{
		Internal = this;
	}

	public void DiscoveryBookOpen(string fileName)
	{
		if (fileName == string.Empty) 
			return;
		_fileName = fileName;
		Load();
	}

	void Load()
	{
		if (lastName == _fileName) // проверка, чтобы не загружать уже загруженный файл
		{
			//for (int i = 0; i < length; i++)
			//{
			//	SetSection(i);
			//}
			
			return;
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