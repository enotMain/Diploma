using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWeapon : MonoBehaviour
{
    private Image objImage;

    public Sprite spriteCircle;
    public Sprite spriteSquare;
    public Sprite spriteTriangle;
    public Sprite spriteHexagon;
    public Sprite spriteStar;

    void Start()
    {
        objImage = GetComponent<Image>();
        switch (DatabaseContainer.weaponFigure)
        {
            case 0:
                objImage.sprite = spriteCircle;
                break;
            case 1:
                objImage.sprite = spriteSquare;
                break;
            case 2:
                objImage.sprite = spriteTriangle;
                break;
            case 3:
                objImage.sprite = spriteHexagon;
                break;
            case 4:
                objImage.sprite = spriteStar;
                break;
        }
        switch (DatabaseContainer.weaponColor)
        {
            case 0:
                objImage.color = new Color(0.39f, 0.39f, 1f, 1f);
                break;
            case 1:
                objImage.color = new Color(0.5098f, 1f, 1f, 1f);
                break;
            case 2:
                objImage.color = new Color(0.5098f, 1f, 0.7843137f, 1f);
                break;
            case 3:
                objImage.color = new Color(0.5098f, 1f, 0.5098f, 1f);
                break;
            case 4:
                objImage.color = new Color(1f, 1f, 0.5098f, 1f);
                break;
        }
    }
}
