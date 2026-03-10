using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private OldInput oldInput;
    private Rigidbody rb;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        oldInput = GetComponent<OldInput>();
        rb = GetComponent<Rigidbody>();
    }

    public void Movement()
    {
        rb.velocity = new Vector3(oldInput.horizontal * speed, rb.velocity.y, oldInput.vertical * speed);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
}
