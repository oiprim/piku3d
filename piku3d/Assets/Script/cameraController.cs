using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class cameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 3, -5);
    public float sensitivity = 5f, distance = 5f, smoothSpeed = 10f;

    private float xAxis = 15f;
    private float pitch = 0f;

    public float minPitch = -30f, maxPitch = 30f;

    void LateUpdate()
    {
        xAxis += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        Quaternion rotation = Quaternion.Euler(pitch, xAxis, 0);

        Vector3 desiredPosition = player.position + rotation * offset;

        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(player);
    }
}
