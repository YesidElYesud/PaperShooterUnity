using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 2f;
    public int vida = 3;
    private Vector3 direccion;

    public float velocidadRotacion = 90f; // grados por segundo

    void Start()
    {
        GameObject nave = GameObject.FindGameObjectWithTag("navesita");
        if (nave != null)
        {
            direccion = nave.transform.position;  // se guarda la posición al momento del spawn
        }
        else
        {
            direccion = Vector3.zero;  // valor por defecto
        }
    }

    void Update()
    {
        // Movimiento hacia la dirección
        transform.position = Vector3.MoveTowards(transform.position, direccion, velocidad * Time.deltaTime);

        // Rotación constante en Z (como si estuviera girando)
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
    }

    public void RecibirDaño(int daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            GameOverManager.instance.EnemigoDestruido();
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pared"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("navesita"))
        {
            other.GetComponent<NaveController1>().RecibirDaño(1);
            Destroy(gameObject);
        }
    }
}
