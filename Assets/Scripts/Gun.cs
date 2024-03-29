using System.Security.AccessControl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject cubeMovement;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firing;
    private Rigidbody2D rb;
    private float mx;
    private float my;

    private Vector2 mousePos;
    private Vector2 cubePos;

    private float timer = 0f;
    private float interval = 4f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cubePos = cubeMovement.transform.position;

        float angle = Mathf.Atan2(cubePos.y - transform.position.y, cubePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle); 

        timer += Time.deltaTime;

        if(timer > interval)
        {
            Shoot(Quaternion.Euler(0, 0,angle*(1+ Random.Range(-5f, 5f) / 100f)));
            timer = 0f;
            if (interval > 0.1f) { 
                interval = interval / 1.2f;
            }
        }
    }

    private void Shoot(Quaternion quaternion)
    {
        Instantiate(bulletPrefab, firing.position, quaternion);
    }
}
