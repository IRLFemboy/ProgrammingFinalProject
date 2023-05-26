using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;
    
    int waveNumber;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GameObject.Find(¨ScoreDisplay¨).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
