using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int gunAmmo = 10;

    private void Awake()
    {
        // Si ya existe una instancia y no es esta, destruye este objeto
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // Asigna esta instancia como la instancia única
            Instance = this;
            // Si quieres que el GameManager persista entre escenas
            DontDestroyOnLoad(gameObject);
        }
    }
}
