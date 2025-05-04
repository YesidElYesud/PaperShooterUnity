using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 10f;

    void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemigo"))
        {
            IDañable dañable = collision.GetComponent<IDañable>();
            if (dañable != null)
            {
                dañable.RecibirDaño(1);
                Destroy(gameObject);
                return;
            }
        }

        if (collision.CompareTag("pared"))
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.Play();
        }
    }
}
