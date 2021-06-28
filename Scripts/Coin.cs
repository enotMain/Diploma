using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data.SqlClient;

public class Coin : MonoBehaviour
{
    public Text text;
    internal static long coin = DatabaseContainer.coin;

    void Start()
    {
        coin = DatabaseContainer.coin;
        text.text = coin.ToString();
    }

    void FixedUpdate()
    {
        text.text = coin.ToString();
    }

    private void OnDisable()
    {
        DatabaseContainer.coin = coin;
        string connectionString = DatabaseContainer.sqlConn;
        string sqlExpression = "UPDATE other SET coin = " + coin + " WHERE id = " + DatabaseContainer.id + ";";
        SqlConnection dbConnection = new SqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, dbConnection);
            command.ExecuteNonQuery();
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }
}
