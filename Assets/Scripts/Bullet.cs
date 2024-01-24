using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEditor.Progress;

public class Bullet : MonoBehaviour {
    private float speed = 10f;

    private float lifeTime =10f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        rb.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name!="Gun"){
            if (collision.gameObject.name != "Cube")
            {
                Score.IncrementScore();
            }
            Destroy(gameObject);
        }
    }
}
