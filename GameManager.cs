using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isPausedGame = false;
    public void PauseGame()
    {
        if (isPausedGame == false)
        {
            Time.timeScale = 0f;
            isPausedGame = true;
        }
        else
        {
            Time.timeScale = 1f;
            isPausedGame = false;
        }
    }
}
