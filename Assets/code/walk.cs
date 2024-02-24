using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

/// <summary>
/// Half of the code was stolen from some cool dudes, that made guides
/// Other half was made when I was drunk, because of that, I don`t know how the heck some of this shit work
/// </summary>

public class walk : MonoBehaviour
{
    //For body and weapon turn
    public Vector3 turn;
    public Vector3 weaponTurn;
    public Vector3 headTurn;
    [SerializeField] float maxWeaponBobling = 10f;
    [SerializeField] float minWeaponTurn = -25f;
    [SerializeField] float maxWeaponTurn = 15f;
    [SerializeField] float minBodyTurn = -40f;
    [SerializeField] float maxBodyTurn = 40f;
    [SerializeField] Gun gunInstance;
    Gun pepsi;
    public GameObject mover;
    [SerializeField] Transform cam;
    [SerializeField] Transform hands;
    [SerializeField] Transform head;
    [SerializeField] Transform gun;
    [SerializeField] private LayerMask groundMask;
    //idk
    private Camera topDownCamera;

    bool doesWeaponGetToItsMaxBobling = false;

    private Vector3 offset;

    public Vector3 deltaMove;
    public Rigidbody rigid;
    public float mouseSensitivity = 1f;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    [SerializeField] float walkSpeed = 5f;
    float lookSpeed = 5f;
    bool amIMoving = false;
    CameraControl cameraControl;

    public float minWeaponTurnX;
    public float maxWeaponTurnX;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        pepsi = gameObject.GetComponent<Gun>();
        rigid = GetComponent<Rigidbody>();
        cameraControl = GetComponent<CameraControl>();
        topDownCamera = Camera.main;
        minWeaponTurnX = minWeaponTurn - 5f;
        maxWeaponTurnX = maxWeaponTurn - 5f;


    }

    // Update is called once per frame
    void Update()
    {
        MouseMove();
        BodyMove();
    }

    private void BodyMove()
    {
        //input
        float horInput = Input.GetAxisRaw("Horizontal");
        float verInput = Input.GetAxisRaw("Vertical");

        //local to camera transform
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        //To bound camera to the ground
        camForward.y = 0;
        camRight.y = 0;

        //Relative to camera movement
        Vector3 forwardRelative = Vector3.Normalize(verInput * camForward);
        Vector3 rightRelative = Vector3.Normalize(horInput * camRight);
        Vector3 moveDir = forwardRelative * moveSpeed + rightRelative * moveSpeed;

        //Make shit moving
        rigid.velocity = new Vector3(moveDir.x, rigid.velocity.y, moveDir.z);
    }

    private void MouseMove()
    {
        //Body rotation
        turn.x += Input.GetAxis("Mouse X") * mouseSensitivity;

        //Weapon rotation
        weaponTurn.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        weaponTurn.y += Input.GetAxis("Mouse Y") * mouseSensitivity;//For normal work flow of this code - you are supposed to make y turn half of the head y turn
        //This code will shit it self, when you going to add aiming 
        //Maxing weapon rotation
        weaponTurn.x = Mathf.Clamp(weaponTurn.x, minWeaponTurnX, maxWeaponTurnX);
        weaponTurn.y = Mathf.Clamp(weaponTurn.y, minWeaponTurn, maxWeaponTurn);
        
        hands.transform.localRotation = Quaternion.Euler(Mathf.Clamp(weaponTurn.y, minWeaponTurn, maxWeaponTurn), Mathf.Clamp(weaponTurn.x, minWeaponTurn, maxWeaponTurn), 0);

        HeadRotation();
        BodyRotation();




    }
    private void BodyRotation()
    {
        if (weaponTurn.x >= maxWeaponTurn || weaponTurn.x <= minWeaponTurn || Input.GetKey(KeyCode.Q))
        {
            //Head rotation small power
            turn.x += Input.GetAxis("Mouse X") * mouseSensitivity / 8f;

            //This stuff slightly tilts body, when you move your weapon
            mover.transform.localRotation = Quaternion.Euler(turn.y, turn.x, turn.z);
        }
        else
        {
            //Head rotation small power
            turn.x += Input.GetAxis("Mouse X") * mouseSensitivity / 15f;

            //This stuff slightly tilts body, when you move your weapon
            mover.transform.localRotation = Quaternion.Euler(turn.y, turn.x, turn.z);
        }
    }

    private void HeadRotation()
    {
        if (weaponTurn.y >= maxWeaponTurn || weaponTurn.y <= minWeaponTurn || Input.GetKey(KeyCode.Q))
        {
            //Head rotation FULL power
            headTurn.y += (Input.GetAxis("Mouse Y") * mouseSensitivity);

            //Maxing it
            headTurn.y = Mathf.Clamp(headTurn.y, -30f, 40f);

            //This stuff goes full out, when weapon goes to its max point
            head.transform.localRotation = Quaternion.Euler(-headTurn.y, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z);
        }
        else
        {
            //Head rotation smaller one power
            headTurn.y += (Input.GetAxis("Mouse Y") * mouseSensitivity) / 3;

            //Maxing it
            headTurn.y = Mathf.Clamp(headTurn.y, -30f, 40f);

            //This stuff slightly tilts head, when you move your weapon
            head.transform.localRotation = Quaternion.Euler(-headTurn.y, gameObject.transform.localRotation.y, gameObject.transform.localRotation.z);
        }
    }
    //for aiming tran -5 2605 3 rot 0, -5 -19

}
