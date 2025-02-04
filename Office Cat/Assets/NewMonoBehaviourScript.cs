using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public List<GameObject> interactionSequence; // List of objects to interact with in order
    private int currentStep = 0; // Current step in the sequence

    public List<GameObject> spritePrefab; // The sprite that will follow the player
    private GameObject spawnedSprite; // Instance of the spawned sprite

    private Transform player; // Reference to the player's transform

    void Update()
    {
        // Check for interactions (e.g., mouse click or key press)
        if (Input.GetMouseButtonDown(0)) // Example: Left mouse click
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                CheckInteraction(hit.collider.gameObject);
            }
        }

        // Make the sprite follow the player if it's spawned
        if (spawnedSprite != null)
        {
            spawnedSprite.transform.position = player.position + new Vector3(1, 1, 0); // Adjust offset as needed
        }
    }

    void CheckInteraction(GameObject interactedObject)
    {
        if (interactedObject == interactionSequence[currentStep])
        {
            currentStep++;

            if (currentStep >= interactionSequence.Count)
            {
                // Sequence completed, spawn the sprite
                SpawnSprite();
            }
        }
    }

    void SpawnSprite()
    {
        if (spritePrefab != null && spawnedSprite == null)
        {
            spawnedSprite = Instantiate(spritePrefab[currentStep], player.position, Quaternion.identity);
        }
    }

    // Call this method when the sprite is placed in the next area
    public void PlaceSprite(GameObject targetArea)
    {
        if (spawnedSprite != null)
        {
            // Move the sprite to the target area
            spawnedSprite.transform.position = targetArea.transform.position;
            spawnedSprite = null; // Clear the reference
        }
    }
}
