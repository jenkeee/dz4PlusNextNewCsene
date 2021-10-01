using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraa;
    public float distanceTo= 3;
    public float distanceUp =3;
    public float distanceUp2 = 3;
    public float distanceRight = 3;
    public GameObject pauseMenu;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /* turn.x = Input.GetAxis("Mouse X");
         turn.y = Input.GetAxis("Mouse Y");
         transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);*/
        cameraa.transform.position = transform.position + transform.forward * distanceTo + transform.up * distanceUp;
        cameraa.transform.LookAt(transform.position + transform.right * distanceRight);
        if (pauseMenu.activeSelf) // пусть курсор не лочится если активно меню
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0)) Cursor.lockState = CursorLockMode.Locked;

    }
}
