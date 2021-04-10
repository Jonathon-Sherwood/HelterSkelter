using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BodyMenu : MonoBehaviour
{
    [Range(0,1), Tooltip("Set amount of slowdown you want the world to become when looking through body menu")]
    public float menuTimeScale;

    public GameObject bodyMenu;
    ThirdPersonMovement thirdPersonMovement;


    //Used for locking the player for a moment after transforming
    public GameObject clouds;
    public float frozenCountdown;
    private float currentTimeLeft;
    private bool transforming;

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonMovement = GetComponent<ThirdPersonMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        MenuOpen();
    }

    public void MenuOpen()
    {
        //While holding tab, the cursor shows up, player movement is restricted, and time slows
        if(Input.GetKey(KeyCode.Tab))
        {
            bodyMenu.SetActive(true);
            thirdPersonMovement.canMove = false;
            thirdPersonMovement.canJump = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = menuTimeScale;
            transforming = true;
        }
        //On release of Tab, the cursor disappears, the player can move again, and time returns to normal
        else
        {
            if(transforming)
            {
                currentTimeLeft = frozenCountdown;
                clouds.SetActive(true);
                transforming = false;
            }
            currentTimeLeft -= Time.deltaTime;
            if (currentTimeLeft < 0)
            {
                //Able to interact
                thirdPersonMovement.canMove = true;
                thirdPersonMovement.canJump = true;
                clouds.SetActive(false);
            }
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            bodyMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }





}
