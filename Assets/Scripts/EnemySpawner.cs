using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]List<WaveConfig> wave_configs;
    int start_wave = 0;
    // Start is called before the first frame update
    void Start()
    {
        var cur_wave = wave_configs[start_wave];
        StartCoroutine(Spawn_Enemies_Wave(cur_wave));
    }
    private IEnumerator Spawn_Enemies_Wave(WaveConfig wave_config)
    {
        for(int enemy_count = 0; enemy_count < wave_config.Get_numenemy(); enemy_count++)
        {
            var new_enemy = Instantiate(wave_config.Get_Enemypre(),
                                        wave_config.Get_waypoints()[0].transform.position,
                                        Quaternion.identity);
            new_enemy.GetComponent<EnemyPathing>().Set_WaveConfig(wave_config);
            yield return new WaitForSeconds(wave_config.Get_Timespawns());
        }
    }
}
