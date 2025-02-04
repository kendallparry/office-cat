using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public List<GameObject> interactionSequence; // List of objects to interact with in order
    private int currentStep = 0; // Current step in the sequence

    public List<GameObject> spritePrefab; // The sprite that will follow the player
    private GameObject spawnedSprite; // Instance of the spawned sprite

    private Transform player; // Reference to the player's transform
    public LayerMask layers;

    void Start()
    {
        // Find the player object and assign its transform
        player = GameObject.FindGameObjectWithTag("player").transform;
        if (player == null)
        {
            Debug.LogError("Player not found! Make sure the player has the 'player' tag.");
        }
    }

    void Update()
    {
        // Check for player input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key pressed. Checking for interactions...");
            CheckForInteraction();
        }

        // Make the sprite follow the player if it's spawned
        if (spawnedSprite != null)
        {
            spawnedSprite.transform.position = player.position + new Vector3(1, 1, 0); // Adjust offset as needed
        }
    }

    void CheckForInteraction()
    {
        // Check for interactions near the player
        Collider2D hit = Physics2D.OverlapCircle(player.position, 2f, layers);

        if (hit != null && hit.CompareTag("player")==false)
        {
            Debug.Log("Hit detected: " + hit.gameObject.name);
            CheckInteraction(hit.gameObject);
        }
        else
        {
            Debug.Log(hit);
            Debug.Log("No interactable object detected.");
        }
    }

    void CheckInteraction(GameObject interactedObject)
    {
        Debug.Log(interactedObject + "Rahhhhhhhhhhhhhhhhhh" + interactionSequence[currentStep]);
        if (interactedObject == interactionSequence[currentStep])
        {
            Debug.Log("Correct interactable object detected: " + interactedObject.name);
            currentStep++;
            Debug.Log("Interaction sequence completed.");
            // Sequence completed, spawn the sprite
            Destroy(spawnedSprite);
                SpawnSprite();
        }
        else
        {
            Debug.Log("Incorrect interactable object detected. Expected: " + interactionSequence[currentStep].name);
        }
    }

    void SpawnSprite()
    {
        if (spritePrefab != null)
        {
            spawnedSprite = Instantiate(spritePrefab[currentStep-1], player.position, Quaternion.identity);
            Debug.Log("Sprite spawned: " + spawnedSprite.name);
        }
        else
        {
            Debug.LogWarning("Prefab list is empty or currentStep is out of bounds.");
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
            Debug.Log("Sprite placed in target area: " + targetArea.name);
        }
    }
}