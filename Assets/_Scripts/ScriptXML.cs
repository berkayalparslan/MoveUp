using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Xml;

public class ScriptXML : MonoBehaviour
{

    public int score;

    public string fileName;
    private string path;
    private string filePath;


    void Awake()
    {
        fileName = "highscores.xml";

        path = Application.persistentDataPath+"/";

        filePath = path + fileName;
        CreateFile();

        score = 0;

        CheckRecord();
    }


    private void CreateFile()
    {

        if(File.Exists(filePath)== false)
        {

            WWW writer = new WWW(filePath);
            byte[] toBytes;
            while (writer.isDone == false) { }

            File.WriteAllBytes(writer.url, writer.bytes);

            Debug.Log(File.GetCreationTime(filePath));
            Debug.Log("File created !");

            XmlDocument doc = new XmlDocument();            

            XmlDeclaration xmlDeclare = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;

            doc.InsertBefore(xmlDeclare, root);

            XmlElement scoreElement = doc.CreateElement(string.Empty, "score", string.Empty);
            
            doc.AppendChild(scoreElement);

            scoreElement.InnerText=score.ToString();

            toBytes = System.Text.Encoding.UTF8.GetBytes(doc.OuterXml);

            File.WriteAllBytes(writer.url, toBytes);

        }

        else
        {
            Debug.Log("file already exists !");
        }
        
    }

   
    public void AddRecord(int score)
    {
        File.Delete(path + fileName);
        WWW writer = new WWW(path + fileName);
        byte[] toBytes;
        while (writer.isDone == false) { }

        File.WriteAllBytes(writer.url, writer.bytes);

        Debug.Log(File.GetCreationTime(filePath));
        Debug.Log("File created !");

        XmlDocument doc = new XmlDocument();

        XmlDeclaration xmlDeclare = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        XmlElement root = doc.DocumentElement;

        doc.InsertBefore(xmlDeclare, root);

        XmlElement scoreElement = doc.CreateElement(string.Empty, "score", string.Empty);

        doc.AppendChild(scoreElement);

        scoreElement.InnerText = score.ToString();

        toBytes = System.Text.Encoding.UTF8.GetBytes(doc.OuterXml);

        File.WriteAllBytes(writer.url, toBytes);

    }


    public void CheckRecord()
    {
        byte[] toBytes = File.ReadAllBytes(filePath);
        string xmlText = System.Text.UTF8Encoding.UTF8.GetString(toBytes);
        //Debug.Log(xmlText);

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xmlText);
        XmlNode node = doc.DocumentElement.SelectSingleNode("/score");

        score = Int32.Parse(node.InnerText);
        Debug.Log(score);
    }

}
