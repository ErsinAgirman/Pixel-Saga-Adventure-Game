using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private int level; 
    [SerializeField] private TextMeshProUGUI levelText;
    private Finish finish;

    public GameObject button;
    public Color color;
    

    private void Start() 
    {
        if (levelText != null)
        {
            levelText.text = level.ToString();
            finish = FindObjectOfType<Finish>();
            UpdateButtonColors();

            PlayerPrefs.Save();
            //PlayerPrefs.SetInt("LevelKey",0); //kilitli seviyeleri sıfırlamak için
         }
        

    }

    public void OpenScene()
    {
        Finish.myLevel = PlayerPrefs.GetInt("LevelKey",Finish.myLevel);
        if (Finish.myLevel + 1 >= level)
        {
            string levelName = "Level " + level;
            SceneManager.LoadScene(levelName);
            Debug.Log("myLevel "+ Finish.myLevel);

        }
        
    }

    private void UpdateButtonColors()
    {
            if (Finish.myLevel + 1 < level)
            {   
                button.GetComponent<Image>().color = Color.gray;
                //color = new Color(0.5f, 0.5f, 0.5f);
            }
            
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

    public void OpenInfoMenu()
    {
        string levelName = "InfoScene" ;
        SceneManager.LoadScene(levelName);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
