using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRoot : MonoBehaviour
{
    public Build build;
    public Transform root;
    public bool IsBuilded;
    private void OnMouseDown()
    {
        if(IsBuilded)
        {
            return;
        }
        build.gameObject.SetActive(true);
        build.SetRoot(this);
    }

}
