using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Button _button;
    private Text _textWin;
    private Text _textLose;
    public static bool IsPlayerDead = false;
    void Start()
    {
        var child1 =  transform.Find("BUTTON");
        _button = child1.GetComponent<Button>();
        var child2 =  transform.Find("WIN");
        _textWin = child2.GetComponent<Text>();
        var child3 =  transform.Find("LOSE");
        _textLose = child3.GetComponent<Text>();

        if (IsPlayerDead)
        {
            _textWin.gameObject.SetActive(false);
        }
        else
        {
            _textLose.gameObject.SetActive(false);
        }
    }

    public void BackToGame()
    {
        SceneManager.LoadScene("proj2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
