using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerLook lookScript;
    
    float playerHeight = 2f;

    AudioManager am;

    [SerializeField] Transform orientation;

    [Header("Movement")]
    public float moveSpeed = 6f;
    float movementMultiplier = 10f;
    [SerializeField] float airMultiplier = 0.4f;

    [Header("Jumping")]
    public float jumpForce = 5f;

    [Header("Shooting")]
    [SerializeField] Transform shootingPoint;
    [SerializeField] GameObject bulletPrefab;

    [Header("Sword Stuff")]
    [SerializeField] GameObject swordObject;

    [Header("Keybinds")]
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    [SerializeField] KeyCode shootKey = KeyCode.Mouse0;
    [SerializeField] KeyCode swingSwordKey = KeyCode.Mouse1;

    float groundDrag = 6f;
    float airDrag = 2f;

    float horizontalMovement;
    float verticalMovement;

    [Header("Ground Detection")]
    [SerializeField] LayerMask groundMask;
    bool isGrounded;
    float groundDistance = 0.4f;


    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        lookScript = GetComponent<PlayerLook>();

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        am = FindObjectOfType<AudioManager>();

        //swordObject = GameObject.FindWithTag("Sword");
        swordObject.SetActive(false);
    }

    // Checks if on the ground, if there is player input, and updates drag
    private void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, 1, 0), groundDistance, groundMask);
        
        MyInput();
        ControlDrag();

        ButtonPresses();
    }

    // Updates physics and stuff
    private void FixedUpdate()
    {
        MovePlayer();
    }

    // Most non-movement related input is checked here
    void ButtonPresses()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            Jump();
        }

        if(Input.GetKeyDown(shootKey))
        {
            am.Play("Fart");
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.transform.rotation);
        }

        if (Input.GetKeyDown(swingSwordKey))
        {
            am.Play("Sword Slice");
            StartCoroutine(SwingSword());
        }
    }

    // Movement input
    void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = orientation.forward * verticalMovement + orientation.right * horizontalMovement;
    }

    IEnumerator SwingSword()
    {
        swordObject.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        swordObject.SetActive(false);
    }
    
    // Big jump
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    // Changes the drag of the player if on the ground or not
    void ControlDrag()
    {
        if (isGrounded)
        {
            rb.drag = groundDrag;
        } else
        {
            rb.drag = airDrag;
        }
    }

    // Moves the player with different speeds based on if grounded or not
    void MovePlayer()
    {
        if (isGrounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        } else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * airMultiplier, ForceMode.Acceleration);
        }
    }
}
