using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject spawner;

    void Start()
    {
        Time.timeScale = 0f; // Pausar el juego al inicio
        menuUI.SetActive(true);
        spawner.SetActive(false); // Enemigos no aparecen aún
    }

    public void IniciarJuego()
    {
        Time.timeScale = 1f;
        menuUI.SetActive(false);
        spawner.SetActive(true);
    }
}
