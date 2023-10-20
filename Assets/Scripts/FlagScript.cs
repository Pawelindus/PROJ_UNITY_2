using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagScript : MonoBehaviour
{

    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(FadeOut());
        
    }

    IEnumerator MenuScene()
    {
        LogicScript.IsPlayerDead = false;
        SceneManager.LoadScene("menu");
        yield return null;
    }

    IEnumerator FadeOut()
    {
        
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                player.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, i);
                yield return null;
            }
            player.GetComponent<SpriteRenderer>().material.color = new Color(1, 1, 1, 0);
            yield return StartCoroutine(MenuScene());
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
