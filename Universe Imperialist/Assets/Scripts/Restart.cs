using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        GameManager.playGame = true;
        GameManager.lives = 3;
        GameManager.score = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
        
    }
}
