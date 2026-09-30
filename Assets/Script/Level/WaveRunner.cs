using System.Collections;
using UnityEngine;

public class WaveRunner : MonoBehaviour
{
    [SerializeField] Level level;
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] int waveCount = 5;
    [SerializeField] int enemiesPerWave = 5;
    [SerializeField] float spawnInterval = 1f;
    [SerializeField] float timeBetweenWaves = 5f;

    IEnumerator Start()
    {
        for (int wave = 0; wave < waveCount; wave++)
        {
            for (int i = 0; i < enemiesPerWave + wave; i++)
            {
                Instantiate(enemyPrefab).SetLevel(level);
                yield return new WaitForSeconds(spawnInterval);
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
}
