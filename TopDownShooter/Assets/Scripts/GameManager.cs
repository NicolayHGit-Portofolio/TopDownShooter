using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    [SerializeField]
    GameObject mainCanvas;
    public Score scoreboard;

    [SerializeField]
    GameObject _gameOverCanvas;

    [SerializeField]
    Text _healthText;

    public bool gameOver = false;
    
    void Start()
    {
        if (gm == null)
            gm = gameObject.GetComponent<GameManager>();

        scoreboard = mainCanvas.GetComponent<Score>();
    }

    public void EndGame()
    {
        gameOver = true;
        Destroy(GameObject.FindGameObjectWithTag("Player"));

        _gameOverCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void UpdateHealth(int health)
    {
        _healthText.text = "Health: " + health.ToString();
    }
}
