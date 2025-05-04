using UnityEngine;
using UnityEngine.UI;

public class NaveController1 : MonoBehaviour, IDañable // 👈 IMPLEMENTAMOS LA INTERFAZ
{
    public float velocidad = 65f;
    public GameObject balaPrefab;
    public GameObject cohetePrefab;
    public Transform alaIzquierda;
    public Transform alaDerecha;
    public Transform centro;
    private bool disparoAlternado = true;
    public int vida = 3;
    public Image barraRecargaCohete;

    public float tiempoEntreDisparos = 0.2f;
    private float tiempoProximoDisparo = 0f;

    public float tiempoRecargaCohete = 3f;
    private float tiempoDisponibleCohete = 0f;

    void Update()
    {
        float mov = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * mov * velocidad * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) && Time.time >= tiempoProximoDisparo)
        {
            DispararBala();
            tiempoProximoDisparo = Time.time + tiempoEntreDisparos;
        }

        if (Input.GetKeyDown(KeyCode.S) && Time.time >= tiempoDisponibleCohete)
        {
            DispararCohete();
            tiempoDisponibleCohete = Time.time + tiempoRecargaCohete;
        }

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

    public void RecibirDaño(int daño) // 👈 USO DE LA INTERFAZ IDañable
    {
        vida -= daño;
        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        GameOverManager.instance.MostrarCanvasFinal(); // 👈 Muestra botón de reinicio
        Time.timeScale = 0f;
        Destroy(gameObject);
    }
}