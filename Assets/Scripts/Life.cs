using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject LifePrefab; // using to create new life after getting some score points
    private Vector2 position;

    void Start()
    {
        position.x = 3.36f;
        position.y = 5.4f;

        position.x += 1.8f;
        Instantiate(LifePrefab, position, new Quaternion());
    }


    void Update()
    {
        
    }

    public void OnScorePoints()
    {
        // change position
        position.x += 1.8f;

        // add new life to pacman lives

        Instantiate(LifePrefab, position, new Quaternion());
    }
}
