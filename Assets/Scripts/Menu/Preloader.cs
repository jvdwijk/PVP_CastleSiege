using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{

    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimumLogoTime = 3.0f;
    private void Start()
    {
        //Grab the only canvas group in the scene.
        fadeGroup = FindObjectOfType<CanvasGroup>();

        //Start with blackscreen.
        fadeGroup.alpha = 1;

        //Preload the game.
        // $$

        //Get timestamp of completion time.
        //If loadtime is too small, give it a buffer so we can appreciate PeppaSquad Logo :)
        if(Time.time < minimumLogoTime)
         loadTime = minimumLogoTime;
        else
            loadTime = Time.time;
    }

    private void Update()
    {
        //Fade-in
        if(Time.time < minimumLogoTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }
        //Fade-out
        if(Time.time > minimumLogoTime && loadTime != 0)
        { 
            fadeGroup.alpha = Time.time - minimumLogoTime;
            if(fadeGroup.alpha >= 1)
            {
                //ChangeScene
                SceneManager.LoadScene(1);
            }
        }
    }
}
