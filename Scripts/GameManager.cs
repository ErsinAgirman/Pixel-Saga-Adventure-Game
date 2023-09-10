using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPausedGame = false;
    public GameObject yourObjectToEnable;
    public GameObject QuitButton;

    public void PauseGame()
    {
        if (isPausedGame == false)
        {
            Time.timeScale = 0f;
            isPausedGame = true;
            yourObjectToEnable.SetActive(true);
            QuitButton.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            isPausedGame = false;
            yourObjectToEnable.SetActive(false);
            QuitButton.SetActive(false);
        }
    }

    public void QuitMenu()
    {
        string levelName = "LevelSelector" ;
        SceneManager.LoadScene(levelName);
        Time.timeScale = 1f;
    }
}
