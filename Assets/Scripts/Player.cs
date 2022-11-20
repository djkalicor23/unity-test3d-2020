using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGrounded) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    // FixedUpdate is called once every physics update
    private void FixedUpdate() {
        if (jumpKeyWasPressed) {
            rigidbodyComponent.AddForce(Vector3.up * 10, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);
    }

    private void OnCollisionEnter() {
        isGrounded = true;
    }

    private void OnCollisionExit() {
        isGrounded = false;
    }
}
