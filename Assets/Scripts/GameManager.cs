using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float TimeCohete = 0.0f;
    public int Puntos = 0;
    public int VidaNave = 0;
    public bool Started = false;

    void Awake()
    {
        // Asegurar que solo haya una instancia del GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persistente entre escenas
        }
        else
        {
            Destroy(gameObject); // Evitar duplicados
        }
    }
}
