using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float moveSpeed;

    public GameObject Waypoints;

    private Transform[] WaypointsArray = new Transform[5];
    private int waypointsIndex = 0;

    private bool goingBack = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Waypoints.transform.childCount; i++)
        {
            WaypointsArray[i] = Waypoints.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!goingBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, WaypointsArray[waypointsIndex].position, moveSpeed * Time.deltaTime);
        }


        if (waypointsIndex >= WaypointsArray.Length - 1 || goingBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, WaypointsArray[waypointsIndex].position, moveSpeed * Time.deltaTime);
            goingBack = true;
            if (waypointsIndex == 0)
            {
                goingBack = false;
            }
        }

        if (transform.position == WaypointsArray[waypointsIndex].position && !goingBack)
        {
            waypointsIndex += 1;
        }

        if (transform.position == WaypointsArray[waypointsIndex].position && goingBack)
        {
            waypointsIndex -= 1;
        }
    }
}
