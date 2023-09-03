using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;
    private int myLevel= 0;
    internal static object finish;

    void Start()
    {
        finishSound = GetComponent<AudioSource>();
        myLevel = PlayerPrefs.GetInt("LevelKey",0);
        Debug.Log("seviye " + myLevel);
    }

    public void LevelisCompleted()
    {
        myLevel++;
        PlayerPrefs.SetInt("LevelKey",myLevel);
        PlayerPrefs.Save();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
         if (other.gameObject.name == "Player" && !levelCompleted)
         {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel",2f);
            LevelisCompleted();
         }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
