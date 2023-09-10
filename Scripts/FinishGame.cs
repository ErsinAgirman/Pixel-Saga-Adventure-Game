using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private bool gameCompleted = false;
    private PlayerMovement playerMovement;
    public Camera mainCamera;

    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
         if (other.gameObject.name == "Player" && !gameCompleted)
        {
            gameCompleted = true;
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Static; // Karakterin hareketini durdur.
            }
            mainCamera.orthographicSize = 2.5f;
            Invoke("CompleteGame", 8f);
         }

    }

    private void CompleteGame()
    {
        string levelName = "GameEnd" ;
        SceneManager.LoadScene(levelName);
    }
    

    
}
