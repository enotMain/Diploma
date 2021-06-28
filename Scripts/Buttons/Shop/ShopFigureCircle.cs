using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;

public class ShopFigureCircle : MonoBehaviour
{
    public Button button;

    public GameObject gameObjectWeapon;
    public Sprite spriteCircle;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        string connectionString = DatabaseContainer.sqlConn;
        string sqlExpression = "UPDATE weapon SET weaponFigure = 0 WHERE id = " + DatabaseContainer.id + ";" +
            "UPDATE weapon SET modifier = 0 WHERE id = " + DatabaseContainer.id + ";";
        DatabaseContainer.weaponFigure = 0;
        DatabaseContainer.modifier = 0;
        SqlConnection dbConnection = new SqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, dbConnection);
            command.ExecuteNonQuery();

            gameObjectWeapon.GetComponent<Image>().sprite = spriteCircle;
            DatabaseContainer.weaponFigure = 0;
            DatabaseContainer.modifier = 0;
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }
}
