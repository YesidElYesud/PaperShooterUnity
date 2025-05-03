using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float velocidad = 2f;
    public int vida = 3;

    [SerializeField] private Vector3 offset = new Vector3(0, -1.5f, 0); // Editable en el editor
    public float velocidadRotacion = 90f; // grados por segundo

    private Vector3 direccion;

    void Start()
    {
        GameObject nave = GameObject.FindGameObjectWithTag("navesita");
        if (nave != null)
        {
            direccion = nave.transform.position + offset;
        }
        else
        {
            direccion = Vector3.zero;
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
            if (GameOverManager.instance != null)
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
            NaveController1 nave = other.GetComponent<NaveController1>();
            if (nave != null)
            {
                nave.RecibirDaño(1);
            }
            Destroy(gameObject);
        }
    }
}
