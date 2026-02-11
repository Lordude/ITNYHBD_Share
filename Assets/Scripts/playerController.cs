 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class playerController : MonoBehaviour
 {    
 
    private CharacterController characterController;
    public GameObject camera;
    public float walkSpeed = 2f;
    public float sprintSpeed = 3f;
    public float minLookX, maxLookX;
    public bool isSprinting, isWalking;
    public Vector3 moveDirection;
    Vector3 idleVector;
    public AudioSource walkSound;
    public Rigidbody rigidbody;
 
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float mouseSensitivity = 1f;
 
     void Start()
     {
        idleVector = new Vector3(0.0f, 0.0f, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();
     }
 
     void Update()
     {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) == false)
        {
            isWalking = false;
        }
        if( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) == true)
        {
            isWalking = true;
        }

        if(Input.GetKey(KeyCode.LeftShift) && isWalking == true)
        {
            isSprinting = true;
        }
        if(Input.GetKey(KeyCode.LeftShift) == false)
        {
            isSprinting = false;
        }

        Move();
        RotatePlayer();
     }

 
     private void Move()
     {
        float x = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * moveSpeed;

        moveDirection = (transform.forward * y + transform.right * x) * Time.deltaTime;
 
        rigidbody.velocity = moveDirection;
     }
 
     private void RotatePlayer()
     {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
 
        float mouseXLook = mouseX * mouseSensitivity;
        float mouseYLook = mouseY * mouseSensitivity;

        mouseYLook = Mathf.Clamp(mouseYLook, minLookX, maxLookX);

        transform.Rotate(0, mouseXLook, 0f);
        camera.transform.Rotate(-mouseYLook, 0f, 0f); 
     }
 }