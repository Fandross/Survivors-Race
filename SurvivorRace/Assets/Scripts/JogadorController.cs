using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JogadorController : MonoBehaviour
{
    // Variaveis
    public Rigidbody playerRigidbody;
    public float velocidade = 10f;
    public float velocidadeMaxima = 50f;
    public float velocidadeGiro = 150f;
    public Text debug;

    // Executado uma vez somente no primeiro frame
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Executado uma vez em todos os frames
    void Update()
    {
        // Rotacao
        float eixoX = Input.GetAxis("Horizontal");
        float movimentoGiro = eixoX * velocidadeGiro * Time.deltaTime;
        Quaternion rotacao = Quaternion.Euler(0f, movimentoGiro, 0f);
        // Update na rotacao
        playerRigidbody.MoveRotation(playerRigidbody.rotation * rotacao);

        // Movimento
        Vector3 movimento = transform.forward * velocidade * Time.deltaTime;
        // Update Movimento
        playerRigidbody.MovePosition(playerRigidbody.position + movimento);


        // Debugs
        debug.text = movimentoGiro.ToString();
    }
}
