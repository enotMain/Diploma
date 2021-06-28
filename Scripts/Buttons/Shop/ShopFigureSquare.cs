using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;

public class ShopFigureSquare : MonoBehaviour
{
    public Button button;

    public GameObject gameObjectWeapon;
    public Sprite spriteSquare;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        string connectionString = DatabaseContainer.sqlConn;
        string sqlExpression = "UPDATE weapon SET weaponFigure = 1 WHERE id = " + DatabaseContainer.id + ";" +
            "UPDATE weapon SET modifier = 1 WHERE id = " + DatabaseContainer.id + ";";
        DatabaseContainer.weaponFigure = 1;
        DatabaseContainer.modifier = 1;
        SqlConnection dbConnection = new SqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, dbConnection);
            command.ExecuteNonQuery();

            gameObjectWeapon.GetComponent<Image>().sprite = spriteSquare;
            DatabaseContainer.weaponFigure = 1;
            DatabaseContainer.modifier = 1;
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }
}
