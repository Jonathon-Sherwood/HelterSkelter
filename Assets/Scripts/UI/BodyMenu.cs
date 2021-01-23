using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMenu : MonoBehaviour
{
    [Range(0,1), Tooltip("Set amount of slowdown you want the world to become when looking through body menu")]
    public float menuTimeScale;

    public GameObject bodyMenu;
    ThirdPersonMovement thirdPersonMovement;

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
        if(Input.GetKey(KeyCode.Tab))
        {
            bodyMenu.SetActive(true);
            thirdPersonMovement.canMove = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = menuTimeScale;
        }
        else
        {
            bodyMenu.SetActive(false);
            thirdPersonMovement.canMove = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }
}
