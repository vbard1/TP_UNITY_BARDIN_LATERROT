using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject cubeMovement;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firing;
    [Range(0.1f, 1f)]
    [SerializeField] private float firingRate = 0.5f;

    private Rigidbody2D rb;
    private float mx;
    private float my;

    private Vector2 mousePos;
    private Vector2 cubePos;

    private float timer = 0f;
    private float interval = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //mx = Input.GetAxisRaw("Horizontal");
        //my = Input.GetAxisRaw("Vertical");
        //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cubePos = cubeMovement.transform.position;

        float angle = Mathf.Atan2(cubePos.y - transform.position.y, cubePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        transform.localRotation = Quaternion.Euler(0, 0, angle);

        timer += Time.deltaTime;

        if(timer > interval)
        {
            Shoot();
            timer = 0f;
            if (interval > 0.2f) { 
                interval = interval / 1.1f;
            }
        }
    }

    private void Shoot()
    {
        UnityEngine.Debug.Log(firing.position);
        Instantiate(bulletPrefab, firing.position, firing.rotation);
    }
}
