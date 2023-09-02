using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float xAxis;
    public float zAxis;

    public float speed;
    public float actualSpeed;
    public float acceleration;
    public float turningSpeed;
    public float gravityVar=10f;
    public float gravity;

    private bool sideStepL;
    private bool sideStepR;
    public float sideStepSpeed;
    public float sideStepTime;
    private float sideStepTimer;
    private bool isSideStep;
    int stepSign;

    public bool boostButton;
    public float boostSpeed;
    public float boostLimit = 100;
    public float maxBoost;
    public float boostLossMultiplier;
    public float boostGainMultiplier;

    public float minTurn;
    public float maxTurn;

    private bool jumpButton;
    public float jumpForce;
    public float fallingSpeed= -15f;
    public int jumpCount;


    public Rigidbody rb;
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask groundLayer;
    public float rayDistance;

    public GameObject propulsionNormal;
    public GameObject propulsionBoost;
    public GameObject SpeedVisualEffect;

    public float speedLossTimer;
    public float speedLossTime = 2;
    public float speedLossMultiplier;
    public bool collision = false;
    public float hazardDamage;

    private AudioSource idle;
    public AudioSource movingSound;
    public AudioSource boostSound;

    //-----CUMPLE BERTA---------


    private void Awake()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody>();
        idle = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetInput();
        SideStep();
        //SideStepTest();
        Boosting();
        Jump();
        Collision();
        SoundEffects();
    }
    private void FixedUpdate()
    {
        GroundCheck();
        Movement();
    }

    private void GetInput()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");
        boostButton = Input.GetKey(KeyCode.LeftShift);
        sideStepL = Input.GetKeyDown(KeyCode.Q);
        sideStepR = Input.GetKeyDown(KeyCode.E);
        jumpButton = Input.GetButtonDown("Jump");
    }

    private void Movement()
    {
        float velocityChange = Vector3.Dot(Vector3.up, transform.forward);
        
        if (velocityChange > 0) acceleration = 1 - Mathf.Abs(velocityChange);
        if(velocityChange < 0) acceleration = 1 + Mathf.Abs(velocityChange);
        actualSpeed = speed * acceleration;
        actualSpeed = Mathf.Clamp(actualSpeed, speed, 500000);

        if (zAxis > 0)
        {
            rb.AddForce((zAxis * transform.forward).normalized * actualSpeed, ForceMode.Acceleration);
            propulsionNormal.SetActive(true);
        }
        else propulsionNormal.SetActive(false);
        if (!GroundCheck())
        {
            gravity += gravityVar * Time.deltaTime;
            rb.AddForce(transform.up * gravity, ForceMode.Acceleration);

            //----------------My Way-------------------------
            Quaternion airRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, airRotation, Time.deltaTime * 2);

            //----------------Mateu Way----------------------
            Quaternion fallingRot = Quaternion.Euler(50, transform.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, fallingRot, Time.deltaTime);
        }
        rb.AddTorque((xAxis * transform.up).normalized * turningSpeed, ForceMode.VelocityChange);
        RaycastHit hit;
        if(Physics.Raycast(groundCheck.position + transform.up, -transform.up, out hit, rayDistance, groundLayer))
        {
            //--------------Mateu Way----------------
            //Vector3 crossProduct = Vector3.Cross(transform.right, hit.normal);
            //transform.rotation = Quaternion.LookRotation(crossProduct);
            //--------------My Way-------------------
            Quaternion normalRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, normalRotation, Time.deltaTime * 20);
        }
    }
    /*private void SideStepTest()
    {
        bool leftInput = Input.GetKeyDown(KeyCode.A);
        bool rightInput = Input.GetKeyDown(KeyCode.D);
        if (leftInput)
        {
            stepCountL++;
            stepCountR = 0;

        }
        else if (rightInput)
        {
            stepCountR++;
            stepCountL = 0;
        }

        if(stepCountL > 0)
        {
            stepTimer += Time.deltaTime;

            if(stepCountL > 1 && stepTimer < 0.15f)
            {
                stepSign = -1;
                stepCountL = 0;
                stepTimer = 0;
            }
            else if(stepTimer > 0.15f)
            {
                stepSign = 0;
                stepCountL = 0;
                stepTimer = 0;
            }
        }

        rb.AddForce(transform.right * stepSign * sideStepSpeed, ForceMode.VelocityChange);
    }*/
   
    private void SideStep()
    {
        if (sideStepL)
        {
            stepSign = -1;
            isSideStep = true;
        }
        if (sideStepR)
        {
            stepSign = 1;
            isSideStep = true;
        }


        if (isSideStep)
        {
            sideStepTimer += Time.deltaTime;

            if (sideStepTimer > sideStepTime)
            {
                sideStepTimer = 0;
                isSideStep = false;
                return;
            }

            rb.AddForce(transform.right * sideStepSpeed * stepSign, ForceMode.Impulse);
        }
    }
    private void Boosting()
    {
        if (boostButton && boostLimit > 0 && zAxis > 0)
        {
            rb.AddForce(zAxis * transform.forward * boostSpeed, ForceMode.Acceleration);
            propulsionNormal.SetActive(false);
            propulsionBoost.SetActive(true);
            SpeedVisualEffect.SetActive(true);
            boostLimit -= Time.deltaTime * boostLossMultiplier;
        }
        else if (!boostButton && boostLimit < maxBoost)
        {
             boostLimit += Time.deltaTime * boostGainMultiplier;
            propulsionBoost.SetActive(false);
            propulsionNormal.SetActive(true);
            SpeedVisualEffect.SetActive(false);
        }
    
        else
        {
            propulsionBoost.SetActive(false);
            propulsionNormal.SetActive(true);
            SpeedVisualEffect.SetActive(false);
        }
    }
    private void Jump()
    {
        if (GroundCheck() && jumpButton && jumpCount<=1)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.VelocityChange);
            jumpCount++;
        }
        if (GroundCheck())
        {
            jumpCount = 0;
            gravity = 0;
            rb.useGravity = false;
        }
    }
    private bool GroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, groundRadius, groundLayer);
    }
    void Collision()
    {
        if (collision)
        {
            speedLossTimer += Time.deltaTime;
            if (speedLossTimer < speedLossTime)
            {
                speed = speed * speedLossMultiplier;
            }
            else if (speedLossTimer >= speedLossTime)
            {
                collision = false;
                speed = 1000;
            }
        }
        else if (!collision && speedLossTimer >= speedLossTime)
        {
            speedLossTimer = 0;
            speed = 1000;
        }
    }
    void SoundEffects()
    {
        if (zAxis <= 0.1f)
        {
            idle.enabled = true;
            movingSound.enabled = false;
            boostSound.enabled = false;
        }
        else if (zAxis > 0.1f && !boostButton)
        {
            movingSound.enabled = true;
            idle.enabled = false;
            boostSound.enabled = false;
        }
        else if (boostButton && zAxis > 0.1f)
        {
            movingSound.enabled = true;
            idle.enabled = false;
            boostSound.enabled = true;
        }
    }
}
