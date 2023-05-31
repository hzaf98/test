using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] HeroMovement heroMovement;
    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        //Increase player speed
        heroMovement.speed += heroMovement.speedIncreasedPerPoint;
    }
    private void Awake()
    {
        inst = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
