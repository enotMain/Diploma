using UnityEngine;

public class Mob : MonoBehaviour
{
    public Rigidbody2D rb;
    public AudioClip audioClip;

    private float hp;
    private float speed;
    private int color;
    internal static float weaponDamage;

    private void SwitchComponentsColor(SpriteRenderer component, int color)
    {
        switch (color)
        {
            case 0:
                component.color = new Color32(255, 172, 252, 255);
                break;
            case 1:
                component.color = new Color32(241, 72, 251, 255);
                break;
            case 2:
                component.color = new Color32(113, 34, 250, 255);
                break;
            case 3:
                component.color = new Color32(235, 4, 80, 255);
                break;
        }
    }

    void Start()
    {
        hp = DatabaseContainer.mobHealthPoints;
        speed = DatabaseContainer.mobMoveSpeed;
        weaponDamage = DatabaseContainer.weaponAttackDamage;

        Component[] components = gameObject.GetComponentsInChildren<SpriteRenderer>();
        color = Random.Range(0, 4);
        foreach(SpriteRenderer component in components)
        {
            SwitchComponentsColor(component, color);
        }
        rb.velocity = -transform.right * speed;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob") && collision.transform.position.x <
            gameObject.transform.position.x)
        {
            rb.velocity = -transform.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mob") || collision.CompareTag("Base"))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (collision.CompareTag("Bullet"))
        {
            hp -= weaponDamage;
            if (hp <= 0)
            {
                AudioSource.PlayClipAtPoint(audioClip, new Vector3(0, 0), 0.02f);
                Destroy(gameObject);
                int rareCoinChance = Random.Range(0, 1000);
                if (rareCoinChance == 0)
                {
                    CoinRare.coinRare += 1;
                }
                else
                {
                    Coin.coin += (int) (DatabaseContainer.level * 0.1f + 1f);
                }
            }
        }
    }
}
