using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySwapping : MonoBehaviour
{
    private Speed speed;
    private ThirdPersonMovement playerMovement;

    //Statemachine
    public enum BodyStates { Default, Sword, Axe, Scythe, Legs, Projectile }
    public BodyStates currentState = BodyStates.Default;

    //Body Types
    public GameObject defaultBody;
    public GameObject swordBody;
    public GameObject axeBody;
    public GameObject scytheBody;
    public GameObject legsBody;
    public GameObject projectileBody;
    public List<GameObject> bodyCombinations;

    //Animation
    private AnimationManager animManager;

    //Body Parts
    public GameObject rarm, larm, lleg, rleg, head;

    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<Speed>();
        playerMovement = GetComponent<ThirdPersonMovement>();
        bodyCombinations.Add(defaultBody);
        bodyCombinations.Add(swordBody);
        bodyCombinations.Add(axeBody);
        bodyCombinations.Add(scytheBody);
        bodyCombinations.Add(legsBody);
        bodyCombinations.Add(projectileBody);
        animManager = GetComponent<AnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(larm.GetComponent<DragDrop>().isChild && rarm.GetComponent<DropSlot>().hasChild && !larm.GetComponent<DropSlot>().hasChild && !swordBody.activeInHierarchy)
        {
            BodySwapSword();
        }

        else if(lleg.GetComponent<DropSlot>().hasChild && rleg.GetComponent<DropSlot>().hasChild && !legsBody.activeInHierarchy)
        {
            BodySwapLegs();
        }

        else if (rarm.GetComponent<DropSlot>().hasChild && larm.GetComponent<DropSlot>().hasChild && !scytheBody.activeInHierarchy)
        {
            BodySwapScythe();
        }

        else if(rarm.GetComponent<DropSlot>().hasChild && rleg.GetComponent<DragDrop>().isChild && !larm.GetComponent<DragDrop>().isChild && !axeBody.activeInHierarchy)
        {
            BodySwapAxe();
        } 

        else if(head.GetComponent<DragDrop>().isChild && (rarm.GetComponent<DropSlot>().hasChild || larm.GetComponent<DropSlot>().hasChild) && !projectileBody.activeInHierarchy)
        {
            BodySwapProjectile();
        }

        else
        {
            if (!defaultBody.activeInHierarchy && !lleg.GetComponent<DropSlot>().hasChild && !rleg.GetComponent<DropSlot>().hasChild && !rarm.GetComponent<DropSlot>().hasChild && !larm.GetComponent<DropSlot>().hasChild)
            {
                BodySwapDefault();
            }
        }


        switch (currentState)
        {
            case BodyStates.Default:
               // BodySwapDefault();
                break;
            case BodyStates.Sword:
              //  BodySwapSword();
                break;
            case BodyStates.Axe:
               // BodySwapAxe();
                break;
            case BodyStates.Scythe:
               // BodySwapScythe();
                break;
            case BodyStates.Legs:
               // BodySwapLegs();
                break;
            case BodyStates.Projectile:
                //BodySwapProjectile();
                break;
        }
    }



    //Allows for multiple reactions on state change
    public void ChangeState(BodyStates state)
    {
        Transformation();
        currentState = state;
    }

    //Removes any active body combination for replacement
    public void Transformation()
    {
        foreach (GameObject i in bodyCombinations)
        {
            if (i.activeInHierarchy)
            {
                i.SetActive(false);
            }
        }
    }

    public void BodySwapDefault()
    {
        ChangeState(BodyStates.Default);
        defaultBody.SetActive(true);
        speed.ResetSpeed();
        playerMovement.currentJumpHeight = playerMovement.jumpHeight;

        //Sets the animator of the animation manager to default
        animManager.ChangeAnim(animManager.allAnims[0]);
    }

    public void BodySwapSword()
    {
        ChangeState(BodyStates.Default);
        swordBody.SetActive(true);
        speed.ResetSpeed();
        playerMovement.currentJumpHeight = playerMovement.jumpHeight;

        //Sets the animator of the animation manager to sword
        animManager.ChangeAnim(animManager.allAnims[5]);
    }

    public void BodySwapAxe()
    {
        ChangeState(BodyStates.Default);
        axeBody.SetActive(true);
        speed.LowerSpeed();
        playerMovement.currentJumpHeight = 0;

        //Sets the animator of the animation manager to axe
        animManager.ChangeAnim(animManager.allAnims[2]);
    }

    public void BodySwapScythe()
    {
        ChangeState(BodyStates.Default);
        scytheBody.SetActive(true);
        speed.LowerSpeed();
        playerMovement.currentJumpHeight = 0;

        //Sets the animator of the animation manager to scythe
        animManager.ChangeAnim(animManager.allAnims[4]);
    }

    public void BodySwapLegs()
    {
        ChangeState(BodyStates.Default);
        legsBody.SetActive(true);
        speed.GainSpeed();
        playerMovement.currentJumpHeight = playerMovement.jumpHeight * 2;

        //Sets the animator of the animation manager to legs
        animManager.ChangeAnim(animManager.allAnims[1]);
    }

    public void BodySwapProjectile()
    {
        ChangeState(BodyStates.Default);
        projectileBody.SetActive(true);
        speed.ResetSpeed();
        playerMovement.currentJumpHeight = playerMovement.jumpHeight;

        //Sets the animator of the animation manager to projectile
        animManager.ChangeAnim(animManager.allAnims[3]);
    }

}
