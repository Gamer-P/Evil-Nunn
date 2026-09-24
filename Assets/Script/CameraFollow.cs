using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraFollowObject;

    private void Update() {
        transform.position = cameraFollowObject.position;
    }
}
