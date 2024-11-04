using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text ammoText;           // Texto para mostrar munición
    public Text healthText;         // Texto para mostrar salud
    public Text winText;            // Texto que se mostrará al ganar
    public int gunAmmo = 10;        // Munición inicial
    public int health = 100;        // Salud inicial
    private int enemiesDefeated = 0; // Contador de enemigos derrotados

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        winText.gameObject.SetActive(false); // Asegúrate de que el texto de victoria esté desactivado al inicio
    }

    private void Update()
    {
        ammoText.text = gunAmmo.ToString();
        healthText.text = health.ToString();
    }

    public void LoseHealth(int healthToReduce)
    {
        health -= healthToReduce;
        CheckHealth();
    }

    public void CheckHealth()
    {
        if (health <= 0)
        {
            Debug.Log("Has muerto");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++; // Incrementa el contador de enemigos derrotados
        CheckWinCondition(); // Verifica si se ha alcanzado la victoria
    }

    private void CheckWinCondition()
    {
        if (enemiesDefeated >= 11) // Cambia este número si necesitas más enemigos para ganar
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        // Muestra el texto de victoria
        winText.gameObject.SetActive(true);
        // Detiene el juego
        Time.timeScale = 0; // Detiene el tiempo del juego
    }
}
