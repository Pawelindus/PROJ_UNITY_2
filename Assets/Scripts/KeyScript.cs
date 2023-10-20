using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("Door").SetActive(false);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
