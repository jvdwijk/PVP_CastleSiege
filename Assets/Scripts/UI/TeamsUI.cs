using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamsUI : MonoBehaviour
{
    [SerializeField]
    private GameObject[] teams;

    public void UpdateUI(int playerAmount){
        for (int i = 0; i < teams.Length; i++)
        {
            if(i > playerAmount - 1)
                teams[i].SetActive(false);
        }
    }
}
