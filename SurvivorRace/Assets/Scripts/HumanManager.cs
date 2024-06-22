using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public GameObject humanPrefab;
    public int spawnChance = 50;
    public int distanciaPista = 3000;
    public int maxHumans = 10;
    public List<GameObject> activeHumans = new List<GameObject>();

    public void TrySpawnHuman()
    {
        if (activeHumans.Count >= maxHumans) return;

        while (activeHumans.Count < maxHumans)
        {
            if (Random.Range(0, 100) < spawnChance)
            {
                int zAleatorio = Random.Range(0, distanciaPista);
                int xAleatorio = Random.Range(-2, 2);
                GameObject humanCriado = Instantiate(humanPrefab);
                humanCriado.GetComponent<Transform>().position = new Vector3(xAleatorio, 0, zAleatorio);

                // Desativar todos os filhos inicialmente
                foreach (Transform child in humanCriado.transform)
                {
                    child.gameObject.SetActive(false);
                }

                // Ativar um filho aleatório
                int randomChildIndex = Random.Range(0, humanCriado.transform.childCount);
                humanCriado.transform.GetChild(randomChildIndex).gameObject.SetActive(true);

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
