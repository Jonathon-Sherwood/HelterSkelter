using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    private BodySwapping bodySwap;
    private CharacterController cc;

    //Allows for climbing
    private bool canClimb;


    // Start is called before the first frame update
    void Start()
    {
        bodySwap = GetComponent<BodySwapping>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((bodySwap.axeBody.activeInHierarchy || bodySwap.defaultBody.activeInHierarchy) && canClimb)
        {
            if (Input.GetKey(KeyCode.E))
            {
                print("climbing");
                cc.Move(new Vector3(0, .2f));
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ladder"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            canClimb = false;
        }
    }
}
