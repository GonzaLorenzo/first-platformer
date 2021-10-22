using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMovement : MonoBehaviour
{
    public List<Transform> waypoints;
    private int _currentwaypoint = 0;
    public float            speed = 1f;
    public Vector3          AuxScale;
    public Health           myHealth;
    public PlayerSensor     PlayerSensor;

    private void Awake()
    {
        myHealth = this.GetComponent<Health>();
    }

    void Update()
    {
        if (myHealth.IsAlive && !PlayerSensor.IsHitting())
        {
            Vector3 dir = waypoints[_currentwaypoint].position - transform.position;
            Vector3 actualdir = dir.normalized;
            transform.position += actualdir * speed * Time.deltaTime;

            if (dir.magnitude < 0.1f)
            {

                _currentwaypoint++;
                if (_currentwaypoint > waypoints.Count - 1)
                    _currentwaypoint = 0;
                FlipScale();
            }

        }
    }

    private void FlipScale()
    {
        AuxScale = transform.localScale;
        AuxScale.x = -AuxScale.x;
        transform.localScale = AuxScale;
    }
}
