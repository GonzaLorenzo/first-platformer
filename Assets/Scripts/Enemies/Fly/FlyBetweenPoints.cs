using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBetweenPoints : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed;
    public Vector3 AuxScale;
    private int _currentwaypoint = 0;

    void Update()
    {
        Vector3 dir = waypoints[_currentwaypoint].position - transform.position;
        Vector3 actualdir = dir.normalized;
        transform.position += actualdir * speed * Time.deltaTime;

        if (dir.magnitude < 0.1f)
        {
            _currentwaypoint++;
            if (_currentwaypoint > waypoints.Count - 1)
                _currentwaypoint = 0;
        }

    }

}
