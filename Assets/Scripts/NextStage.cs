using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    public GameObject ball;

    private void Start()
    {
        StartCoroutine(findBall());
    }

    IEnumerator findBall()
    {
        yield return new WaitForSeconds(1f);
        ball = GameObject.Find("bird(Clone)");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Well done!");
            ball.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            ball.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
    }
}
