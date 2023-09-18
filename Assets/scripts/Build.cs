using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public TowerRoot towerRoot;
    public int currentCost;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetRoot(TowerRoot root)
    {
        towerRoot = root;
    }

    public void SetTowerCost(int cost)
    {
        currentCost = cost;
    }

    public void Buildtower(GameObject tower)
    {
        if(GameLevel.Instance.money >= currentCost)
        {
            GameLevel.Instance.RemoveMoney(currentCost);
            Instantiate(tower, towerRoot.root.position, Quaternion.identity);
            gameObject.SetActive(false);
            towerRoot.IsBuilded = true;
        }
    }
}
