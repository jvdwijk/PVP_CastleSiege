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
        SetText(slider.value);
        slider.onValueChanged.AddListener(SetText);
    }

    public void SetText(float num){
        text.text = num.ToString();
    }

}
