using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data.SqlClient;

public class ShopFigureStar : MonoBehaviour
{
    public Button button;

    public GameObject gameObjectWeapon;
    public Sprite spriteStar;

    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        string connectionString = DatabaseContainer.sqlConn;
        string sqlExpression = "UPDATE weapon SET weaponFigure = 4 WHERE id = " + DatabaseContainer.id + ";" +
            "UPDATE weapon SET modifier = 4 WHERE id = " + DatabaseContainer.id + ";";
        DatabaseContainer.weaponFigure = 4;
        DatabaseContainer.modifier = 4;
        SqlConnection dbConnection = new SqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, dbConnection);
            command.ExecuteNonQuery();

            gameObjectWeapon.GetComponent<Image>().sprite = spriteStar;
            DatabaseContainer.weaponFigure = 4;
            DatabaseContainer.modifier = 4;
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }
}
