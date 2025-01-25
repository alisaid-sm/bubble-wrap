using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontal, 0, vertical).normalized;

        if (movementDirection != Vector3.zero)
        {
            Quaternion rotationTarget = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationTarget, speed * 30 * Time.deltaTime);

            transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        }
    }
}
