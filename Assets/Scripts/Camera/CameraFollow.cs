using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public Vector3 offset; // Offset from the target
    public float followSpeed = 10f; // Speed at which the camera follows the target
    public float rotationSpeed = 5f; // Speed at which the camera rotates
    public float speedMultiplier = 0.5f; // Multiplicador para ajustar el retardo seg�n la velocidad de la nave

    void LateUpdate()
    {
        if (target != null)
        {
            // Calcula la posici�n deseada
            Vector3 desiredPosition = target.position + target.rotation * offset;

            // Ajusta la velocidad de seguimiento seg�n la velocidad de la nave
            float dynamicSpeed = followSpeed + (target.GetComponent<Rigidbody>().linearVelocity.magnitude * speedMultiplier);

            // Suaviza el movimiento hacia la posici�n deseada
            transform.position = Vector3.Lerp(transform.position, desiredPosition, dynamicSpeed * Time.deltaTime);

            // Rotaci�n suave hacia la nave
            Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
