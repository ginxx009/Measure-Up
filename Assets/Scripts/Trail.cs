using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public GameObject[] trails;
    int next = 0;

    private void Start()
    {
        // Spawn a new Trail every 100 ms
        InvokeRepeating("SpawnTrail", 0.1f, 0.1f);
    }

    void SpawnTrail()
    {
        //Spawn trail if moving fast
        //if(GetComponent<Rigidbody2D>().velocity.sqrMagnitude > 25)
        //Instantiate(trails[next], transform.position, Quaternion.identity);
        //next = (next + 1) % trails.Length;
    }

}
