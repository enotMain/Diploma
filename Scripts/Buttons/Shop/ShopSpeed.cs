using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopSpeed : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (DatabaseContainer.attackSpeed > 0.05f)
        {
            string connectionString = DatabaseContainer.sqlConn;
            string sqlExpression = "UPDATE weapon SET attackSpeed = attackSpeed - 0.005 WHERE id = " +
                DatabaseContainer.id + ";";
            DatabaseContainer.attackSpeed -= 0.005f;
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
