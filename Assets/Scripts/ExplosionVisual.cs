using UnityEngine;

public class ExplosionVisual : MonoBehaviour
{
    public Color explosionColor = Color.red;
    public float escalaMaxima = 1.5f;
    public float duracion = 0.5f; // duración total de la animación
    public int daño = 999;

    private SpriteRenderer spriteRenderer;
    private float tiempo;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.color = explosionColor;
        }

        transform.localScale = Vector3.zero;
        tiempo = 0f;
    }

    void Update()
    {
        tiempo += Time.deltaTime;
        float mitad = duracion / 2f;

        if (tiempo <= mitad)
        {
            float t = tiempo / mitad;
            transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * escalaMaxima, t);
        }
        else if (tiempo <= duracion)
        {
            float t = (tiempo - mitad) / mitad;
            transform.localScale = Vector3.Lerp(Vector3.one * escalaMaxima, Vector3.zero, t);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        IDañable dañable = collision.GetComponent<IDañable>();
        if (dañable != null)
        {
            dañable.RecibirDaño(daño);
        }
    }
}
