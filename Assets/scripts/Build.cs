using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public TowerRoot towerRoot;
   public void SetRoot(TowerRoot root)
    {
        towerRoot = root;
    }
    public void Buildtower(GameObject tower)
    {
        Instantiate(tower, towerRoot.root.position, Quaternion.identity);
        gameObject.SetActive(false);
        towerRoot.IsBuilded = true;
    }
}
