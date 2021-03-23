using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private BodySwapping bodySwap;
    private AnimationManager animManager;
    private BodyMenu bodyMenu;


    // Start is called before the first frame update
    void Start()
    {
        bodySwap = GetComponent<BodySwapping>();
        animManager = GetComponent<AnimationManager>();
        bodyMenu = GetComponent<BodyMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if((bodySwap.swordBody.activeInHierarchy || bodySwap.axeBody.activeInHierarchy || bodySwap.scytheBody.activeInHierarchy) && !bodyMenu.bodyMenu.activeInHierarchy)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("swing");
                animManager.AttackAnimation();
            }
        }
    }
}
