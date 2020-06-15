using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    GameObject head;
    // Start is called before the first frame update
    void Start()
    {
        head = GameObject.FindGameObjectWithTag("Head");
    }

    // Update is called once per frame
    void Update()
    {

        float xInput = 0;
        float yInput = 0;
        xInput = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        yInput = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        //head.transform.rotation = Quaternion.Euler(head.transform.rotation.eulerAngles.x - 1, head.transform.rotation.eulerAngles.y + yInput, head.transform.rotation.eulerAngles.z);
        head.transform.Rotate(new Vector3(-xInput, 0, -yInput));
    }

}
