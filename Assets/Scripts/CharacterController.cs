using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed;
    public float normalSpeed = 10.0f;
    public float sprintSpeed = 25.0f;
    public float maxSprint = 5.0f;
    float sprintTimer;
    float maxSprintTimer;

    float rotation = 0.0f;
    float camRotation = 0.0f;
    float camRotationSpeed = 1.5f;
    float rotationSpeed = 2.0f;

    GameObject cam;
    Rigidbody myRigidBody;
    

   // private Image StaminaBar = null;
   // private CanvasGroup sliderCanvasGroup = null;
   // private float staminaDrain = 0.5f;
    private float staminaRegen = 0.5f;
    public bool hasRegenerated = true;

     void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        cam = GameObject.Find("Main camera");
        myRigidBody = GetComponent<Rigidbody>();
        sprintTimer = maxSprint;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        }else
        {
            maxSpeed = normalSpeed;
            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                sprintTimer = sprintTimer + Time.deltaTime;
            }
            sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);
        }
        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed + (transform.right * Input.GetAxis("Horizontal") * maxSpeed); 
        myRigidBody.velocity = new Vector3(newVelocity.x, myRigidBody.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        //cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));
        camRotation = Mathf.Clamp(camRotation, -50.0f, 50.0f);


        if (Input.GetKey(KeyCode.LeftShift) == false)
        {
            if (sprintTimer <= maxSprintTimer - 0.01)
            {
                sprintTimer += staminaRegen * Time.deltaTime;
            }
            if (sprintTimer >= maxSprintTimer)
                hasRegenerated = true;

        }


      
       /* void UpdateStamina(int value)
        {
            StaminaBar.fillAmount = sprintTimer / Time.deltaTime;
            if (value == 0)
            {
                sliderCanvasGroup.alpha = 0;
            }
            else
            {
                sliderCanvasGroup.alpha = 1;
            }
        }

      */
            
    }

}
