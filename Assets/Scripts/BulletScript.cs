using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float BulletSize = 1;
    [SerializeField] public float BulletSpeed = 1;
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
        if (other.gameObject.CompareTag("Player"))
        {
            LogicScript.IsPlayerDead = true;
            SceneManager.LoadScene("menu");
        }

        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
