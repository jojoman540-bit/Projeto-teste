using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static InputSystem_Actions;

public class Movimento2 : MonoBehaviour
{
    public float playerSpeed;

    public Rigidbody2D rb;

    private PlayerActions playerActions;

    private Vector2 moveDirections;

    private float jumpForce;

    [SerializeField]
    private Animator playerAnimation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() 
    {
    }

    
    private void Awake()
    {
        playerActions = new PlayerActions();
        playerActions.PlayerMovement.Jump.performed += Jump;

    }
    private void OnEnable()
    {
        playerActions.Enable();
    }

    private void onDisable()
    {
        playerActions.Disable();
    }

    private void FixedUpdate()
    {
        moveDirections = playerActions.PlayerMovement.Move.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext ctx) 
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
