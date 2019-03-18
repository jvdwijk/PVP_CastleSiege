using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameReset : MonoBehaviour
{

    [SerializeField]
    private string sceneName;

    public void ResetGame(){
        SceneManager.LoadScene(sceneName);
    }
}
