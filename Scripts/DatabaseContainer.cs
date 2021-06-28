using System.Data.SqlClient;
using System.IO;
using UnityEngine;

public class DatabaseContainer : MonoBehaviour
{
    public static int id;
    public static string sqlConn;

    // Weapon parameters
    public static int modifier; // Database
    public static int modLevel; // Database
    public static int weaponFigure; // Database
    public static int weaponColor; // Database
    public static float attackSpeed; // Database
    public static float weaponAttackDamage; // Database

    // Bullet parameters
    public static int bulletColor;
    public static float bulletMoveSpeed;

    // Others parameters
    public static long coin; // Database
    public static int coinRare; // Database
    public static int level; // Database

    // Mob parameters
    public static float mobMoveSpeed;
    public static float mobHealthPoints;

    public static void LoadDb()
    {
        Debug.Log("Connecting to database...");
        string connectionString = sqlConn;
        //Debug.Log(id);
        string sqlExpressionOther = "SELECT * FROM other WHERE id = " + id + ";";
        string sqlExpressionPlayer = "SELECT * FROM play WHERE id = " + id + ";";
        string sqlExpressionWeapon = "SELECT * FROM weapon WHERE id = " + id + ";";
        SqlConnection dbConnection = new SqlConnection(connectionString);
        try
        {
            dbConnection.Open();
            Debug.Log("Connected to database.");

            SqlCommand commandOther = new SqlCommand(sqlExpressionOther, dbConnection);
            SqlCommand commandPlayer = new SqlCommand(sqlExpressionPlayer, dbConnection);
            SqlCommand commandWeapon = new SqlCommand(sqlExpressionWeapon, dbConnection);

            SqlDataReader readerOther = commandOther.ExecuteReader();
            if (readerOther.Read())
            {
                coin = readerOther.GetInt64(1);
                coinRare = readerOther.GetInt32(2);
                level = readerOther.GetInt16(3);
                mobMoveSpeed = 2.6f + (level - 1f) * 0.0948f;
                mobHealthPoints = 100f + (level - 1f) * 1.98f;
            }
            readerOther.Close();

            Debug.Log(coin + " " + coinRare + " " + level);

            SqlDataReader readerWeapon = commandWeapon.ExecuteReader();
            if (readerWeapon.Read())
            {
                modifier = readerWeapon.GetByte(1);
                modLevel = readerWeapon.GetByte(2);
                weaponFigure = readerWeapon.GetByte(3);
                weaponColor = readerWeapon.GetByte(4);
                attackSpeed = readerWeapon.GetFloat(5);
                weaponAttackDamage = readerWeapon.GetFloat(6);
            }
            readerWeapon.Close();

            bulletColor = weaponColor;
            bulletMoveSpeed = 20f;
        }
        catch (SqlException exception)
        {
            Debug.LogWarning(exception.ToString());
        }
    }
}
