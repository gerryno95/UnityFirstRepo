using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
 
    MainGameController mainGameController;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TMP_InputField playerNameText;

    // Start is called before the first frame update
    void Start()
    {
        mainGameController = MainGameController.instance;
        mainGameController.LoadBestMatch();
        if (mainGameController.bestMatch != null)
        {
           
            bestScoreText.text = "Best Score: "
                + mainGameController.bestMatch.name + " -> "
                + mainGameController.bestMatch.score;
        }

    }
    public void StartGame() {
        mainGameController.playerName = playerNameText.text.Trim();
        mainGameController.StartGame();
    }
}
