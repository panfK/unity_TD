using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    public TextMeshProUGUI baseHp;
    public int baseHealth;

    private void Start()
    {
        baseHp.text = baseHealth.ToString();
    }

    public void Hit(int damage)
    {
        baseHealth -= damage;
        if (baseHealth <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
        baseHp.text = baseHealth.ToString();
    }
}
