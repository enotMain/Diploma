using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float attackSpeed;
    public int modifier;
    public int modLevel;
    public int weaponFigure;
    public int weaponColor;

    public GameObject topAttackPoint;
    public GameObject topAttackPoint2;
    public GameObject bottomAttackPoint;
    public GameObject bottomAttackPoint2;
    public GameObject bullet;
    private float timeTofire = 0;

    public SpriteRenderer spriteRenderer;
    public Sprite circleSprite;
    public Sprite squireSprite;
    public Sprite triangleSprite;
    public Sprite hexagonSprite;
    public Sprite starSprite;

    public AudioSource audioSource;

    private void Awake()
    {
        DatabaseContainer.LoadDb();
        

        attackSpeed = DatabaseContainer.attackSpeed;
        modifier = DatabaseContainer.modifier;
        modLevel = DatabaseContainer.modLevel;
        weaponFigure = DatabaseContainer.weaponFigure;
        weaponColor = DatabaseContainer.weaponColor;

        if (!ToggleMusic.isMusicOn)
        {
            GameObject.FindGameObjectsWithTag("Music")[0].GetComponent<AudioSource>().mute = false;
        }

        Debug.Log(DatabaseContainer.weaponAttackDamage + " " + DatabaseContainer.attackSpeed);

        switch (weaponColor)
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
        switch (weaponFigure)
        {
            case 0:
                spriteRenderer.sprite = circleSprite;
                break;
            case 1:
                spriteRenderer.sprite = squireSprite;
                break;
            case 2:
                spriteRenderer.sprite = triangleSprite;
                break;
            case 3:
                spriteRenderer.sprite = hexagonSprite;
                break;
            case 4:
                spriteRenderer.sprite = starSprite;
                break;
        }
        switch (modifier)
        {
            case 1:
                switch (modLevel)
                {
                    case 0:
                        Mob.weaponDamage *= 1.2f;
                        break;
                    case 1:
                        Mob.weaponDamage *= 1.4f;
                        break;
                    case 2:
                        Mob.weaponDamage *= 1.6f;
                        break;
                    case 3:
                        Mob.weaponDamage *= 1.8f;
                        break;
                    case 4:
                        Mob.weaponDamage *= 2f;
                        break;
                }
                break;
            case 2:
                switch (modLevel)
                {
                    case 0:
                        attackSpeed /= 1.5f;
                        break;
                    case 1:
                        attackSpeed /= 2f;
                        break;
                    case 2:
                        attackSpeed /= 2.5f;
                        break;
                    case 3:
                        attackSpeed /= 3f;
                        break;
                    case 4:
                        attackSpeed /= 3.5f;
                        break;
                }
                break;
        }
    }

    void Modifier(float angle)
    {
        switch (modifier)
        {
            case 0:
                Instantiate(bullet, transform.position, transform.rotation);
                break;
            case 1:
                Instantiate(bullet, transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(bullet, transform.position, transform.rotation);
                break;
            case 3:
                switch (modLevel)
                {
                    case 0:
                        Instantiate(bullet, transform.position, transform.rotation);
                        break;
                    case 1:
                        Instantiate(bullet, topAttackPoint.transform.position, transform.rotation);
                        Instantiate(bullet, transform.position, transform.rotation);
                        break;
                    case 2:
                        Instantiate(bullet, bottomAttackPoint.transform.position, transform.rotation);
                        Instantiate(bullet, topAttackPoint.transform.position, transform.rotation);
                        Instantiate(bullet, transform.position, transform.rotation);
                        break;
                    case 3:
                        Instantiate(bullet, bottomAttackPoint.transform.position, transform.rotation);
                        Instantiate(bullet, topAttackPoint.transform.position, transform.rotation);
                        Instantiate(bullet, topAttackPoint2.transform.position, transform.rotation);
                        Instantiate(bullet, transform.position, transform.rotation);
                        break;
                    case 4:
                        Instantiate(bullet, bottomAttackPoint.transform.position, transform.rotation);
                        Instantiate(bullet, bottomAttackPoint2.transform.position, transform.rotation);
                        Instantiate(bullet, topAttackPoint.transform.position, transform.rotation);
                        Instantiate(bullet, topAttackPoint2.transform.position, transform.rotation);
                        Instantiate(bullet, transform.position, transform.rotation);
                        break;
                }
                break;
            case 4:
                switch (modLevel)
                {
                    case 0:
                        Instantiate(bullet, transform.position, transform.rotation);
                        break;
                    case 1:
                        transform.eulerAngles = new Vector3(0, 0, angle + 5);
                        Instantiate(bullet, transform.position, transform.rotation);
                        transform.eulerAngles = new Vector3(0, 0, angle);
                        Instantiate(bullet, transform.position, transform.rotation);
                        break;
                    case 2:
                        transform.eulerAngles = new Vector3(0, 0, angle + 5);
                        Instantiate(bullet, transform.position, transform.rotation);
                        transform.eulerAngles = new Vector3(0, 0, angle - 5);
                        Instantiate(bullet, transform.position, transform.rotation);
                        transform.eulerAngles = new Vector3(0, 0, angle);
                        Instantiate(bullet, transform.position, transform.rotation);
                        break;
                    case 3:
                        transform.eulerAngles = new Vector3(0, 0, angle + 10);
                        Instantiate(bullet, transform.position, transform.rotation);
                        transform.eulerAngles = new Vector3(0, 0, angle + 5);
                        Instantiate(bullet, transform.position, transform.rotation);
                        transform.eulerAngles = new Vector3(0, 0, angle - 5);
                        Instantiate(bullet, transform.position, transform.rotation);
                        transform.eulerAngles = new Vector3(0, 0, angle);
                        Instantiate(bullet, transform.position, transform.rotation);
                        break;
                    case 4:
                        transform.eulerAngles = new Vector3(0, 0, angle + 10);
                        Instantiate(bullet, transform.position, transform.rotation);
                        transform.eulerAngles = new Vector3(0, 0, angle + 5);
                        Instantiate(bullet, transform.position, transform.rotation);
                        transform.eulerAngles = new Vector3(0, 0, angle - 5);
                        Instantiate(bullet, transform.position, transform.rotation);
                        transform.eulerAngles = new Vector3(0, 0, angle - 10);
                        Instantiate(bullet, transform.position, transform.rotation);
                        transform.eulerAngles = new Vector3(0, 0, angle);
                        Instantiate(bullet, transform.position, transform.rotation);
                        break;
                }
                break;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 aimDirection = (mousePosition - transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            if (angle > 90)
            {
                angle = 90;
            }
            if (angle < -90)
            {
                angle = -90;
            }
            transform.eulerAngles = new Vector3(0, 0, angle);
            timeTofire += Time.deltaTime;
            if (timeTofire > attackSpeed)
            {
                audioSource.Play();
                Modifier(angle);
                timeTofire = 0;
            }
        }  
    }
}
