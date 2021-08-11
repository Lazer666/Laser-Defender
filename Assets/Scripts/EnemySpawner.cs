using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]List<WaveConfig> wave_configs;
    [SerializeField]int start_wave = 0;
    [SerializeField]bool looping = false;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(Spawn_Waves());
        }while(looping);
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
    private IEnumerator Spawn_Waves()
    {
        for(int wave_index = start_wave; wave_index < wave_configs.Count; wave_index++)
        {
            var cur_wave = wave_configs[wave_index];
            yield return StartCoroutine(Spawn_Enemies_Wave(cur_wave));
        }
    }
}
