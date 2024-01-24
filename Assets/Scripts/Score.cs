using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public TMP_Text scoreUiElement;
    public TMP_Text highScoreUiElement;

    public GameObject[] bullet;
    private static int score;
    private static int highScore;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreUiElement.text = "["+highScore+"]";
    }

    void Update(){
        scoreUiElement.text="[" +score+"]";
        if(score-1>highScore){
            highScoreUiElement.text = scoreUiElement.text;
        }
    }

    public static int GetScore()
    {
        return score;
    }

    public static void IncrementScore()
    {
        score++;
    }

        public static void IncrementScore(int addScore) {
            for(int i=0; i<addScore;i++){
                IncrementScore();
            }
        }

}
