using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

public class CoinRare : MonoBehaviour
{
    public Text text;
    internal static int coinRare = DatabaseContainer.coinRare;

    void Start()
    {
        coinRare = DatabaseContainer.coinRare;
        text.text = coinRare.ToString();
    }

    void FixedUpdate()
    {
        text.text = coinRare.ToString();
    }

    private void OnDisable()
    {
        DatabaseContainer.coinRare = coinRare;
        string connectionString = DatabaseContainer.sqlConn;
        string sqlExpression = "UPDATE other SET coinRare = " + coinRare + " WHERE id = " + DatabaseContainer.id + ";";
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
