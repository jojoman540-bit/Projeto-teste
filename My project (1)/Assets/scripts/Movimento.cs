using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Movimento : MonoBehaviour
{
    public float speed;
    public float forcapulo;
    public Rigidbody2D rb;
    private InputSystem_Actions actions;
    private Vector2 moveDirection;
    public Animator playerAnimation;
    [SerializeField] private AudioSource audioSourcePlayer;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxOnGround;


    private void Awake()
    {
        actions = new InputSystem_Actions();
        actions.Player.Jump.performed += jump;
    }

    public void OnEnable()
    {
        actions.Enable();
    }

    private void jump(InputAction.CallbackContext ctx)
    {
        rb.AddForce(Vector2.up * forcapulo, ForceMode2D.Impulse);
        audioSourcePlayer.PlayOneShot(sfxJump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            audioSourcePlayer.PlayOneShot(sfxOnGround);
        }
    }

    public float playerSpeed;



    private void FixedUpdate()
    {
        moveDirection = actions.Player.Move.ReadValue<Vector2>();
        transform.Translate(moveDirection*Time.deltaTime*speed);

        playerAnimation.SetFloat("eixoX", moveDirection.x);
        playerAnimation.SetFloat("eixoY", moveDirection.y);

        if (moveDirection.x != 0)
        {

            playerAnimation.SetInteger("andando",1);

        }
        else
        {
            playerAnimation.SetInteger("andando",0);
        }
        

    } 
}