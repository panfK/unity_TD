using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public static List<Enemy> EnemyList = new();

    public Transform[] dots;
    public Transform enemyInfo;
    public TextMeshProUGUI enemySpeedText;
    public Slider enemyHP;
    public float speed;
    public int indexDot;
    public int enemyHealth;
    public int damage;
    public int reward;

    private void Start()
    {
        EnemyList.Add(this);
        enemySpeedText.text = speed.ToString();
        enemyHP.maxValue = enemyHealth;
        enemyHP.value = enemyHealth;
    }

    private void OnDestroy()
    {
        
        EnemyList.Remove(this);        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (indexDot >= dots.Length)
        {
            return;
        }
        float distance = Vector3.Distance(dots[indexDot].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, dots[indexDot].position, speed * Time.deltaTime);
        transform.forward = dots[indexDot].position - transform.position;
        enemyInfo.transform.rotation = Quaternion.Euler(Vector3.right * 45);
        if (distance <= 0.1f)
        {
            indexDot = indexDot + 1;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Projectile>(out Projectile projectile))
        {
            enemyHealth -= projectile.damage;
            enemyHP.value = enemyHealth;

            if(enemyHealth<= 0)
            {
                GameLevel.Score++;
                Destroy(gameObject);
                GameLevel.Instance.AddMoney(reward);
            }

            Destroy(projectile.gameObject);
        }

        if(other.TryGetComponent<Base>(out Base playerBase))
        {
            playerBase.Hit(damage);
            Destroy(gameObject);
        }
    }
}
