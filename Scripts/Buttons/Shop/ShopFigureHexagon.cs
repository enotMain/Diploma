using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;

public class ShopFigureHexagon : MonoBehaviour
{
    public Button button;

    public GameObject gameObjectWeapon;
    public Sprite spriteHexagon;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        string connectionString = DatabaseContainer.sqlConn;
        string sqlExpression = "UPDATE weapon SET weaponFigure = 3 WHERE id = " + DatabaseContainer.id + ";" +
            "UPDATE weapon SET modifier = 3 WHERE id = " + DatabaseContainer.id + ";";
        DatabaseContainer.weaponFigure = 3;
        DatabaseContainer.modifier = 3;
        SqlConnection dbConnection = new SqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, dbConnection);
            command.ExecuteNonQuery();

            gameObjectWeapon.GetComponent<Image>().sprite = spriteHexagon;
            DatabaseContainer.weaponFigure = 3;
            DatabaseContainer.modifier = 3;
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }
}
