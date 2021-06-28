using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using UnityEngine;
using UnityEngine.UI;

public class ShopDamageMinus : MonoBehaviour
{
    public Button button;

    private void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (DatabaseContainer.weaponAttackDamage > 10)
        {
            string connectionString = DatabaseContainer.sqlConn;
            string sqlExpression = "UPDATE weapon SET weaponAttackDamage = weaponAttackDamage - 10 WHERE id = " +
                DatabaseContainer.id + ";";
            DatabaseContainer.weaponAttackDamage -= 10;
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
