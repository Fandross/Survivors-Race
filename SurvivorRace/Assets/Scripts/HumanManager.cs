using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public GameObject humanPrefab; // Prefab do humano a ser coletado
    public int spawnChance = 50; // Probabilidade de spawn (0-100)
    public int distanciaPista = 3000;
    public int maxHumans = 10; // Número máximo de humanos que podem estar ativos
    public List<GameObject> activeHumans = new List<GameObject>();

    public void TrySpawnHuman()
    {
        if (activeHumans.Count >= maxHumans) return;
       
        while (activeHumans.Count <= maxHumans)
        {
            if (Random.Range(0, 100) < spawnChance)
            {
                int zAleatorio = Random.Range(0, distanciaPista);
                int xAleatorio = Random.Range(-2, 2);
                GameObject humanCriado = Instantiate<GameObject>(humanPrefab);
                humanCriado.GetComponent<Transform>().position = new Vector3(xAleatorio, 0, zAleatorio);
                activeHumans.Add(humanCriado);
                Debug.Log("Humano added!");
            }

        }
        
    }

    public void RemoveHuman(GameObject human)
    {
        activeHumans.Remove(human);
        Destroy(human);
    }

    private void Awake()
    {
        TrySpawnHuman();
    }
}
