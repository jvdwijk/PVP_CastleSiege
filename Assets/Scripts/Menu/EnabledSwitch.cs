using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledSwitch : MonoBehaviour
{
public GameObject[] menuObjects;

      public void Switch(int menuNumber)
    {
        menuObjects[menuNumber].SetActive(!menuObjects[menuNumber].activeSelf);
    }

    public void DisableAll()
    {
        foreach(GameObject menuObject in menuObjects)
        {
            menuObject.SetActive(false);
        }
    }
}
