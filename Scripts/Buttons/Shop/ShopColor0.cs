using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;

public class ShopColor0 : MonoBehaviour
{
    public Button button;

    public GameObject gameObjectWeapon;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        string connectionString = DatabaseContainer.sqlConn;
        string sqlExpression = "UPDATE weapon SET weaponColor = 0 WHERE id = " + DatabaseContainer.id + ";";
        DatabaseContainer.weaponColor = 0;
        SqlConnection dbConnection = new SqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, dbConnection);
            command.ExecuteNonQuery();

            gameObjectWeapon.GetComponent<Image>().color = new Color(0.39f, 0.39f, 1f, 1f);
            DatabaseContainer.weaponColor = 0;
            DatabaseContainer.bulletColor = 0;
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }
}
