using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSLimiter : MonoBehaviour
{
    public int target = 30;
    public int avgFrameRate;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }

    void Update()
    {
        float current = 0;
        current = (int)(1f / Time.unscaledDeltaTime);
        avgFrameRate = (int)current;

        if (Application.targetFrameRate != target)
            Application.targetFrameRate = target;
    }
}
