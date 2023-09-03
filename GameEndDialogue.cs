using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameEndDialogue : MonoBehaviour
{
    public TextMeshProUGUI playerText;
    public TextMeshProUGUI princessText;
    private string[] playerLines;
    private string[] princessLines;
    private int currentPlayerLineIndex;
    private int currentPrincessLineIndex;
    private bool isPlayerSpeaking = true;

    private void Start()
    {
        // İlgili metinleri tanımlayın
        playerLines = new string[]
        {
            "Ben geldim prenses Zeynep!",
            "Senin için her şeyi aşıp geldim.",
            "Sonunda işte burda yanınızdayım!",
        };

        princessLines = new string[]
        {
            "Merhaba, cesur şövalyem!",
            "Yaptıkların ve bana ulaşmaya çalıştığın için sana minnettarım",
            "Ancak bu kadar geç geldiğin için sana küstüm BB."
        };

        ShowNextLine();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowNextLine();
        }
    }

    private void ShowNextLine()
    {
        if (isPlayerSpeaking)
        {
            if (currentPlayerLineIndex < playerLines.Length)
            {
                playerText.text = playerLines[currentPlayerLineIndex];
                currentPlayerLineIndex++;
            }
            else
            {
                isPlayerSpeaking = false;
                Invoke("ChangeScene", 15f);
            }
        }
        else
        {
            if (currentPrincessLineIndex < princessLines.Length)
            {
                princessText.text = princessLines[currentPrincessLineIndex];
                currentPrincessLineIndex++;
            }
            else
            {
                isPlayerSpeaking = true;
            }
        }
    }

    private void ChangeScene()
    {
       string levelName = "MainMenu";
       SceneManager.LoadScene(levelName);
    }
}
