using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    //Pause the game;
    public void OnPause()
    {
        Time.timeScale = 0;
    }

    //Resume the game
    public void OnResume()
    {
        Time.timeScale = 1f;
    }
}
