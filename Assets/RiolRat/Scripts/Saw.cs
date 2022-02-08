using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float moveSpeed;

    public GameObject Waypoints;

    private Transform[] WaypointsArray;
    private int waypointsIndex = 0;

    private bool goingBack = false;

    public bool goBack; //If set to false, the saw will return to the first waypoint after reaching the last waypoint.
                        //If set to true, the saw will return to the previous waypoint after reaching the last waypoint, and this until it's back at the first way point. So ping pong

    // Start is called before the first frame update
    void Start()
    {
        WaypointsArray = new Transform[Waypoints.transform.childCount];

        for (int i = 0; i < WaypointsArray.Length; i++)
        {
            WaypointsArray[i] = Waypoints.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, WaypointsArray[waypointsIndex].position, moveSpeed * Time.deltaTime); //Move the saw to the next waypoint

        if (transform.position == WaypointsArray[waypointsIndex].position && waypointsIndex + 1 < WaypointsArray.Length && !goingBack) 
        {//If the saw reached the waypoint, and there is another waypoint after the current one, and the saw isn't return to the first waypoint
            waypointsIndex++;
        }
        else if (transform.position == WaypointsArray[waypointsIndex].position && waypointsIndex - 1 > -1 && goingBack)
        {//If the saw reached the waypoint, and there is another waypoint after the current one, and the saw is returning to the first waypoint
            waypointsIndex--;
        }
        else if (transform.position == WaypointsArray[waypointsIndex].position)
        {//If we reached the last waypoint and there isn't another waypoint after the current one
            if (goBack)
            {//If we stated that the saw could go back, reverse the way it was going
                goingBack = !goingBack;
            }
            else
            {//If the saw wasn't allowed to go back and forth, but instead had to loop. Put the first waypoint as the next waypoint
                waypointsIndex = 0;
            }
        }
    }
}
