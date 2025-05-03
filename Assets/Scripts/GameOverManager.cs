using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject canvasFinal;
    public Text textoConteo;
    private int enemigosDestruidos = 0;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void EnemigoDestruido()
    {
        enemigosDestruidos++;
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
