using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject frontTarget;
    Rigidbody rb;
    Vector3 currentEulerAngles;
    public float turnSpeed = 45f;
    public float speed = 10f;
    float pitch;
    float yaw;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        frontTarget = GameObject.FindGameObjectWithTag("front target");
        frontTarget.transform.position = new Vector3(gameObject.transform.position.x+0.243f, gameObject.transform.position.y, gameObject.transform.position.z+2);
    }

    // Update is called once per frame
    void Update()
    {
        yaw = Input.GetAxisRaw("Horizontal");
        pitch = -Input.GetAxisRaw("Vertical");
        Vector3 vectorRotations = new Vector3(pitch, yaw);
        if (yaw != 0 && pitch != 0)
        {
            if (transform.eulerAngles.x >= 40 && transform.eulerAngles.x <= 320)
            {
                float distance1 = transform.eulerAngles.x - 40f;
                float distance2 = 320f - transform.eulerAngles.x;
                if(distance1 > distance2)
                {
                    vectorRotations = new Vector3(0f, yaw);
                } else
                {
                    vectorRotations = new Vector3(0f, yaw);
                }
            }
        }
        currentEulerAngles += vectorRotations * Time.deltaTime * turnSpeed;
        transform.eulerAngles = currentEulerAngles;

        //transform.eulerAngles = new Vector3(gameObject.transform.rotation.x + (pitch), gameObject.transform.rotation.y + (yaw), gameObject.transform.rotation.z);

        if (Input.GetAxisRaw("Swim") != 0)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }

}
