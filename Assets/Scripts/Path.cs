using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] float moveSpeed;
    int pointsIndex;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex <= points.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            if(transform.position == points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }
        }
    }
}
