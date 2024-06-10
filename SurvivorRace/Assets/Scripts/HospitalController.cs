using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalController : MonoBehaviour
{
    public int pontosParaGanharEstrela = 5; // Pontos necessários para ganhar uma estrela

    public GameObject hospitalPrefab;
    public List<GameObject> listaHospitais = new List<GameObject>();
    public int activeHospitais = 0;
    public int maxHospitaisSpawn = 10;
    public int distanciaPista = 3000;
    public int spawnChance = 10;


    public void TrySpawnHospital()
    {
        if (listaHospitais.Count >= maxHospitaisSpawn) return;

        while (listaHospitais.Count <= maxHospitaisSpawn)
        {
            if (Random.Range(0, 100) < spawnChance)
            {
                int zAleatorio = Random.Range(0, distanciaPista);
                int xAleatorio = Random.Range(-2, 2);
                GameObject hospitalCriado = Instantiate<GameObject>(hospitalPrefab);
                hospitalCriado.GetComponent<Transform>().position = new Vector3(-2, 0, zAleatorio);
                listaHospitais.Add(hospitalCriado);
                Debug.Log("Hospital added!");
            }

        }

    }
    private void Awake()
    {
        TrySpawnHospital();
    }
}
