using UnityEngine;

public class SideEffectsGood : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
