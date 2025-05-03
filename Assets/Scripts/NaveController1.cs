using UnityEngine;

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

    void Update()
    {
        float mov = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * mov * velocidad * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DispararBala();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DispararCohete();
        }
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
