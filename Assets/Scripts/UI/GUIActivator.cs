using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIActivator : MonoBehaviour
{
    [SerializeField]
    private bool activateOnAwake = false;
    [SerializeField]
    private Animator[] uiObjects;


    private const string inScreen = "InScreen";

    private void Awake(){
        SetActive(activateOnAwake);
    }

    public void SetActive(bool active){
        foreach (var uiObject in uiObjects){
            uiObject.SetBool(inScreen, active);
        }
    }
}
