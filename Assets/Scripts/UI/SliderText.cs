using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderText : MonoBehaviour
{
    [SerializeField]
    private Text text;

    [SerializeField]
    private Slider slider;

    private void Awake() {
        SetSetxt(slider.value);
        slider.onValueChanged.AddListener(SetSetxt);
    }

    public void SetSetxt(float num){
        text.text = num.ToString();
    }

}
