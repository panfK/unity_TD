using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Projectile projectilePrefab;
    public Transform firePoint;
    public float towerRange;
    public float towerReload;
    public float currentReload;
    public int towerDamage;


    // Update is called once per frame
    void Update()
    {
        currentReload -= Time.deltaTime;

        if(Enemy.EnemyList.Count > 0)
        {
            Enemy target = null;

            float currentDistance = 0f;
            float minDistance = 1000f;

            for (int i = 0; i < Enemy.EnemyList.Count; i++)
            {
                currentDistance = Vector3.Distance(Enemy.EnemyList[i].transform.position, transform.position);

                if(currentDistance < towerRange && currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    target = Enemy.EnemyList[i];
                }
            }

            if (target == null) return;

            Vector3 direction = target.transform.position - transform.position;
            transform.forward = direction;

            if(currentReload <= 0)
            {
                currentReload = towerReload;
                Projectile attack = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
                attack.damage = towerDamage;
                attack.target = target.transform;
            }        }
    }
}
