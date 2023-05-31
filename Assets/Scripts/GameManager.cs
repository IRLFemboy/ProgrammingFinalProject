using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;

    public GameObject selectedGun;
    public GameObject[] gunOptions;

    int waveNumber;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.Find("ScoreDisplay").GetComponent<TextMeshProUGUI>();
        scoreDisplay.text = "Score: " + score;

        selectedGun = gunOptions[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore()
    {
        scoreDisplay.text = "Score: " + score;
    }
}
