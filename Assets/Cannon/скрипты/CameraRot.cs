using Unity.VisualScripting;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float sensivity;
    [SerializeField] private float limit;
    private Vector3 offest, StartPosition;
    private float rotationX, rotationY;
    private float StartRotationX, StartRotationY;
    public static bool CanMove;

    void Start()
    {
        StartPosition = transform.position;
        StartRotationX = transform.rotation.eulerAngles.x;
        StartRotationY = transform.rotation.eulerAngles.y;
        CanMove = false;
        limit = Mathf.Abs(limit);
        if (limit > 20) limit = 20;
        offest = new Vector3(0, 0, -8f);

    }
    void Update()
    {
        if (Input.GetButton("Fire1") && CanMove) RotationCamera();
        else if (!CanMove)
        {
            transform.position = StartPosition;
            transform.rotation = Quaternion.Euler(StartRotationX, StartRotationY, 0);
        }
    }
    private void RotationCamera()
    {
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensivity;
        rotationY = Input.GetAxis("Mouse Y") * sensivity;
        rotationY = Mathf.Clamp(rotationY, -10, limit);
        transform.localEulerAngles = new Vector3(rotationY, rotationX, 8);
        transform.position = transform.localRotation * offest + _target.position;
    }
}