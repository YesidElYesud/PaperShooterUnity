using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    [Header("Canvases")]
    public GameObject canvasInicio;
    public GameObject canvasFinal;

    [Header("Textos")]
    public TMP_Text textoConteo;
    public TMP_Text textoConteoEnTiempoReal;

    private int enemigosDestruidos = 0;
    private bool juegoActivo = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 0f; // Detenemos el juego al inicio
        canvasInicio.SetActive(true);
        canvasFinal.SetActive(false);
        enemigosDestruidos = 0;

        if (textoConteoEnTiempoReal != null)
            textoConteoEnTiempoReal.text = "Enemigos: 0";
    }

    public void IniciarJuego()
    {
        canvasInicio.SetActive(false);
        Time.timeScale = 1f;
        juegoActivo = true;

        // Puedes activar el spawner de enemigos aquí si usas uno:
        // enemigoSpawner.SetActive(true);
    }

    public void EnemigoDestruido()
    {
        if (!juegoActivo) return;

        enemigosDestruidos++;
        if (textoConteoEnTiempoReal != null)
        {
            textoConteoEnTiempoReal.text = "Enemigos: " + enemigosDestruidos;
        }
    }

    public void MostrarCanvasFinal()
    {
        juegoActivo = false;
        canvasFinal.SetActive(true);
        textoConteo.text = "Enemigos destruidos: " + enemigosDestruidos.ToString();
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
