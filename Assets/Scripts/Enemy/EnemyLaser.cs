// En el script del enemigo:
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    public int damage = 20; // Este l�ser hace m�s da�o

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ArwingHealth arwingHealth = other.GetComponent<ArwingHealth>();
            if (arwingHealth != null)
            {
                arwingHealth.TakeDamage(damage); // Pasa 20 de da�o
            }
            Destroy(gameObject);
        }
    }
}