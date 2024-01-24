using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    public TMP_Text scoreUiElement;
    public GameObject[] bullet;
    private static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    void Update(){
        scoreUiElement.text="[" +score+"]";
    }

    public static int GetScore()
    {
        return score;
    }

    public static void IncrementScore()
    {
        score++;
    }
}
