using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int damage = 10;
    public float speed = 30f; // Velocidad alta (30 unidades/segundo)
    private ArwingHealth playerHealth;

    private void Start()
    {
        playerHealth = FindFirstObjectByType<ArwingHealth>();
    }

    void Update()
    {
        // Movimiento hacia adelante en el eje Z global
        transform.Translate(-Vector3.forward * speed * Time.deltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealth != null)
            {
                Debug.Log("Player hit by enemy projectile");
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject, 0.5f);
        }
    }
}