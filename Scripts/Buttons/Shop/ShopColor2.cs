using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;

public class ShopColor2 : MonoBehaviour
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
        string sqlExpression = "UPDATE weapon SET weaponColor = 2 WHERE id = " + DatabaseContainer.id + ";";
        DatabaseContainer.weaponColor = 2;
        SqlConnection dbConnection = new SqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, dbConnection);
            command.ExecuteNonQuery();

            gameObjectWeapon.GetComponent<Image>().color = new Color(0.5098f, 1f, 0.7843137f, 1f);
            DatabaseContainer.weaponColor = 2;
            DatabaseContainer.bulletColor = 2;
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }
}
