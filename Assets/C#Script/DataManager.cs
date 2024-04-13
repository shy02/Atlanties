using System.Collections;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Android;

public class DataManager : MonoBehaviour
{
    [SerializeField] MainStatus_Data maindata;
    [SerializeField] Text text;
    string filepath;

    void Start()
    {
        Debug.Log("Initializing database...");
        string DBname = "Atlanties_DB.db";
        text.text = "1";

        // 안드로이드에서 런타임 권한 요청
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite) || !Permission.HasUserAuthorizedPermission(Permission.ExternalStorageRead))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
                Permission.RequestUserPermission(Permission.ExternalStorageRead);
            }
        }

        StartCoroutine(InitializeDatabase(DBname));
    }

    IEnumerator InitializeDatabase(string DBname)
    {
        yield return StartCoroutine(SetDBfilePath(DBname));

        text.text = "2";
        string connectionString = GetDBFilePath(DBname);
        text.text = "3";

        using (IDbConnection DBConnection = new SqliteConnection(connectionString))
        {
            text.text = "4";
            DBConnection.Open();
            text.text = "5";

            string tablename = "Player_Data";
            text.text = "6";
            IDbCommand dbCommand = DBConnection.CreateCommand();
            text.text = "7";
            dbCommand.CommandText = "SELECT * FROM " + tablename;
            text.text = "8";
            using (IDataReader dataReader = dbCommand.ExecuteReader())
            {
                text.text = "9";
                if (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(1))
                    {
                        maindata.Playername = dataReader.GetString(1);
                    }
                    maindata.Level = dataReader.GetInt32(2);
                    maindata.rec_exp = dataReader.GetInt32(3);
                    maindata.coin = dataReader.GetInt32(4);
                    maindata.cash = dataReader.GetInt32(5);
                    maindata.heart = dataReader.GetInt32(6);
                    maindata.head = dataReader.GetInt32(7);
                    maindata.body = dataReader.GetInt32(8);
                    maindata.leg = dataReader.GetInt32(9);
                    maindata.pet = dataReader.GetInt32(10);
                    maindata.Final_Clear_Stage = dataReader.GetInt32(11);
                    if (!dataReader.IsDBNull(12))
                    {
                        maindata.Call_ = dataReader.GetInt32(12);
                    }
                }
            }
            text.text = "10";
        }

        text.text = "11";
        Debug.Log("Database initialization complete.");
        SceneManager.LoadScene("StartDisplay");
    }

    IEnumerator SetDBfilePath(string DBname)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            filepath = Path.Combine(Application.persistentDataPath, DBname);
            if (!File.Exists(filepath))
            {
                UnityWebRequest unityWebRequest = UnityWebRequest.Get(Path.Combine(Application.streamingAssetsPath, DBname));
                yield return unityWebRequest.SendWebRequest();

                if (string.IsNullOrEmpty(unityWebRequest.error))
                {
                    File.WriteAllBytes(filepath, unityWebRequest.downloadHandler.data);
                }
                else
                {
                    Debug.LogError("Failed to download database: " + unityWebRequest.error);
                }
            }
        }
        else
        {
            filepath = Path.Combine(Application.dataPath, DBname);
            if (!File.Exists(filepath))
            {
                File.Copy(Path.Combine(Application.streamingAssetsPath, DBname), filepath);
            }
        }
    }

    public string GetDBFilePath(string DBname)
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            return "URI=file:" + Path.Combine(Application.persistentDataPath, DBname);
        }
        else
        {
            return "URI=file:" + Path.Combine(Application.dataPath, DBname);
        }
    }
}
