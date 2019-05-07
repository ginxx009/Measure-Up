using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public float force = 300;
    public GameObject trail_small;
    public GameObject dotPrefab;
    private Vector2 startPos;

    private int maxDots = 10;
    private GameObject[] line;
    private float spacing = 0.001f;
    private GameObject go;

    private void Start()
    {
        line = new GameObject[maxDots];
        //Instantiate 15 dotted for trajectory line
        for(int i = 0; i < line.Length; i++)
        {
            go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            line[i] = go;
            line[i].SetActive(false);
        }

        startPos = transform.position;
    }
    
    //TEMPORARY
    private void OnMouseUp()
    {
        // Disable IsKenematic
        GetComponent<Rigidbody2D>().isKinematic = false;

        // Add the Force
        Vector2 dir = startPos - (Vector2)transform.position;

        GetComponent<Rigidbody2D>().AddForce(dir * force);
        //Remove the script (not the gameobject)
        Destroy(this);

        //Disable Trajectory Line
        DisplayLine(false);
    }
    
    private void OnMouseDrag()
    {
        //Display and Enable Trajectory Line
        DisplayLine(true);
        //Convert mouse potision to world position
        Vector2 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Keep it in a certain radius
        float radius = 1.8f;
        Vector2 dir = p - startPos;

        if (dir.sqrMagnitude > radius)
        {
            dir = dir.normalized * radius;

            //Set position
            transform.position = startPos + dir;
        }
    }

    private void DisplayLine(bool display)
    {
        line[0].transform.position = transform.position;
        Vector2 v2 = transform.position;
        float y = (force *( startPos - (Vector2)transform.position)).y;
        float t = 0.0f;
        v2.y = 0.0f;

        for(int i = 1; i < line.Length; i++)
        {
            v2 += force * (startPos - (Vector2)transform.position) * spacing;
            t += spacing;
            v2.y = y * t + 0.5f * Physics2D.gravity.y * t * t + transform.position.y;
            line[i].transform.position = v2;
            line[i].SetActive(display);
        }
    }
}
