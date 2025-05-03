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
            collision.GetComponent<Enemigo>().RecibirDaño(1);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("pared"))
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
