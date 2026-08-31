using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public int CameraSpeed;
    public float sensitivity;

    private void Update()
    {
        move(1);
    }
    void move(int mode)
    {
        switch (mode)
        {
            case 1:
                FreeCamera();
                break;
        }
    }

    void FreeCamera()
    {
        int forward = (Input.GetKey(KeyCode.W)) ? 1 : (Input.GetKey(KeyCode.S)) ? -1 : 0;
        int up = (Input.GetKey(KeyCode.Space)) ? 1 : (Input.GetKey(KeyCode.LeftShift)) ? -1 : 0;
        int rigth = (Input.GetKey(KeyCode.D)) ? 1 : (Input.GetKey(KeyCode.A)) ? -1 : 0;

        float mouseX;
        float mouseY;

        if (Input.GetKey(KeyCode.Mouse2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            mouseX = 0f;
            mouseY = 0f;
        }

        Vector3 Vector = (transform.forward * forward + transform.up * up + transform.right * rigth);

        transform.position += Vector.normalized * CameraSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, mouseX * sensitivity, Space.World);
        transform.Rotate(Vector3.right, -mouseY * sensitivity, Space.Self);
    }
}