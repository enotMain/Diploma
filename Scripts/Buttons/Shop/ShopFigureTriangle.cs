using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;

public class ShopFigureTriangle : MonoBehaviour
{
    public Button button;

    public GameObject gameObjectWeapon;
    public Sprite spriteTriangle;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        string connectionString = DatabaseContainer.sqlConn;
        string sqlExpression = "UPDATE weapon SET weaponFigure = 2 WHERE id = " + DatabaseContainer.id + ";" +
            "UPDATE weapon SET modifier = 2 WHERE id = " + DatabaseContainer.id + ";";
        DatabaseContainer.weaponFigure = 2;
        DatabaseContainer.modifier = 2;
        SqlConnection dbConnection = new SqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, dbConnection);
            command.ExecuteNonQuery();

            gameObjectWeapon.GetComponent<Image>().sprite = spriteTriangle;
            DatabaseContainer.weaponFigure = 2;
            DatabaseContainer.modifier = 2;
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }
}
