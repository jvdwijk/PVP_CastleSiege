using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWonHandler : MonoBehaviour
{

    [SerializeField]
    private Animator victoryUI;

    [SerializeField]
    private GameReset reset;

    [SerializeField]
    private GUIActivator mainGUI;

    private const string inScreen = "InScreen";

    private void OnEnable() {
        StartCoroutine(GameWonRoutine());
    }

    private IEnumerator GameWonRoutine(){
        victoryUI.SetBool(inScreen, true);
        mainGUI.SetActive(false);
        yield return new WaitForSeconds(2);
        victoryUI.SetBool(inScreen, false);
        yield return new WaitForSeconds(0.5f);
        reset.ResetGame();
    }

}
