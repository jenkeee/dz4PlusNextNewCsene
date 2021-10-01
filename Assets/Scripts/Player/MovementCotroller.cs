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

    [SerializeField] Transform sound_p_steps; // будем обращатся к элементам аудио сурса в цикле фор как к детям в масиве
    AudioSource[] steps;
    int stepscount = 0;
    [SerializeField] AudioSource sound_p_jump;
    public bool sound_jumped;
    int soundTimer;
    [SerializeField] AudioSource sound_p_land;
    [SerializeField] public Collider[] groundChecker;
    [SerializeField] public Collider[] groundCheckerPlayerRoot;
    public bool isJumping;
    [SerializeField] private LayerMask SetMaskWithPlayer; // будем исключать слой с игроком, через так чего не пошло

    void Start()
    {
      cameraTransform = Camera.main.transform;
        steps = new AudioSource[sound_p_steps.childCount];
        for (int i = 0; i < sound_p_steps.childCount; i++)
        {
            steps[i] = sound_p_steps.GetChild(i).GetComponent<AudioSource>();
        }

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



        if (isWalking && isJumping)
        { //  if ( !steps[i].isPlaying) // думаю как правильно указать что любой элемент масива
            if (stepscount >= steps.Length) stepscount = 0;

            for (int i = 0; i < steps.Length; i++)
            {
                if (!steps[i].isPlaying)
                {
                    steps[stepscount].Play();                   
                }
                else steps[stepscount].Stop();

            }
            stepscount++;
        }
        else
        {
            stepscount = 0;             
        }
       
       


        //isJumping = true;
        // transform.position = Vector3.Lerp(transform.position,target.position,speed * Time.deltaTime); // из точки а в точку б
    }
    private void Update()
    {
        if (soundTimer > -1)
            soundTimer--;
        if (Input.GetKeyDown(KeyCode.Space) && isJumping)
        {
            isJumping = false;
            soundTimer = 50;
            transform.parent.GetComponent<Rigidbody>().AddForce(Vector3.up * 30, ForceMode.Impulse);
            if (!sound_p_jump.isPlaying)
            {
                Debug.Log("прыгнул");
                sound_p_jump.Play();             
            }
            else sound_p_jump.Stop();
        }
        else if (!isJumping && soundTimer <=0) sound_jumped = true; // дам таймер, надоел спамить приземление при прыжке
        else if (sound_jumped && isJumping)
        {
            sound_jumped = false;
            if (!sound_p_land.isPlaying)
            {
                sound_p_land.Play();
                Debug.Log("приземлился");               
            }
            else sound_p_land.Stop();
        }
    }
}
