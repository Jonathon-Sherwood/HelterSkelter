using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    ThirdPersonMovement playerMovement;

    float regularSpeed; //Holds the initial value of the player's speed chosen in ThirdPersonMovement;

    private void Start()
    {
        playerMovement = GetComponent<ThirdPersonMovement>();
        regularSpeed = playerMovement.speed;
    }

    //Function called for lowering player speed
    public void LowerSpeed()
    {
        playerMovement.speed = regularSpeed / 6;
    }

    //Function called for setting player speed to original
    public void ResetSpeed()
    {
        playerMovement.speed = regularSpeed;
    }

    //Function called for increasing player speed
    public void GainSpeed()
    {
        playerMovement.speed = regularSpeed * 3;
    }
}
