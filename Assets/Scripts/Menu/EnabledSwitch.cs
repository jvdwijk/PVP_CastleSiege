using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledSwitch : MonoBehaviour
{
[SerializeField] private GameObject[] _menuObjects;

      public void Switch(int menuNumber)
    {
        _menuObjects[menuNumber].SetActive(!_menuObjects[menuNumber].activeSelf);
    }

    public void BeginGame()
    {
        foreach(GameObject menuObject in _menuObjects)
        {

            menuObject.SetActive(false);
        }
    }
}
