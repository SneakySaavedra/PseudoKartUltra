using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;

    public float smooth;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        //Vector3 desiredPosition = target.position + transform.TransformPoint(offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smooth);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}
