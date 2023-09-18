using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Records : MonoBehaviour
{
    public TextMeshProUGUI record1;
    public TextMeshProUGUI record2;
    public TextMeshProUGUI record3;


   // Start is called before the first frame update
    void Start()
    {
        record1.text = PlayerPrefs.GetString("record1", "");
        record2.text = PlayerPrefs.GetString("record2", "");
        record3.text = PlayerPrefs.GetString("record3", "");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
