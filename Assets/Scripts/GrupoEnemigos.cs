using UnityEngine;

public class GrupoEnemigos : MonoBehaviour
{
    public float velocidad = 2f;
    public float velocidadRotacion = 90f;
    [SerializeField] private Vector3 offset = new Vector3(0, -1.5f, 0); // Editable en el editor

    private Transform objetivo;

    void Start()
    {
        GameObject nave = GameObject.FindGameObjectWithTag("navesita");
        if (nave != null)
        {
            objetivo = nave.transform;
        }
    }

    void Update()
    {
        if (objetivo != null)
        {
            // Movimiento del grupo
            Vector3 destino = objetivo.position + offset;
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
        }

        // Rotación del grupo completo
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
    }
}
