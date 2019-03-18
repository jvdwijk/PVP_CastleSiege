using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpUI : MonoBehaviour
{
    [SerializeField]
    private Image powerupIconDisplay;
    
    public void SetPowerupImage(Sprite image){
        powerupIconDisplay.color = Color.white;
        powerupIconDisplay.sprite = image;
    }

    public void ResetImage(){
        powerupIconDisplay.color = new Color(0,0,0,0);
    }

}
