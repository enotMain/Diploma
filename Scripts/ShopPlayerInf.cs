using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPlayerInf : MonoBehaviour
{
    public static Text text;

    private void Start()
    {
        text = gameObject.GetComponent<Text>();
        ShowStats();
    }

    public static void ShowStats()
    {
        text.text = "Урон " + DatabaseContainer.weaponAttackDamage + "\n" +
            "Скор. " + (1 / DatabaseContainer.attackSpeed) + "\n" +
            "Level " + DatabaseContainer.level;
    }
}
