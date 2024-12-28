using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float verticalSpeed = 80f;
    public float horizontalSpeed = 160f;
    public float maxRotationAngle = 25f; // �ngulo m�ximo de inclinaci�n
    public float rotationSmoothing = 5f; // Suavizado de la rotaci�n

    private float targetRotationX = 0f; // Rotaci�n objetivo en X (inclinaci�n)
    private float targetRotationY = 0f; // Rotaci�n objetivo en Z (alabeo)

    public float limitX = 100.0f;
    public float limitY = 50.0f;

    private float oscillationTime = 0.0f;
    private bool isMoving = false;

    public float oscillationSpeed = 2.5f;    // Velocidad de la oscilaci�n
    public float oscillationAmplitude = 0.05f; // Amplitud de la oscilaci�n


    void Update()
    {
       
        // Movimiento vertical (adelante y atr�s)
        float deltaY = Input.GetAxis("Vertical");
        Vector3 verticalMovement = Vector3.up * deltaY * verticalSpeed * Time.deltaTime;

        // Movimiento horizontal (izquierda y derecha)
        float deltaX = Input.GetAxis("Horizontal");
        Vector3 horizontalMovement = Vector3.right * deltaX * horizontalSpeed * Time.deltaTime;

        if (deltaX != 0 || deltaY != 0) isMoving = true;
        else isMoving = false;

        // Aplicar la traslaci�n (solo la posici�n)
        transform.Translate(verticalMovement + horizontalMovement, Space.World);

        // Limitar la posici�n en X y Y
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -limitX, limitX);
        position.y = Mathf.Clamp(position.y, -limitY, limitY);
        transform.position = position;

        if (transform.position.x == limitX || transform.position.x == -limitX)
        {
            deltaX = 0;
        }

        if (transform.position.y == limitY || transform.position.y == -limitY)
        {
            deltaY = 0;
        }

        // Calcular rotaciones objetivo
        targetRotationX = -deltaX * maxRotationAngle; // Inclinar hacia adelante/atr�s seg�n el movimiento vertical
        targetRotationY = -deltaY * maxRotationAngle; // Inclinar hacia los lados seg�n el movimiento horizontal

        // Suavizar la rotaci�n actual hacia la rotaci�n objetivo
        Quaternion targetRotation = Quaternion.Euler(targetRotationY, 0, targetRotationX);
        Quaternion targetRotation2 = Quaternion.Euler(0, targetRotationX, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation * targetRotation2, rotationSmoothing * Time.deltaTime);

        if (!isMoving)
        {
            Oscillate(transform);
        }
    }

    void Oscillate(Transform transform)
    {
        // Hacer oscilaci�n con una funci�n de seno
        oscillationTime += Time.deltaTime * oscillationSpeed;
        float oscillation = Mathf.Sin(oscillationTime) * oscillationAmplitude;

        // Aplicar la oscilaci�n en el eje Y
        transform.position = new Vector3(transform.position.x,  transform.position.y + oscillation, transform.position.z);
    }
}
