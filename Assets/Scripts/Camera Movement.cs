using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 10f;  // Mozgás sebessége
    public float scrollSpeed = 0.1f;  // Zoom sebessége

    void Update()
    {
        // Alap WASD mozgatás
        float horizontal = Input.GetAxis("Horizontal"); // A/D vagy bal/jobb nyíl
        float vertical = Input.GetAxis("Vertical"); // W/S vagy fel/le nyíl

        Vector2 moveDirection = new Vector3(horizontal, vertical);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }
}
