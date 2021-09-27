using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCotroller : MonoBehaviour
{
       public float speed = 1;
    float horizontal;
    float vertical;
    float jump;

    Vector2 turn;
    private Transform cameraTransform;


    [SerializeField] public Collider[] groundChecker;
    [SerializeField] public Collider[] groundCheckerPlayerRoot;
    bool isJumping;
    [SerializeField] private LayerMask SetMaskWithPlayer; // будем исключать слой с игроком, через так чего не пошло

    void Start()
    {
      cameraTransform = Camera.main.transform;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        groundChecker = Physics.OverlapSphere(transform.parent.position + Vector3.down, 1f);
        groundCheckerPlayerRoot = Physics.OverlapSphere(transform.parent.position + Vector3.down, 1f, SetMaskWithPlayer);
        if (groundChecker.Length - groundCheckerPlayerRoot.Length > 0)
        {
            isJumping = true;
        }
        else isJumping = false;


        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //jump = Input.GetAxis("Jump");

        Vector3 move = new Vector3(horizontal, 0, vertical);
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized;
        move.Set(move.x, 0, move.z);
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        //bool isJumpingnot = true; // !Mathf.Approximately(jump, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
     
        
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(-turn.y, turn.x, 0);
        transform.parent.rotation = Quaternion.Euler(0, turn.x, 0);


        if (isWalking)            
            transform.parent.position += move.normalized * speed * Time.deltaTime;
        else transform.parent.position += new Vector3(0, 0, 0);

                
        
        //isJumping = true;
        // transform.position = Vector3.Lerp(transform.position,target.position,speed * Time.deltaTime); // из точки а в точку б
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping)
        {
            isJumping = false;

            transform.parent.GetComponent<Rigidbody>().AddForce(Vector3.up * 30, ForceMode.Impulse);
        }
    }
}
