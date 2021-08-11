using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
        [SerializeField]GameObject enemy_pre;
        [SerializeField]GameObject path_pre;
        [SerializeField]float time_spawns = 0.5f;
        [SerializeField]float spawn_random = 0.3f;
        [SerializeField]int num_enemy = 5;
        [SerializeField]float move_speed = 2f;

        public GameObject Get_Enemypre() { return enemy_pre; }
        public List<Transform> Get_waypoints()
        {
            var wave_waypoints = new List<Transform>();
            foreach(Transform child in path_pre.transform)
            {
                wave_waypoints.Add(child);
            }
            return wave_waypoints;
        }
        public float Get_Timespawns() { return time_spawns; }
        public float Get_spawnrandom() { return spawn_random; }
        public int Get_numenemy() { return num_enemy; }
        public float Get_movespeed() { return move_speed; }
}