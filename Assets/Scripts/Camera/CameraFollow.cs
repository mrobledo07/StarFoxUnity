using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float divisor = 1.5f;

    void Update()
    {
        if (target != null)
        {
            Vector3 position = target.position;
            position.x = target.position.x / divisor;
            position.y = target.position.y / divisor;
            position.z = 0;

            transform.position = position;
        }
    }
}
