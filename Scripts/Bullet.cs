using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    private float speed = DatabaseContainer.bulletMoveSpeed;
    private int bulletColor = DatabaseContainer.bulletColor;

    private void switchBulletColor(int bulletColor)
    {
        switch (bulletColor)
        {
            case 0:
                spriteRenderer.color = new Color32(100, 100, 255, 255);
                break;
            case 1:
                spriteRenderer.color = new Color32(130, 255, 255, 255);
                break;
            case 2:
                spriteRenderer.color = new Color32(130, 255, 200, 255);
                break;
            case 3:
                spriteRenderer.color = new Color32(130, 255, 130, 255);
                break;
            case 4:
                spriteRenderer.color = new Color32(255, 255, 130, 255);
                break;
        }
    }

    void Start()
    {
        rb.velocity = transform.right * speed;
        switchBulletColor(bulletColor);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border" || collision.tag == "Mob")
        {
            Destroy(gameObject);
        }
    }
}
