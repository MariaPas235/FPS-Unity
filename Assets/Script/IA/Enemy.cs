using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Método que se llama cuando el enemigo es golpeado
    public void OnShot()
    {
        GameManager.Instance.EnemyDefeated(); // Llama al método para contar el enemigo derrotado
        Destroy(gameObject); // Destruye el enemigo
    }

    // Método para detectar colisiones
    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto con el que colisiona es una bala
        if (collision.gameObject.CompareTag("Bullet")) // Asegúrate de que las balas tengan el tag "Bullet"
        {
            OnShot(); // Llama al método que destruye el enemigo
        }
    }
}
