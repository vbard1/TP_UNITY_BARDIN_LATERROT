using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CubeMovement : MonoBehaviour
{
    [SerializeField]
    float _speed;

    public Text phaseDisplayText;
    public bool[] life;
    public GameObject[] lifeDisplay;
    private Vector2 touchStartPos;

    [SerializeField] private GameObject lifePrefab;


    // Start is called before the first frame update
    void Start()
    {
        life = new bool[4];
        for (int i = 0; i < life.Length; i++)
        {
            life[i] = true;
        }

        Color color = Color.black;
        lifeDisplay = new GameObject[4];
        for (int i = 0; i < lifeDisplay.Length; i++)
        {
            lifeDisplay[i] = Instantiate(lifePrefab, new Vector3(-9.63f + i, 4f, 0f), Quaternion.identity);
        }
        _speed = 5f;
        transform.position = new Vector2(0, 0);

        DisplayLife();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch theTouch = Input.GetTouch(0);

            switch (theTouch.phase)
            {
                case TouchPhase.Began:
                    touchStartPos = theTouch.position;
                    break;

                case TouchPhase.Moved:
                    Vector2 touchDelta = theTouch.position - touchStartPos;
                    Move(touchDelta);
                    touchStartPos = theTouch.position;
                    break;
            }
        }
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
                Retry();
            }
               
            DisplayLife();
        }
    }

    public void Retry()
    {
        //Restarts current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DisplayLife()
    {
        int i = 0;
        foreach (var item in life)
        {
            if (!item)
            {
                Debug.Log(item);
                lifeDisplay[i].GetComponent<SpriteRenderer>().material.color = Color.white;
            }
            i += 1;
        }
    }

    void Move(Vector2 touchDelta)
    {
        float adjustedSpeed = _speed * 0.005f;
        transform.Translate(touchDelta * adjustedSpeed);
    }
}
