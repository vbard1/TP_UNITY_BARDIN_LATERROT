using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject[] bullet;
    private static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
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
