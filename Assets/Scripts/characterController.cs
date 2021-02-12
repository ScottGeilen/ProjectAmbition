using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public GameObject ball;
    public GameObject playerCamera;
    public float regSpeed = 20.0f;
    public float walkSpeed = 20.0f;
    public int sprint = 10;
    public float ballThrowingDistance = 5.0f;
    public float ballThrowingForce = 500.0f;
    private bool holdingBall = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        ball.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * walkSpeed;
        float straffe = Input.GetAxis("Horizontal") * walkSpeed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            walkSpeed = sprint;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) {
            walkSpeed = regSpeed;
        }

        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
        
        if (holdingBall) {
            ball.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            if (Input.GetMouseButtonDown(0)) {
                holdingBall = false;
                ball.GetComponent<Rigidbody>().useGravity = true;
                ball.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * ballThrowingForce);
            }
        }
    }
}
