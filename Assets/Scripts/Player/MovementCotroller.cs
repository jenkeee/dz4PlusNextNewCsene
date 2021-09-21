using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCotroller : MonoBehaviour
{
       public float speed = 1;
    float horizontal;
    float vertical;

    Vector2 turn;
    private Transform cameraTransform;
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(horizontal, 0, vertical);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.Set(move.x, 0, move.z);
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
     
        
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(turn.y, -turn.x, 0);
        transform.parent.rotation = Quaternion.Euler(0, -turn.x, 0);


        if (isWalking)            
            transform.parent.position += move.normalized * speed * Time.deltaTime;
        else transform.parent.position += new Vector3(0, 0, 0);

        // transform.position = Vector3.Lerp(transform.position,target.position,speed * Time.deltaTime); // из точки а в точку б
    }
}
