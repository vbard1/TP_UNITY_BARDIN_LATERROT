using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LifeComputation : MonoBehaviour
{

    public bool[] life;
    public GameObject[] lifeDisplay;
    [SerializeField] private GameObject lifePrefab;

    // Start is called before the first frame update
    void Start()
    {
        life = new bool[50];
        for (int i = 0; i < life.Length; i++)
        {
            life[i] = true;
        }

        Color color = Color.black;
        lifeDisplay = new GameObject[life.Length];
        for (int i = 0; i < lifeDisplay.Length; i++)
        {
            lifeDisplay[i] = Instantiate(lifePrefab, new Vector3(-6.3f + ((float)i) / 10f, 4f, 0f), Quaternion.identity);
        }
        DisplayLife();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            int index = life.Length - 1; // position du dernier true dans le tableau
            for (int i = 0; i < life.Length; i++)
            {
                if (!life[i])
                {
                    index = i - 1;
                    break;
                }
            }
            life[index] = false; //retire une vie
            if (!life[0])
            {
                if (Score.GetScore() > PlayerPrefs.GetInt("HighScore"))
                {
                    HighScoreSave(Score.GetScore());
                }
                Retry();
            }

            DisplayLife();
        }
    }

    void HighScoreSave(int highScore)
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }


    public void Retry()
    {
        //Restarts current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DisplayLife()
    {
        for (int i = 0; i < life.Length; i++)
        {
            if (!life[i])
            {
                lifeDisplay[i].GetComponent<SpriteRenderer>().material.color = Color.red;
                if (i > 1 && (life[i - 1] && !life[i]))
                {
                    lifeDisplay[i - 2].GetComponent<SpriteRenderer>().material.color = Color.green;
                    lifeDisplay[i - 1].GetComponent<SpriteRenderer>().material.color = Color.yellow;
                }
                

            }
        }
    }
}
