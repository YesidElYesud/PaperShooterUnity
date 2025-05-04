using UnityEngine;

public class EnemigoX : MonoBehaviour, IDañable
{
    public int vida = 3;

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad;
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
