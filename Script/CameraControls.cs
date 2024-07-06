using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 0.1f; // Speed at which the camera moves

    void Update()
    {
        // Check if the left mouse button (or touch) is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Move the camera vertically (upwards) based on the moveSpeed
            transform.Translate(Vector3.up * moveSpeed);
        }
    }
}
