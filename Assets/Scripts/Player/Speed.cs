using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    ThirdPersonMovement playerMovement;


    private void Start()
    {
        playerMovement = GetComponent<ThirdPersonMovement>();
    }

    //Function called for lowering player speed
    public void LowerSpeed()
    {
        playerMovement.currentSpeed = playerMovement.slowSpeed;
    }

    //Function called for setting player speed to original
    public void ResetSpeed()
    {
        playerMovement.currentSpeed = playerMovement.speed;
    }

    //Function called for increasing player speed
    public void GainSpeed()
    {
        playerMovement.currentSpeed = playerMovement.fastSpeed;
    }
}
