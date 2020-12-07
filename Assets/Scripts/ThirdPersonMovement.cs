using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ThirdPersonMovement : MonoBehaviour
{
    CharacterController controller;
    Transform cam;
    CinemachineFreeLook cinemachine;
    BodyMenu bodyMenu;

    [Tooltip("Character's Movement Speed in Meters per Second")]
    public float speed = 6f;

    [Tooltip("Character facing movement direction smoothness")]
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool canMove = true; //Freezes player movement and camera control

    //Allows for the cinemachine camera to return to original speed
    float ySpeedStart;
    float xSpeedStart;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = GameObject.Find("Main Camera").transform;
        cinemachine = GameObject.Find("ThirdPersonCamera").GetComponent<CinemachineFreeLook>();
        bodyMenu = GetComponent<BodyMenu>();

        ySpeedStart = cinemachine.m_YAxis.m_MaxSpeed; //Sets a speed to be returned to 
        xSpeedStart = cinemachine.m_XAxis.m_MaxSpeed; //Sets a speed to be returned to
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove) //Called by BodyMenu on menu open
        {
            MoveCamera(true); //Allows camera to move
            Movement();
        } else
        {
            MoveCamera(false);
        }
    }

    /// <summary>
    /// Allows control over cinemachine. Deactivates Mouse input when false and slows its speed, returns to Mouse Y/Mouse X when true.
    /// </summary>
    /// <param name="canMoveCamera"></param>
    void MoveCamera(bool canMoveCamera)
    {
        if (canMoveCamera) //Allows the mouse to control the cinemachine
        {
            cinemachine.m_YAxis.m_InputAxisName = "Mouse Y";
            cinemachine.m_XAxis.m_InputAxisName = "Mouse X";
            cinemachine.m_XAxis.m_MaxSpeed = xSpeedStart;
            cinemachine.m_YAxis.m_MaxSpeed = ySpeedStart;

        }
        else //Removes all input but allows the camera to keep moving at a slow pace
        {
            cinemachine.m_YAxis.m_InputAxisName = "";
            cinemachine.m_XAxis.m_InputAxisName = "";
            cinemachine.m_XAxis.m_MaxSpeed = xSpeedStart * bodyMenu.menuTimeScale;
            cinemachine.m_YAxis.m_MaxSpeed = ySpeedStart * bodyMenu.menuTimeScale;
        }
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //Returns -1 to 1 on X axis
        float vertical = Input.GetAxisRaw("Vertical"); //Returns -1 to 1 on Z axis
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized; //Creates a new vector for movement

        //If direction input...
        if (direction.magnitude >= 0.1f)
        {
            //Finds the angle between the x axis to the vector we want to see then converts to degrees
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //Slowly applies the new angle smoothly to prevent jerking motions on player movement
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            //Turns player based on angle of movement
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            //Creates a direction to move relative to the camera
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //...Move the input direction by a speed
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
