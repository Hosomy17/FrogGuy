using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator anim;
    
    public float jumpForce;

    [SerializeField]
    private AudioClip _audioClip;

    private void Start()
    {
        //anim = GetComponent<Animator>();
        TryGetComponent(out anim);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            AudioSource.PlayClipAtPoint(_audioClip, Vector3.back*10);
        }
    }
}
