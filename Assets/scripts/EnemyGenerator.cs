using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public List<Transform> waypoints;
    public Enemy enemyType1;
    public Enemy enemyType2;
    public int currentWave;
    public float createStepTimer;
    private int enemyType1Count;
    private int enemyType2Count;

    public void CreateWave()
    {
        enemyType1Count = (currentWave + 1) * 2;
        enemyType2Count = enemyType1Count / 10;

        currentWave += 1;

        StartCoroutine(CreateWaveRuntime());
    }

    private void CreateEnemy(Enemy prefab)
    {
        Enemy enemy = Instantiate(prefab, waypoints[0].position, Quaternion.identity);
        enemy.dots = waypoints.ToArray();
    }

    private IEnumerator CreateWaveRuntime()
    {
        while (enemyType1Count > 0 | enemyType2Count > 0)
        {
            if (enemyType1Count > 0)
            {
                CreateEnemy(enemyType1);
                enemyType1Count -= 1;
            }
            if(enemyType2Count > 0)
            {
                CreateEnemy(enemyType2);
                enemyType2Count -= 1;
            }

            yield return new WaitForSeconds(createStepTimer);
        }

        enemyType1Count = 0;
        enemyType2Count = 0;
    }
}
