using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    [SerializeField] public bool doubleVision;
    [SerializeField] public bool isHeadBobbing;
    public bool isMoving = false;
    public float walkingSpeed;
    public float runningSpeed;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public GameObject secretView;
    public AudioSource staticNoise;
    public Animator cameraAnim;
    public GameObject walkSound, runSound;


    public bool enableZoom = true;
    public bool holdToZoom = false;
    public bool holdSprint = true;
    public KeyCode zoomKey = KeyCode.Mouse1;
    public float zoomFOV = 30f;
    public float zoomStepTime = 5f;
    public float fov = 60f;
    
    private bool isZoomed = false;
    private bool isRunning;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
    float randomNumber;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraAnim.SetTrigger("idle");
    }

    void Update()
    {
        if(doubleVision)
        {
            if (Time.frameCount % 3 == 0)
            {
                VisionFlicker();
            }
        }
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W);
        isMoving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);

        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxisRaw("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxisRaw("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;

        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
        moveDirection.y = movementDirectionY;
        moveDirection.Normalize();

        if(isRunning)
        {
            isZoomed = false;
            moveDirection *= 2.1f;
        }
        HeadbobControl(isMoving, isRunning);


        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        
        // Move the controller

        // if (!characterController.isGrounded)
        // {
        moveDirection.y -= gravity * Time.deltaTime;
        // }

        // if (canMove)
        // {
        moveDirection = moveDirection * Time.deltaTime;
        characterController.Move(moveDirection);
        // } 

        // Player and Camera rotation
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX , 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
                CameraRotation();


        if (enableZoom)
        {
            // Changes isZoomed when key is pressed
            // Behavior for hold to zoom
            if(holdToZoom && !isRunning)
            {
                if(Input.GetKeyDown(zoomKey) && !isRunning)
                {
                    isZoomed = true;
                    isRunning = false;
                }
                else if(Input.GetKeyUp(zoomKey))
                {
                    isZoomed = false;
                }
            }
            // Lerps camera.fieldOfView to allow for a smooth transistion
            if(isZoomed && !isRunning)
            {
                playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, zoomFOV, zoomStepTime * Time.deltaTime);
            }
            else if(!isZoomed && !isRunning)
            {
                playerCamera.fieldOfView = Mathf.Lerp(playerCamera.fieldOfView, fov, zoomStepTime * Time.deltaTime);
            }
        }
        
    }

    void VisionFlicker()
    {
        randomNumber = Random.Range(0, 14);
            if(randomNumber < 13)
            {
                secretView.SetActive(false);
                staticNoise.Pause();
                playerCamera.cullingMask &=  ~(1 << LayerMask.NameToLayer("secretView"));
            }
            else
            {
                secretView.SetActive(true);
                staticNoise.Play(0);
                playerCamera.cullingMask |= 1 << LayerMask.NameToLayer("secretView"); 
            }
    }

    void CameraRotation()
    {
        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
    }

    void HeadbobControl(bool isMoving, bool isRunning)
    {
            if(isMoving && !isRunning)
            {
                walkSound.SetActive(true);
                runSound.SetActive(false);        
            }
            // cameraAnim.ResetTrigger("idle");
            // cameraAnim.ResetTrigger("sprint");
            // cameraAnim.SetTrigger("walk");
            if (isMoving && isRunning)
            {
                walkSound.SetActive(false);
                runSound.SetActive(true);
            // cameraAnim.ResetTrigger("walk");
            // cameraAnim.ResetTrigger("idle");
            // cameraAnim.SetTrigger("sprint");
            }
            if(!isMoving)
            {
                walkSound.SetActive(false);
                runSound.SetActive(false);
            }
    }
}