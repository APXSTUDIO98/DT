using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRed : MonoBehaviour
{
    public float speed;
    public float range;
    private float startingposy;
    int dir = 1;
    void Start()
    {
        startingposy = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if(transform.position.y <startingposy|| transform.position.y > startingposy+range)
        {
            dir *= -1;
        }
    }
}
