using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject frontTarget;
    GameObject head;
    GameObject placeholderTarget;
    Rigidbody rb;
    Vector3 currentEulerAngles;
    public float turnSpeed = 45f;
    public float speed = 10f;
    float pitch;
    float yaw;
    bool isTurningAround;
    bool isTurningBack;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        frontTarget = GameObject.FindGameObjectWithTag("front target");
        head = GameObject.FindGameObjectWithTag("head");
        placeholderTarget = GameObject.FindGameObjectWithTag("target");
        placeholderTarget.transform.position = new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z+2.5f);
        frontTarget.transform.position = new Vector3(placeholderTarget.transform.position.x, placeholderTarget.transform.position.y, placeholderTarget.transform.position.z);
        isTurningAround = false;
        isTurningBack = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Swim") != 0)
        {

            yaw = Input.GetAxisRaw("Horizontal");
            pitch = -Input.GetAxisRaw("Vertical");
            Vector3 vectorRotations = new Vector2(pitch, yaw);

            if (isTurningBack)
            {
                print("true");
                // need to add logic to turn player back
            }

            if (yaw != 0 && pitch != 0)
            {
                if (transform.eulerAngles.x >= 40 && transform.eulerAngles.x <= 320)
                {
                    float distance1 = transform.eulerAngles.x - 40f;
                    float distance2 = 320f - transform.eulerAngles.x;
                    if (distance1 > distance2)
                    {
                        if (pitch < 0)
                        {
                            vectorRotations = new Vector2(0f, yaw);
                        }
                    } else
                    {
                        if (pitch > 0)
                        {
                            vectorRotations = new Vector2(0f, yaw);
                        }
                    }
                }
            }


            currentEulerAngles += vectorRotations * Time.deltaTime * turnSpeed;
            transform.eulerAngles = currentEulerAngles;

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (transform.eulerAngles.z == 180 && Input.GetAxisRaw("Swim") == 0)
        {
            isTurningAround = true;
        }

        if(isTurningAround)
        {
            if(transform.eulerAngles.z < 0.2)
            {
                isTurningAround = false;
            }

            float speed = 140f;
            if (transform.eulerAngles.z - 0 < 140 * Time.deltaTime)
            {
                speed = 0f;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            }
            transform.eulerAngles -= new Vector3(0, 0, 1 * Time.deltaTime * speed);
            speed = 140f;

            if(Input.GetAxisRaw("Swim") != 0)
            {
                isTurningAround = false;
                isTurningBack = true;
            }
        }

        //is turning around is true when you abruptly interrupt it

    }

}
