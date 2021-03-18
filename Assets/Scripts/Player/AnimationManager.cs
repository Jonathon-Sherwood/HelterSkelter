using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator currentAnimator;
    public Animator[] allAnims;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeAnim(Animator anim)
    {
        currentAnimator = anim;
    }

    public void WalkAnimation(bool isWalking)
    {
        currentAnimator.SetBool("Walking", isWalking);
        print("I'm being called");
        print(isWalking);
    }

}
