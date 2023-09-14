using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    public int indexDot;
    public float speed;
    public Transform[] dots;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (distance <= 0.1f)
        {
            indexDot = indexDot + 1;
        }

    }
}
