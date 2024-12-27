using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float verticalSpeed = 20f;
    public float horizontalSpeed = 40f;

    // Update se llama una vez por frame
    void Update()
    {
        // Mover la nave hacia arriba o abajo con las teclas W y S o las flechas
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            float moveVertical = -Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * moveVertical * verticalSpeed * Time.deltaTime);
        }
        // Rotar la nave con las teclas A y D o las flechas
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * moveHorizontal * horizontalSpeed * Time.deltaTime);
        }
      
    }
}
