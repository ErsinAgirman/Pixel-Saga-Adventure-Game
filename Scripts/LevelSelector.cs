using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private int level; 
    [SerializeField] private TextMeshProUGUI levelText;
    private Finish finish;

    private void Start() 
    {
        if (levelText != null)
        {
            levelText.text = level.ToString();
            finish = FindObjectOfType<Finish>();
        }
        
    }

    public void OpenScene()
    {
        string levelName = "Level " + level;
        SceneManager.LoadScene(levelName);
    }

    public void OpenMainMenu()
    {
        string levelName = "MainMenu" ;
        SceneManager.LoadScene(levelName);
    }

    public void OpenLevelMenu()
    {
        string levelName = "LevelSelector" ;
        SceneManager.LoadScene(levelName);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
