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
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<TextMeshProUGUI>();
        scoreDisplay.text = "Score: " + score;
    }

    public void UpdateScore()
    {
        scoreDisplay.text = "Score: " + score;
    }
}
