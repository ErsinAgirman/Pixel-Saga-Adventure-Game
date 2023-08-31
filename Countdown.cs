using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float current_time;
    [SerializeField] private float duration;
    private PlayerLife playerLife; // Referansı tutmak için değişken
    



    void Start()
    {
        current_time = duration;
        timerText.text = current_time.ToString();
        StartCoroutine(UpdateTime());
         playerLife = FindObjectOfType<PlayerLife>(); // Referansı ayarla
    }

    private IEnumerator UpdateTime()
{
    while (current_time > 0)
    {
        timerText.text = current_time.ToString();
        yield return new WaitForSeconds(1f);
        current_time--;
    }
        if (playerLife != null)
        {
            playerLife.Die();
        }

    yield return null;
    }
 
    
}
