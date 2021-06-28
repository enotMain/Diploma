using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

public class ShopLevel : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (DatabaseContainer.level < 500)
        {
            string connectionString = DatabaseContainer.sqlConn;
            string sqlExpression = "UPDATE other SET level = level + 1 WHERE id = " +
                DatabaseContainer.id + ";";
            DatabaseContainer.level += 1;
            ShopPlayerInf.ShowStats();
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
}
