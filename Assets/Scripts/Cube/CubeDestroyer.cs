using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    void Update()
    {
        // Comprueba si el cubo est� fuera del rango visible en el eje Z
        if (transform.position.z < 0f) // Ajusta este valor seg�n tu escena.
        {
            Destroy(gameObject); // Destruye el cubo.
        }
    }
}
