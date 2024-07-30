using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float XSensitivity = 3;
    public float YSensitivity = 3;
    public float orbitDamping = 10;
    public Vector3 offset;

    public Vector3 localRot;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        transform.position = target.position;

        localRot.x += Input.GetAxis("Mouse X") * XSensitivity;
        localRot.y -= Input.GetAxis("Mouse Y") * YSensitivity;

        localRot.y = Mathf.Clamp(localRot.y, -20f, 15f);

        Quaternion QT = Quaternion.Euler(localRot.y, localRot.x, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, QT, Time.deltaTime * orbitDamping);
    }

}
