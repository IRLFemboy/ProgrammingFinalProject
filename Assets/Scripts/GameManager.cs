using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;
    int waveNumber;


    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Game")
        {
            scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<TextMeshProUGUI>();
            scoreDisplay.text = "Score: " + score;
        }
    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "GameOver")
        {
            if(Input.GetButtonDown("Submit"))
            {
                Restart();
            }

            if(Input.GetButtonDown("Cancel"))
            {
                LeaveCuzUrBad();
            }
        }
    }

    public void UpdateScore()
    {
        scoreDisplay.text = "Score: " + score;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Restart()
    {
        SceneManager.LoadScene("SelectScene");
        PlayerController.isDead = false;
    }

    public void LeaveCuzUrBad()
    {
        Debug.Log("wooOOooOOo game quit!1!1!!1");
        Application.Quit();
    }
}
