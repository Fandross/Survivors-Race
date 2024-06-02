using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    // Variaveis
    public GameObject tileBase;
    public List<GameObject> tileLista;
    public List<GameObject> tileListaDesert;
    public int tamanhoTile = 10;
    private int quantidadeTiles = 0;
    public int quantidadeTilesMaxima = 10;

    private void Awake()
    {
        // Gerador de Tile apartir de uma lista de tiles com uma quantidade maxima
            Instantiate<GameObject>(tileBase);
            while (quantidadeTiles <= quantidadeTilesMaxima)
            {
                int numeroRandom = Random.Range(0, tileLista.Count);
                GameObject tileCriado = Instantiate<GameObject>(tileLista[numeroRandom]);
                tileCriado.GetComponent<Transform>().position = new Vector3(0, 0, tamanhoTile * quantidadeTiles);
                quantidadeTiles++;
            }
    }
}
