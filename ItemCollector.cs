using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private TextMeshProUGUI cherriesText;
    [SerializeField] private AudioSource collectionSoundEffect;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Cherry"))
        {
            collectionSoundEffect.Play();
            Destroy(other.gameObject);
            cherries++;
            // Debug.Log("Cherries:" + cherries);
            cherriesText.text = "Cherries: " + cherries.ToString();
        }    
    }
}
