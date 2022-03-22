using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public EnemySpawn enemyManager;
    public TMP_Text coins;

    public int coinAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        manager = this;
        this.coins.text = "Coins: " + coinAmount;
    }

    public void addCoins(int num)
    {
        Debug.Log("cha-ching");
        coinAmount += num;
        this.coins.text = "Coins: " + coinAmount;
    }

    public void checkEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0 && !enemyManager.done.Contains(false)) GameOver();
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void unpauseGame()
    {
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneLoaded.loader.ReloadScene();
    }

    void GameOver()
    {
        pauseGame();
    }
}
