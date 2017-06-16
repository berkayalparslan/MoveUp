using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mono.Data.Sqlite;
//using System.Data;
using System;
using System.IO;
using System.Xml;

public class dbAccess : MonoBehaviour
{

    //private IDbConnection dbCon;
    //private IDbCommand dbCommand;
    //private IDataReader reader;

    public int score;

    public string fileName;
    //private string conn;
    private string path;
    private string filePath;


    void Start()
    {
        //dbName = "database.db";
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

            scoreElement.InnerText=score.ToString();
            //root.AppendChild(scoreElement);


            toBytes = System.Text.Encoding.UTF8.GetBytes(doc.OuterXml);

            File.WriteAllBytes(writer.url, toBytes);

        }
        else
        {
            Debug.Log("file already exists !");
        }
        

    }


    public void xmlFunc()
    {
        XmlDocument doc = new XmlDocument();

        XmlDeclaration xmlDeclare = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        XmlElement root = doc.DocumentElement;
        doc.InsertBefore(xmlDeclare, root);

        XmlElement scoreElement = doc.CreateElement(string.Empty, "score", string.Empty);
        doc.AppendChild(scoreElement);
        XmlText scoreValue = doc.CreateTextNode("testScore");
        scoreElement.AppendChild(scoreValue);

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
        //root.AppendChild(scoreElement);


        toBytes = System.Text.Encoding.UTF8.GetBytes(doc.OuterXml);

        File.WriteAllBytes(writer.url, toBytes);

        //////

        //byte[] toBytes = File.ReadAllBytes(filePath) ;
        //string xmlText =System.Text.UTF8Encoding.UTF8.GetString(toBytes);
        //Debug.Log("eben XD "+xmlText);
        //WWW writer = new WWW(path + fileName);

        //XmlDocument doc = new XmlDocument();
        //doc.LoadXml(xmlText);
        //Debug.Log(xmlText);

        //XmlNode scoreNode = doc.SelectSingleNode("/score");
        //Debug.Log(scoreNode.InnerText);
        //scoreNode.InnerText = score.ToString();

        ////scoreElement.InnerText = score.ToString();



        //toBytes = System.Text.Encoding.UTF8.GetBytes(doc.OuterXml);



        //while (writer.isDone == false) { }

        //File.WriteAllBytes(writer.url, writer.bytes);

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


    private void CreateNode(string name,int score,XmlWriter writer)
    {
        
        
        //writer.WriteStartElement("name");
        //writer.WriteName(name);
        //writer.WriteEndElement();

        //writer.WriteStartElement("score");
        //writer.WriteValue(score);
        //writer.WriteEndElement();

    }

    //private void CreateDatabase()
    //{
    //    string filePath = path + dbName;

    //    Debug.Log(File.Exists(filePath));
    //    WWW loadDatabase = new WWW(filePath);

    //    while (loadDatabase.isDone == false)
    //    {
    //        Debug.Log("file progress " +loadDatabase.uploadProgress);
             
    //    }


    //    File.WriteAllBytes(filePath, loadDatabase.bytes);


    //}




    //private void CreateTable()
    //{
    //    //string test = "SELECT count(*) FROM database WHERE type='table' AND name='highscores'";

    //    string sql= "CREATE TABLE IF NOT EXISTS `highscores`"
    //        +"(`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
    //        +"`name`	TEXT NOT NULL,`score`	INTEGER NOT NULL);";

    //    Connect();

    //    dbCommand = dbCon.CreateCommand();
    //    dbCommand.CommandText = sql;

    //    dbCommand.ExecuteNonQuery();

    //    dbCommand.Dispose();
    //    dbCommand = null;

    //    Disconnect();

    //}


    //private void Connect()
    //{

    //    dbCon =  new SqliteConnection(conn);

    //    dbCon.Open(); 

    //}


    //private void Disconnect()
    //{
    //    dbCon.Close();
    //    dbCon.Dispose();
    //    dbCon = null;
    //}

    //public void GetRecords()
    //{

    //    string sql = "SELECT name,score FROM highscores ORDER BY score DESC";

    //    Connect();

    //    dbCommand = dbCon.CreateCommand();
    //    dbCommand.CommandText = sql;

    //    reader = dbCommand.ExecuteReader();

    //    for(int i=0;reader.Read() && i<5 ;i++)
    //    {
                       
    //        playerName[i] = reader.GetString(0);
    //        score[i] = reader.GetInt32(1);

    //        record[i] = playerName[i] + " " + score[i].ToString();

    //        Debug.Log(reader.GetString(0) + " " + reader.GetInt32(1).ToString());
    //    }

    //    reader.Close();
        
    //    reader = null;

    //    dbCommand.Dispose();
    //    dbCommand = null;

    //    Disconnect();

    //}


    //private string GetRecord(IDataReader reader)
    //{
    //    string queryName,queryScore,record;

    //    queryName = reader.GetString(0);
    //    queryScore = reader.GetInt32(1).ToString();

    //    record = queryName + "   " + queryScore;
    //    Debug.Log(record);
    //    return record;

    //}


    //public void AddRecord(string name,int score)
    //{

    //    string sql = "INSERT INTO highscores(name,score) VALUES('" + name +"'," + score + ")";

        

    //    Connect();

    //    dbCommand = dbCon.CreateCommand();
    //    dbCommand.CommandText = sql;

    //    try
    //    {
    //        dbCommand.ExecuteNonQuery();
    //    }
    //    catch (SqliteException ex)
    //    {

    //        Debug.Log(ex.ErrorCode);
    //    }
        

    //    Debug.Log(name + " with score : " + score + "added to database successfully");

    //    dbCommand.Dispose();
    //    dbCommand = null;

    //    Disconnect();
        

    //}


}
