using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    public Text timeScore;
    public Text score;
    public GameObject Player;
    public GameObject gameOverUI;
    public GameObject victoryUI;
    public static int index = 3;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    public string Scenename;
    void Update()
    {
        timeScore.text = Time.timeSinceLevelLoad.ToString("0");
        score.text = (10*TransferData._instance.layer).ToString("0");
        float abc = Time.timeSinceLevelLoad;
        if(TransferData._instance.clicks < 4)
        {
            if (abc > 10)
            {
                victoryUI.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
        
    }

    public void RestartGame()
        {
            SceneManager.LoadScene(2);
            TransferData._instance.layer = 0;
            Time.timeScale = 1;
        }
    public void victoryGame()
    {
        TransferData._instance.speed += 1.5f;
        Debug.Log(TransferData._instance.speed);
        TransferData._instance.clicks += 1;
        Debug.Log(TransferData._instance.clicks);
        TransferData._instance.spawnTime -= 0.2f;
        Debug.Log(TransferData._instance.spawnTime);
        SceneManager.LoadScene(Scenename);
        Time.timeScale = 1;
    }
    public void Quit()
    {
        TransferData._instance.layer = 0;
        SceneManager.LoadScene(1);
    }

    public static void GameOver(bool dead)
    {
        if(dead)
        {
            index -= 1;
            if(index == 0){
            instance.gameOverUI.SetActive(true);
            Time.timeScale = 0f;
            }
        }
    }
}
