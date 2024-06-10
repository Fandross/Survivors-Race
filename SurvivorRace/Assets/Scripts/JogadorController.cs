using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JogadorController : MonoBehaviour
{
    public GameObject playerPrefab;
    private Rigidbody playerRigidbody;
    public float velocidade = 30f;
    public float velocidadeMaxima = 50f;
    public float velocidadeGiro = 150f;
    public Text debug;
    public int pontos = 0;
    public int estrelas = 0;
    public int pontosParaGanharEstrela = 5;

    public HumanManager humanManager;

    void Start()
    {
        playerRigidbody = playerPrefab.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float movimentoGiro = eixoX * velocidadeGiro * Time.deltaTime;
        Quaternion rotacao = Quaternion.Euler(0f, movimentoGiro, 0f);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * rotacao);

        Vector3 movimento = transform.forward * velocidade * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + movimento);

        debug.text = "Pontos: " + pontos.ToString() + "Estrelas: " + estrelas.ToString();
    }
 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Humano"))
        {
            pontos++;
            humanManager.RemoveHuman(collision.gameObject);
        }

        if (collision.CompareTag("Hospital"))
        {
            //estrelas = pontos / pontosParaGanharEstrela;
            if (pontos > 5)
            {
                estrelas += pontos / 5;
                pontos -= 5;
                
            }
        }
        debug.text = "Pontos: " + pontos.ToString() + "Estrelas: " + estrelas.ToString();
    }

}
