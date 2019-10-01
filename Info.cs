using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {

    Vector3 lastCheckPoint;
    public int score = 0, lives = 3, bulletsLeft = 20, coins = 0;
    public Image[] hearts;
    public GameObject gameOverPanel, winPanel;
    public Text bulletsText, scoreText;
    public Text coinText;

	void Start () {
        lastCheckPoint = transform.position;
        UpdateLives(0);
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        UpdateBullets(0);
        UpdateCoin(0);
        for (int i = 0; i < 5; i++ )
        {
            if(i < lives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

	}


    public void DeathReset()
    {
        transform.position = lastCheckPoint;
        UpdateLives(-1);
    }


    public void UpdateCheckpoint()
    {
        lastCheckPoint = transform.position;
    }

    public void UpdateLives(int l)
    {
        lives += l;
        if(lives > 5)
        {
            lives = 5;
        }
        for (int i = 0; i < 5; i++)
        {
            if (i < lives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        if(lives == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Cursor.visible = true;
        GetComponent<Controller2D>().enabled = false;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach(Enemy e in enemies)
        {
            e.enabled = false;
        }
    }

    public void YouWin()
    {
        winPanel.SetActive(true);
        Cursor.visible = true;
        GetComponent<Controller2D>().enabled = false;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (Enemy e in enemies)
        {
            e.enabled = false;
        }
    }

    

    public void UpdateScore(int s)
    {
        score += s;
        scoreText.text = score.ToString();
    }

    public void UpdateBullets(int b)
    {
        bulletsLeft += b;
        bulletsText.text = bulletsLeft.ToString();
    }

    public void UpdateCoin(int c)
    {
        coins += c;
        coinText.text = coins.ToString();

    }
}
