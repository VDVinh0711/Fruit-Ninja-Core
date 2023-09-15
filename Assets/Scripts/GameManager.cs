using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool isActive;
    public float someFew;
    public static GameManager Innstance;
    public SpawnManager spawnManager;
    public RectTransform  titlScrene;
    public Button restart;
    public int countMiss = 0;
    private void Awake()
    {
        Innstance = this;
        restart.onClick.AddListener(RestartGame);
    }
    public void StarGame(float diffculty)
    {
        titlScrene.gameObject.SetActive(false);
        someFew =someFew / diffculty;
        isActive = true;
        spawnManager.SpawmFruit();
    }
    public void GameOver()
    {
        isActive = false;
        restart.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
}
