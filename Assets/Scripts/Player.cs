using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Input")]
    private PlayerInputs actions;
    
    public float Speed;
    public float JumpForce;

    public bool isJumping;
    public bool doubleJump;
    
    private Rigidbody2D rig;
    private Animator anim;
    
    private float _movement;

    [SerializeField]
    private AudioClip _jumpSFX;
    
    [SerializeField]
    private AudioClip _hitSFX;

    private void Awake()
    {
        actions = new PlayerInputs();

        actions.Player.Movement.performed += Move;
        actions.Player.Movement.canceled += Move;

        actions.Player.Jump.performed += Jump;
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Player.Movement.performed -= Move;
        actions.Player.Movement.canceled -= Move;

        actions.Player.Jump.performed -= Jump;
        
        actions.Disable();
    }

    void Start()
    {
        //rig = GetComponent<Rigidbody2D>();
        TryGetComponent(out rig);
        //anim = GetComponent<Animator>();
        TryGetComponent(out anim);
    }
    
    void FixedUpdate()
    {
        rig.velocity = new Vector2(_movement * Speed, rig.velocity.y);
    }

    void Move(InputAction.CallbackContext movement)
    {
        //mudanca na movimentacao de:
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * Speed;
        
        //para:
        _movement = movement.ReadValue<Vector2>().x;
        
        if (_movement > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        
        if (_movement < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        
        if (_movement == 0f)
        {
            anim.SetBool("walk", false);
        }
    }

    void Jump(InputAction.CallbackContext _)
    {
        if (isJumping == false)
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
