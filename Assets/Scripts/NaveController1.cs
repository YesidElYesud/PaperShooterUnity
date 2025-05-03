using UnityEngine;
using UnityEngine.UI;  // Necesario para manejar la UI


public class NaveController1 : MonoBehaviour
{
    public float velocidad = 65f;
    public GameObject balaPrefab;
    public GameObject cohetePrefab;
    public Transform alaIzquierda;
    public Transform alaDerecha;
    public Transform centro;
    private bool disparoAlternado = true;
    public int vida = 3;
    public Image barraRecargaCohete;  // Asignar en el editor


    // Parámetros para balas
    public float tiempoEntreDisparos = 0.2f;
    private float tiempoProximoDisparo = 0f;

    // Parámetros para cohete
    public float tiempoRecargaCohete = 3f; // segundos entre disparos de cohete
    private float tiempoDisponibleCohete = 0f;

    void Update()
    {
        float mov = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * mov * velocidad * Time.deltaTime);

        // Disparo sostenido de balas
        if (Input.GetKey(KeyCode.UpArrow) && Time.time >= tiempoProximoDisparo)
        {
            DispararBala();
            tiempoProximoDisparo = Time.time + tiempoEntreDisparos;
        }

        // Disparo único de cohete con recarga
        if (Input.GetKeyDown(KeyCode.DownArrow) && Time.time >= tiempoDisponibleCohete)
        {
            DispararCohete();
            tiempoDisponibleCohete = Time.time + tiempoRecargaCohete;
        }

        // Actualización de barra de recarga
        float tiempoRestante = tiempoDisponibleCohete - Time.time;
        float progreso = 1f - Mathf.Clamp01(tiempoRestante / tiempoRecargaCohete);
        barraRecargaCohete.fillAmount = progreso;


    }

    void DispararBala()
    {
        Transform puntoDisparo = disparoAlternado ? alaIzquierda : alaDerecha;
        Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        disparoAlternado = !disparoAlternado;
    }

    void DispararCohete()
    {
        Instantiate(cohetePrefab, centro.position, Quaternion.identity);
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            GameOverManager.instance.MostrarCanvasFinal();
            Time.timeScale = 0;
        }
    }
}
