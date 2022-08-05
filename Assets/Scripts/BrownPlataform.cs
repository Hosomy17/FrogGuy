using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class BrownPlataform : MonoBehaviour
{

    public float speed;
    private bool dirUp = true;
    private float timer;
    public float moveTime;

    void FixedUpdate()
    {
        if (dirUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
         //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 1f),
           //  8f * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
           // transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, 1f),
            //  -8f * Time.deltaTime);
        }
        
        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            dirUp = !dirUp;
            timer = 0f;
        }
        
    }
    
    
}
