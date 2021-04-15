using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class top2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
    private void FixedUpdate()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector3 kuvvet = new Vector3(1, 0, 1);
        GetComponent<Rigidbody>().AddForce(kuvvet);
    }
}
