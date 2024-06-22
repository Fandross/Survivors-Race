using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject tileBase;
    public Transform playerRef;
    public List<GameObject> tileLista;
    public int tamanhoTile = 10;
    public List<GameObject> tileListaSpawned;

    private int quantidadeTiles = 0;
    public int quantidadeTilesMaxima = 10;

    private void Awake()
    {
        tileListaSpawned = new List<GameObject>();

        // Inicialmente cria um número máximo de tiles
        for (int i = 0; i < quantidadeTilesMaxima; i++)
        {
            CriarNovoTile();
        }
    }

    private void Update()
    {
        // Verifica se precisa criar novos tiles à frente do jogador
        float playerZ = playerRef.position.z;
        float limiteSpawn = playerZ + (quantidadeTilesMaxima * tamanhoTile); // Determina a distância à frente para spawnar novos tiles

        // Remove os tiles que estão mais de 3 unidades atrás do jogador
        for (int i = tileListaSpawned.Count - 1; i >= 0; i--)
        {
            if (tileListaSpawned[i].transform.position.z < playerZ - (3 * tamanhoTile))
            {
                tileListaSpawned[i].SetActive(false);
                tileListaSpawned.RemoveAt(i);
            }
        }

        // Cria novos tiles à frente do jogador se necessário
        while (tileListaSpawned[tileListaSpawned.Count - 1].transform.position.z < limiteSpawn)
        {
            CriarNovoTile();
        }
    }

    private void CriarNovoTile()
    {
        int numeroRandom = Random.Range(0, tileLista.Count);
        GameObject tileCriado = Instantiate(tileLista[numeroRandom]);
        tileCriado.transform.position = new Vector3(0, 0, quantidadeTiles * tamanhoTile);
        tileListaSpawned.Add(tileCriado);

        quantidadeTiles++;
    }
}
