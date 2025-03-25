using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f;  // Mozg�s sebess�ge
    public float scrollSpeed = 0.1f;  // Zoom sebess�ge

    void Update()
    {
        // Alap WASD mozgat�s
        float horizontal = Input.GetAxis("Horizontal"); // A/D vagy bal/jobb ny�l
        float vertical = Input.GetAxis("Vertical"); // W/S vagy fel/le ny�l

        Vector2 moveDirection = new Vector3(horizontal, vertical);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
