using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class MainMenuInputButton : MonoBehaviour
{
    InfClass infClass = new InfClass();
    SqlConn sqlConn = new SqlConn();

    private string pathInf;
    private string pathSqlConn;
    private string code;
    private string pathLog;

    public GameObject UI1;
    public GameObject UI2;
    public GameObject UI3;
    public InputField input;
    public Button button;

    public void CreateCode()
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        System.Random random = new System.Random();
        int position;

        string connectionString = @"PATH";
        string sqlExpression = "SELECT COUNT(*) FROM player;";
        SqlConnection dbConnection = new SqlConnection(connectionString);

        ///
        using (StreamWriter sw = File.AppendText(pathLog))
        {
            sw.WriteLine("check before try");
        }
        ///

        try
        {
            dbConnection.Open();

            string sqlExpressionKeyIdCount;
            int keyIdCount;
            bool flag = true;

            ///
            using (StreamWriter sw = File.AppendText(pathLog))
            {
                sw.WriteLine("check before while");
            }
            ///

            while (flag)
            {
                code = "";
                for (int i = 1; i < 24; i++)
                {
                    if (i % 6 == 0)
                    {
                        code += "-";
                    }
                    else
                    {
                        position = random.Next(0, alphabet.Length - 1);
                        code += alphabet[position];
                    }
                }

                ///
                using (StreamWriter sw = File.AppendText(pathLog))
                {
                    sw.WriteLine("check creating code" + code);
                }
                ///

                //Debug.Log(code);

                sqlExpressionKeyIdCount = "SELECT COUNT(*) FROM player WHERE keyID in ('" + code + "');";
                SqlCommand commandCount = new SqlCommand(sqlExpressionKeyIdCount, dbConnection);
                SqlDataReader readerCount = commandCount.ExecuteReader();
                readerCount.Read();
                if ((keyIdCount = readerCount.GetInt32(0)) == 0)
                {
                    flag = false;
                }
                readerCount.Close();
            }

            ///
            using (StreamWriter sw = File.AppendText(pathLog))
            {
                sw.WriteLine("check after code" + code);
            }
            ///

            /*using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(code);
                sw.Close();
            }*/

            SqlCommand command = new SqlCommand(sqlExpression, dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            int idCount = -1;
            if (reader.Read())
            {
                idCount = reader.GetInt32(0);
            }
            reader.Close();

            /*using (StreamWriter sw = File.CreateText(pathId))
            {
                sw.Write(idCount + 1);
                sw.Close();
            }*/

            infClass.keyId = code;
            infClass.id = idCount + 1;
            string json = JsonUtility.ToJson(infClass);
            var encoding = Encoding.GetEncoding("UTF-8");
            try
            {
                using (StreamWriter writerJson = new StreamWriter(pathInf, false, encoding))
                {
                    writerJson.Write(json);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }

            string sqlExpressionNewPlayer = "INSERT weapon VALUES(" + (idCount + 1) + ", 0, 4, 0, 0, 1.0, 10);" +
            "INSERT other VALUES(" + (idCount + 1) + ", 0, 0, 1);" +
            "INSERT player VALUES(" + (idCount + 1) + ", '" + (input.text) + "', " + (idCount + 1) + 
            ", " + (idCount + 1) + ", '" + code + "');";
            command = new SqlCommand(sqlExpressionNewPlayer, dbConnection);
            command.ExecuteNonQuery();

            DatabaseContainer.id = idCount + 1;
            DatabaseContainer.LoadDb();
        }
        catch (SqlException exception)
        {
            //Debug.LogWarning(exception.ToString());
            ///
            using (StreamWriter sw = File.AppendText(pathLog))
            {
                sw.WriteLine("check sqlexc " + exception.ToString());
            }
            ///
        }

        UI1.SetActive(true);
        //UI2.SetActive(true);
        UI3.SetActive(true);
        input.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
    }

    private void Awake()
    {


        pathInf = Application.persistentDataPath + "/inf.json";
        //pathInf = @"Assets/Resources/inf.json";
        //pathSqlConn = @"Assets/Resources/sqlConn.json";

        //pathInf = Application.dataPath + "/inf.json";
        //pathSqlConn = Application.dataPath + "/sqlConn.json";

        Debug.Log(pathInf);

        if (!File.Exists(pathInf))
        {
            File.Create(pathInf).Dispose();
        }

        pathLog = Application.persistentDataPath + "/log.txt";

        UI2.SetActive(false);

        /*using (StreamReader sr = new StreamReader(pathSqlConn))
        {
            JsonUtility.FromJsonOverwrite(sr.ReadLine(), sqlConn);
            sr.Close();
            DatabaseContainer.sqlConn = sqlConn.sqlConnection;
            Debug.Log(DatabaseContainer.sqlConn);
        }*/

        DatabaseContainer.sqlConn = @"PATH";

        using (StreamReader sr = new StreamReader(pathInf))
        {
            string s = sr.ReadLine();

            ///
            using (StreamWriter sw = File.AppendText(pathLog))
            {
                sw.WriteLine("check read code");
            }
            ///

            Debug.Log(s);
            if (s == null)
            {
                sr.Close();
                UI1.SetActive(false);
                UI2.SetActive(false);
                UI3.SetActive(false);
            }
            else
            {
                sr.Close();
                JsonUtility.FromJsonOverwrite(s, infClass);
                Debug.Log("Десериализация\n" +
                    infClass.keyId + "\n" +
                    infClass.id);
                input.gameObject.SetActive(false);
                button.gameObject.SetActive(false);
                DatabaseContainer.id = infClass.id;
                DatabaseContainer.LoadDb();
            }
        }
    }

    private void Start()
    {
        button.onClick.AddListener(TaskOnClick);
        ///
        using (StreamWriter sw = File.AppendText(pathLog))
        {
            sw.WriteLine("check on click");
        }
        ///
    }

    void TaskOnClick()
    {
        string nickname = input.text;
        if (nickname != null && nickname != "")
        {
            ///
            using (StreamWriter sw = File.AppendText(pathLog))
            {
                sw.WriteLine("check button " + nickname);
            }
            ///
            CreateCode();
        }
    }
}
