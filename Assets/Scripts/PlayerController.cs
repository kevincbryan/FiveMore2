using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    public bool isMoving = false;
    public bool facingRight = false;
    public bool facingUp = false;
    private Rigidbody2D rb;


    public GameObject triggerArea;
    private bool isFiring = false;
    public float fireDuration = .5f;


    private BedDetector bed;
    private Transform bedLoc;

    public bool playerStopped;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Debug.Log("PlayerController is running");

        bed= FindObjectOfType<BedDetector>();
        bedLoc = bed.transform;
        gameObject.transform.position = bedLoc.transform.position;

        //Debug.Log ("Bed is at " + bedLoc.transform.position);

    
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStopped == false)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    facingRight = true;
                }
                else
                {
                    facingRight = false;
                }

                if (Input.GetAxis("Vertical") > 0)
                {
                    facingUp = true;
                }
                else
                {
                    facingUp = false;
                }


                isMoving = true;
                //Debug.Log("getting Input " + Input.GetAxis ("Horizontal") + Input.GetAxis ("Vertical"));
                Move();
            }
            else
            {
                //Debug.Log("No input");
                isMoving = false;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                if (isFiring == false)
                {
                    ActivateTrigger();
                }
            }
        }
     
    }

    private void Move()
    {
        
        float moveRight = 0;
        float moveForward = 0;

        moveForward += Input.GetAxis("Vertical");
        moveRight += Input.GetAxis("Horizontal");
        //Debug.Log("Move Forward is: " + moveForward + "MoveRight is: " + moveRight);

        Vector3 moveVector  = ((transform.up * moveForward) + (transform.right * moveRight));

        moveVector.Normalize();
        moveVector *= playerSpeed * Time.deltaTime;
        transform.position += moveVector;
    }


    private void ActivateTrigger ()
    {
        triggerArea.SetActive(true);
        isFiring = true;
        Invoke("DeactivateTrigger", fireDuration);
    }

    private void DeactivateTrigger ()
    {
        triggerArea.SetActive(false);
        isFiring = false;
    }
}
