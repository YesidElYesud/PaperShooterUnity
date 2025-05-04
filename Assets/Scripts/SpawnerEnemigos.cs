using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemigoConPeso
{
    public GameObject prefab;
    public float peso;
}

public class SpawnerEnemigos : MonoBehaviour
{
    public Transform[] puntosDeSpawn;
    public List<EnemigoConPeso> enemigosConPeso;

    public float tiempoMin = 1f;
    public float tiempoMax = 4f;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float tiempoEspera = Random.Range(tiempoMin, tiempoMax);
            yield return new WaitForSeconds(tiempoEspera);

            Transform punto = puntosDeSpawn[Random.Range(0, puntosDeSpawn.Length)];
            GameObject prefabElegido = ElegirPrefabPorPeso();

            if (prefabElegido != null)
            {
                Instantiate(prefabElegido, punto.position, Quaternion.identity);
            }
        }
    }

    GameObject ElegirPrefabPorPeso()
    {
        float pesoTotal = 0f;
        foreach (var e in enemigosConPeso)
        {
            pesoTotal += e.peso;
        }

        float valorAleatorio = Random.Range(0, pesoTotal);
        float suma = 0f;

        foreach (var e in enemigosConPeso)
        {
            suma += e.peso;
            if (valorAleatorio <= suma)
            {
                return e.prefab;
            }
        }

        return null;
    }
}
