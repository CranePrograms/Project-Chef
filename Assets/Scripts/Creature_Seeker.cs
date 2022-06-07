using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Creature_Seeker : MonoBehaviour
{

    public Transform targetPostion;

    private Seeker seeker;

    public Path path;

    public float speed = 2;
    public float nextWaypointDistance = .5f;
    private int currentWaypoint = 0;
    public bool reachedEndOfPath;


    private void Awake()
    {
        targetPostion = this.transform.Find("StudentDestination");
    }

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();

        seeker.StartPath(transform.position, targetPostion.position, OnPathComplete);
    }

    public void OnPathComplete(Path p)
    {
        Debug.Log("Yay, we got a path back did it have an error?" + p.error);

        if(!p.error)
        {

            path = p;
            currentWaypoint = 0;

        }
    }

    public void Update()
    {

        if (path == null)
        {
            //If there's no path to follow do nothing
            return;
        }

        reachedEndOfPath = false;

        float distanceToWayPoint;
        while (true)
        {

            distanceToWayPoint = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);
            if (distanceToWayPoint < nextWaypointDistance)
            {
                if (currentWaypoint + 1 < path.vectorPath.Count)
                {
                    currentWaypoint++;
                } else
                {
                    //This is how we know that the student has reached the end of the path.
                    reachedEndOfPath = true;
                    break;
                }
            } else
            {
                break;
            }

        }

        var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distanceToWayPoint / nextWaypointDistance) : 1f;

        //This is the direction to the next waypoint normalized so it has a length of 1 world unity
        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        //Multiply the direction by our desired speed to get velocity
        Vector3 velocity = dir * speed * speedFactor;

        transform.position += velocity * Time.deltaTime;

    }

    /// <summary>
    /// This will set this students new movement goal.
    /// </summary>
    /// <param name="newMovementPosition"> The new position to move to. </param>
    public void SetTargetPosition(Vector2 newMovementPosition)
    {
        Debug.Log("Got to target pos" + newMovementPosition.ToString());
        this.targetPostion.position = newMovementPosition;
        seeker.StartPath(transform.position, targetPostion.position, OnPathComplete);
    }


}
