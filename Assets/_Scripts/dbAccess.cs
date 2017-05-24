using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using System.IO;

public class dbAccess : MonoBehaviour
{

    private IDbConnection dbCon;
    private IDbCommand dbCommand;
    private IDataReader reader;
    


    public string[] record;
    public int[] score;
    public string[] playerName;
    public string dbName;

    private string conn;
    private string path;



    void Awake()
    {
        dbName = "database.db";



#if UNITY_EDITOR

        path = Application.dataPath + "/StreamingAssets/";
        conn = "URI=file:" + Application.persistentDataPath + "/" + dbName + ";";

#elif UNITY_ANDROID
                       
        path = "file://" + Application.dataPath + "!/assets/";
        conn = "URI=file:" + Application.persistentDataPath + "/" + dbName + ";";

#endif


        conn = "URI=file:" + Application.persistentDataPath + "/" + dbName + ";";

        //Debug.Log(Environment.GetFolderPath(Environment.SpecialFolder.));

        //CreateDatabase();
        CreateTable();

        record = new string[5];
        score = new int[5];
        playerName = new string[5];

        GetRecords();

    }


    private void CreateDatabase()
    {
        string filePath = path + dbName;


        Debug.Log(File.Exists(filePath));

       if(File.Exists(filePath) ==false)
        {



            WWW loadDatabase = new WWW(filePath);

            while (loadDatabase.isDone == false) {}

            File.WriteAllBytes(filePath, loadDatabase.bytes);
            
            //SqliteConnection.CreateFile(filePath);

            
            
        }
        

    }




    private void CreateTable()
    {
        //string test = "SELECT count(*) FROM database WHERE type='table' AND name='highscores'";

        string sql= "CREATE TABLE IF NOT EXISTS `highscores`"
            +"(`id`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,"
            +"`name`	TEXT NOT NULL,`score`	INTEGER NOT NULL);";

        Connect();

        dbCommand = dbCon.CreateCommand();
        dbCommand.CommandText = sql;

        
        
            dbCommand.ExecuteNonQuery();


        dbCommand.Dispose();
        dbCommand = null;

        Disconnect();

    }


    private void Connect()
    {

        dbCon =  new SqliteConnection(conn);

        dbCon.Open(); 

    }


    private void Disconnect()
    {
        dbCon.Close();
        dbCon.Dispose();
        dbCon = null;
    }

    public void GetRecords()
    {

        string sql = "SELECT name,score FROM highscores ORDER BY score DESC";

        Connect();

        dbCommand = dbCon.CreateCommand();
        dbCommand.CommandText = sql;

        reader = dbCommand.ExecuteReader();

        for(int i=0;reader.Read() && i<5 ;i++)
        {
                       
            playerName[i] = reader.GetString(0);
            score[i] = reader.GetInt32(1);

            record[i] = playerName[i] + " " + score[i].ToString();

            Debug.Log(reader.GetString(0) + " " + reader.GetInt32(1).ToString());
        }

        reader.Close();
        
        reader = null;

        dbCommand.Dispose();
        dbCommand = null;

        Disconnect();

    }


    private string GetRecord(IDataReader reader)
    {
        string queryName,queryScore,record;

        queryName = reader.GetString(0);
        queryScore = reader.GetInt32(1).ToString();

        record = queryName + "   " + queryScore;
        Debug.Log(record);
        return record;

    }


    public void AddRecord(string name,int score)
    {

        string sql = "INSERT INTO highscores(name,score) VALUES('" + name +"'," + score + ")";

        

        Connect();

        dbCommand = dbCon.CreateCommand();
        dbCommand.CommandText = sql;

        try
        {
            dbCommand.ExecuteNonQuery();
        }
        catch (SqliteException ex)
        {

            Debug.Log(ex.ErrorCode);
        }
        

        Debug.Log(name + " with score : " + score + "added to database successfully");

        dbCommand.Dispose();
        dbCommand = null;

        Disconnect();
        

    }


}
