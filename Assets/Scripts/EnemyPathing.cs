using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField]WaveConfig wave_config;
    [SerializeField]List<Transform> waypoints;
    [SerializeField]float move_speed = 2f;
    int waypoint_index = 0;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = wave_config.Get_waypoints();
        transform.position = waypoints[waypoint_index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypoint_index <= waypoints.Count - 1)
        {
            var target_position = waypoints[waypoint_index].transform.position;
            var movement_frame = move_speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target_position, movement_frame);
            if (transform.position == target_position)
            {
                waypoint_index++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}