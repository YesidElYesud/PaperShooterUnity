using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    [Header("Canvases")]
    public GameObject canvasInicio;      // Menú de inicio
    public GameObject hudCanvas;         // HUD en tiempo real (barra cohete, contador)
    public GameObject canvasDerrota;     // Pantalla final

    [Header("Spawner de enemigos")]
    public GameObject spawner;           // Activar cuando empiece el juego

    [Header("Textos")]
    public TMP_Text textoConteoFinal;        // Texto que aparece al perder
    public TMP_Text textoConteoEnTiempoReal; // HUD en tiempo real

    private int enemigosDestruidos = 0;
    private bool juegoActivo = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 0f; // Detener juego al inicio
        canvasInicio.SetActive(true);
        hudCanvas.SetActive(false);
        canvasDerrota.SetActive(false);
        if (spawner != null) spawner.SetActive(false);
        enemigosDestruidos = 0;

        ActualizarTextoEnTiempoReal();
    }

    public void IniciarJuego()
    {
        canvasInicio.SetActive(false);
        hudCanvas.SetActive(true);
        canvasDerrota.SetActive(false);
        if (spawner != null) spawner.SetActive(true);

        Time.timeScale = 1f;
        juegoActivo = true;
    }

    public void EnemigoDestruido()
    {
        if (!juegoActivo) return;

        enemigosDestruidos++;
        ActualizarTextoEnTiempoReal();
    }

    void ActualizarTextoEnTiempoReal()
    {
        if (textoConteoEnTiempoReal != null)
        {
            textoConteoEnTiempoReal.text = "Enemigos: " + enemigosDestruidos;
        }
    }

    public void MostrarCanvasFinal()
    {
        juegoActivo = false;
        Time.timeScale = 0f;

        canvasDerrota.SetActive(true);
        hudCanvas.SetActive(false);
        textoConteoFinal.text = "Enemigos destruidos: " + enemigosDestruidos;
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
