using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;

public class ShopColor4 : MonoBehaviour
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
        string sqlExpression = "UPDATE weapon SET weaponColor = 4 WHERE id = " + DatabaseContainer.id + ";";
        DatabaseContainer.weaponColor = 4;
        SqlConnection dbConnection = new SqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, dbConnection);
            command.ExecuteNonQuery();

            gameObjectWeapon.GetComponent<Image>().color = new Color(1f, 1f, 0.5098f, 1f);
            DatabaseContainer.weaponColor = 4;
            DatabaseContainer.bulletColor = 4;
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }
}
