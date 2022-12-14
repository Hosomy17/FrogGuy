using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;
    
    private Rigidbody2D rig;
    private Animator anim;

    [SerializeField]
    private AudioClip _jumpSFX;
    
    [SerializeField]
    private AudioClip _hitSFX;
    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //mudanca na movimentacao de:
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * Speed;
        
        //para:
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);

        if (movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        
        if (movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        
        if (movement == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                JumpFixedGravity();
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    JumpFixedGravity();
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fire"))
        {
            GameController.instance.ShowGameOver();
            AudioSource.PlayClipAtPoint(_hitSFX, Vector3.back*10);
            Destroy(gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

    void JumpFixedGravity()
    {
        rig.velocity *= Vector2.right;
        rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        AudioSource.PlayClipAtPoint(_jumpSFX, Vector3.back*10);
    }
}
