using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls all movement related to the car.
public class CarMovement : MonoBehaviour
{
    // ----Variables----
    [SerializeField] CameraWalls camWalls;

    [Header("Speed Variables")]
    [SerializeField] float rotateSpeed;
    [SerializeField] float moveSpeed = 4;


    [Header("Drift Variables")]
    public bool isDriftingRight;
    public bool isDriftingLeft;

    float vertical;
    float horizontal;

    // ----Methods----
    // Update is called once per frame
    void Update()
    {
        CamWalls();

        // Assigns Vectors based on input values.
        GetInput();

        // Prohibits rotation when not moving.
        if (vertical != 0)
        {
            transform.Rotate(new Vector3(0, 0, horizontal
                * rotateSpeed * Time.deltaTime));
        }

        // Creates vector for movement.
        Vector3 move = new Vector3(0, vertical, transform.position.z);

        // Moves car forward/backwards
        transform.Translate(move * moveSpeed * Time.deltaTime);

        IsDrifting();
    }

    // Checks imput values to determine if drifting.
    void IsDrifting()
    {
        if (vertical != 0 && horizontal > 0)
        {
            isDriftingRight = true;
        }
        else { isDriftingRight = false; }

        if (vertical != 0 && horizontal < 0)
        {
            isDriftingLeft = true;
        }
        else { isDriftingLeft = false; }
    }

    void GetInput()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    void CamWalls()
    {
        Vector3 vehiclePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        // Left & Right
        if (transform.position.x > camWalls.width / 2)
        {
            vehiclePosition.x = camWalls.width / 2;
        }
        if (transform.position.x < -camWalls.width / 2)
        {
            vehiclePosition.x = -camWalls.width / 2;
        }

        // Top & Bottom
        if (transform.position.y > camWalls.height / 2)
        {
            vehiclePosition.y = camWalls.height / 2;
        }
        if (transform.position.y < -camWalls.height / 2)
        {
            vehiclePosition.y = -camWalls.height / 2;
        }

        transform.position = vehiclePosition;
    }

}
