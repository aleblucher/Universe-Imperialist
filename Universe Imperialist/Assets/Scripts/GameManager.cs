using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    public static int score = 0;
    public static bool playGame = true;
    public static bool gameIsPaused;

    public Text livestext;
    public Text scoretext;
    public Text endScreen;
    public Button restartButton;
    public GameObject panel;

    //public GameObject restartButton; 

    // Start is called before the first frame update
    void Start()
    {
        livestext.text = "Vidas: " + lives;
        scoretext.text = "Pontuação: " + score;
        restartButton.gameObject.SetActive(false);
        panel.SetActive(false);
        endScreen.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        livestext.text = "Vidas: " + lives;
        scoretext.text = "Pontuação: " + score;

        if(lives == 0)
        {
            panel.SetActive(true);
            endScreen.text = "Você Perdeu!";
            restartButton.gameObject.SetActive(true);
        }

        else if(GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            panel.SetActive(true);
            endScreen.text = "Você Ganhou!";
            restartButton.gameObject.SetActive(true);
        }

     

        else if (Input.GetKeyDown(KeyCode.P)) {
            gameIsPaused = !gameIsPaused;
            PauseGame();
            

        }

    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            playGame = false;
            panel.SetActive(true);
            endScreen.text = "Pause";
            restartButton.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            endScreen.text = "";
            panel.SetActive(false);
            restartButton.gameObject.SetActive(false);
        }
    }
}
