using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInput : MonoBehaviour
{
    public float PlayerSpeed = 2f;

    //Camera Variables 
    public Transform cameraObject;
    public float AimSpeedX = 30f;
    public float AimSpeedY = 20f;
    public float PitchMin = -89.9f;
    public float PitchMax = 89.9f;

    public float StepDown = 0.2f;

    float GravityVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;

        GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        float Right = Input.GetAxis("Horizontal");
        float Forward = Input.GetAxis("Vertical");

        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = -Input.GetAxis("Mouse Y");

        float dt = Time.deltaTime;

        CharacterController controller = GetComponent<CharacterController>();
        Transform trans = GetComponent<Transform>();

        if (cameraObject != null)
        {

            Vector3 YawRotation = Vector3.zero;
            YawRotation.y = MouseX * AimSpeedX * dt;
            trans.Rotate(YawRotation);

            float PitchRotation = MouseY * AimSpeedY * dt;
            PitchRotation = Mathf.Clamp(cameraObject.localRotation.x + PitchRotation, PitchMin, PitchMax) - cameraObject.localRotation.x;

            Vector3 PitchRotationVec = Vector3.zero;
            PitchRotationVec.x = PitchRotation;

            cameraObject.Rotate(PitchRotationVec);
        }

        if (controller != null)
        {
            Vector3 moveDelta = Vector3.zero;
            moveDelta += transform.right * Right * PlayerSpeed * dt;
            moveDelta += transform.forward * Forward * PlayerSpeed * dt;

            RaycastHit hit;

            if(controller.isGrounded && Physics.Raycast(transform.position + moveDelta + (Vector3.down * controller.height/2), Vector3.down, out hit, StepDown))
            {
                moveDelta += Vector3.down * StepDown;
            }
            else
            {
                GravityVelocity += Physics.gravity.y * dt;
                moveDelta += Vector3.up * GravityVelocity * dt;
            }

            controller.Move(moveDelta);
            if(controller.isGrounded)
            {
                GravityVelocity = 0f;
            }
        }
    }
}
