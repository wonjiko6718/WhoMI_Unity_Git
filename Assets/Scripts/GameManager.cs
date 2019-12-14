using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool playerDead = false;
    
    public static GameManager instance;
    private GameObject playerIsNow;
    public GameObject GameOverText;

    private void Awake() 
    {
        if(GameManager.instance == null) // singleton
        {
            GameManager.instance = this;
        }
        playerDead = false;
    }
    // Update is called once per frame
    void Update()
    {
        playerIsNow = GameObject.Find("Player");
        if(playerIsNow == null)
        {
            playerDead = true;
            GameOverText.SetActive(true);
        }
        else
        {
            playerDead = false;
            GameOverText.SetActive(false);
        }
        OnGameOverMessage();
    }
    void OnGameOverMessage()
    {
        if(playerDead == true && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
