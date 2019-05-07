using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Ball prefab that will be spawned
    public GameObject birdPrefab;

    bool isOccupied = false;

    private void Awake()
    {
        Screen.SetResolution(Screen.height, Screen.width, true);
    }

    // Start is called before the first frame update
    void FixedUpdate()
    {
        if (!isOccupied && !sceneMoving())
        {
            SpawnNext();
        }    
    }

    void SpawnNext()
    {
        // Spawn the ball at current position with default rotation;
        Instantiate(birdPrefab, transform.position, Quaternion.identity);
        isOccupied = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        // Ball left the area
        isOccupied = false;
    }

    bool sceneMoving()
    {
        // Find all rigidbodies , check if there's still movement
        Rigidbody2D[] bodies = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D rb in bodies)
            if (rb.velocity.sqrMagnitude > 5)
                return true;
        return false;
    }
}
