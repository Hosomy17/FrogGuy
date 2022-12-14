using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    [SerializeField]
    private AudioClip _pickSFX;

    public GameObject collected;
    public int Score;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += Score;

            AudioSource.PlayClipAtPoint(_pickSFX, Vector3.back * 10);
            
            Invoke("DisableApple", 0.25f);
        }
    }

    private void DisableApple()
    {
        gameObject.SetActive(false);
    }
}
