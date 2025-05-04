using UnityEngine;

public class Cohete : MonoBehaviour
{
    public float velocidad = 5f;
    public float radioExplosion = 2f;
    public GameObject explosionVisual;

    void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemigo") || collision.CompareTag("pared"))
        {
            Explotar();
        }
    }

    void Explotar()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radioExplosion);
        foreach (Collider2D c in objetos)
        {
            // Verifica si el objeto tiene un componente que implemente IDañable
            IDañable dañable = c.GetComponent<IDañable>();
            if (dañable != null)
            {
                dañable.RecibirDaño(999); // Daño letal
            }
        }

        if (explosionVisual != null)
        {
            Instantiate(explosionVisual, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioExplosion);
    }
}
