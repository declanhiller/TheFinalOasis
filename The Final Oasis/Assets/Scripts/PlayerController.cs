using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject frontTarget;
    Rigidbody rb;
    public float speed = 10f;
    float roll;
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
        pitch = Input.GetAxisRaw("Vertical");
        roll = Input.GetAxisRaw("Roll");

        transform.Rotate(Vector3.up * yaw * 50f * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.left * pitch * 50f * Time.deltaTime, Space.Self);
        transform.Rotate(Vector3.forward * roll * 150f * Time.deltaTime, Space.Self);


        if(Input.GetAxisRaw("Swim") != 0)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if(transform.rotation.z != 0)
        {
            resetRoll();
        }
    }

    void resetRoll()
    {
        //print("resetting roll");

        float step = transform.rotation.z / 2;
        transform.Rotate(Vector3.back * step * Time.deltaTime);
   
    }
}
