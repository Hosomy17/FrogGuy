using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private Animator anim;
    private CircleCollider2D circle;
    
    [SerializeField]
    private AudioClip _pickSFX;
    
    public int Score;
    
    void Start()
    {
        TryGetComponent(out anim);
        TryGetComponent(out circle);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            circle.enabled = false;
            anim.Play("collected");
            
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
