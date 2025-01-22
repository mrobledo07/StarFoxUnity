using UnityEngine;

public class GameObjectDestroyer : MonoBehaviour
{
    void FixedUpdate() // Usamos FixedUpdate para sincronizar con la f�sica
    {

        if (transform.position.z <= 0f) // <= para incluir el punto exacto
        {
            Destroy(gameObject);
        }
    }
}