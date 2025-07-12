using UnityEngine;

public class SideEffectsBad : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Assuming PlayerMovement has a method to handle picking up items
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            Destroy(gameObject); // Destroy the pickup after collection
        }
    }
}
