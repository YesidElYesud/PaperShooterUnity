using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // importante: incluye el namespace de TextMeshPro

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    public GameObject canvasFinal;
    public TMP_Text textoConteo;
    public TMP_Text textoConteoEnTiempoReal; // ahora es TMP_Text

    private int enemigosDestruidos = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void EnemigoDestruido()
    {
        enemigosDestruidos++;
        if (textoConteoEnTiempoReal != null)
        {
            textoConteoEnTiempoReal.text = "Enemigos: " + enemigosDestruidos;
        }
    }

    public void MostrarCanvasFinal()
    {
        canvasFinal.SetActive(true);
        textoConteo.text = "Enemigos destruidos: " + enemigosDestruidos.ToString();
    }

    public void ReiniciarJuego()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
