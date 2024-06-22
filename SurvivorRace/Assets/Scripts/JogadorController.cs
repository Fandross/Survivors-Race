using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public Slider sliderVelocidade;
    public Slider sliderVelocidadeGiro;
    public bool isSliderAtivos;
    public TextMeshProUGUI textoVelocidade;
    public TextMeshProUGUI textoVelocidadeGiro;

    public HumanManager humanManager;

    void Start()
    {
        isSliderAtivos = false;
        playerRigidbody = playerPrefab.GetComponent<Rigidbody>();

        // Inicializa os valores dos sliders
        sliderVelocidade.value = velocidade;
        sliderVelocidadeGiro.value = velocidadeGiro;

        // Adiciona listeners para os sliders
        sliderVelocidade.onValueChanged.AddListener(delegate { AjustarVelocidade(); });
        sliderVelocidadeGiro.onValueChanged.AddListener(delegate { AjustarVelocidadeGiro(); });
    }

    void FixedUpdate()
    {
        float eixoX = Input.GetAxis("Horizontal");

        // Movimento usando o acelerômetro
        if (SystemInfo.supportsAccelerometer)
        {
            Vector3 aceleracao = Input.acceleration;
            eixoX = aceleracao.x; 
        }

        float movimentoGiro = eixoX * velocidadeGiro * Time.deltaTime;
        Quaternion rotacao = Quaternion.Euler(0f, movimentoGiro, 0f);
        playerRigidbody.MoveRotation(playerRigidbody.rotation * rotacao);

        Vector3 movimento = transform.forward * velocidade * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + movimento);

        debug.text = "Humanos: " + pontos.ToString() + " Estrelas: " + estrelas.ToString();
        if (pontos >= 50 || estrelas >= 5)
        {
            SalvarDados();
            SceneManager.LoadScene("CenaVitoria");
        }

        // Verificar Configuracao
        if (isSliderAtivos == true)
        {
            sliderVelocidade.gameObject.SetActive(isSliderAtivos);
            sliderVelocidadeGiro.gameObject.SetActive(isSliderAtivos);
        } else if(isSliderAtivos == false)
        {
            sliderVelocidade.gameObject.SetActive(isSliderAtivos);
            sliderVelocidadeGiro.gameObject.SetActive(isSliderAtivos);
        }

        // Verificar a altura do jogador
        if (transform.position.y > 10 || transform.position.y < -10)
        {
            SceneManager.LoadScene("CenaGameOver");

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Humano"))
        {
            pontos++;
            humanManager.RemoveHuman(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Hospital"))
        {
            if (pontos >= pontosParaGanharEstrela)
            {
                estrelas += pontos / pontosParaGanharEstrela;
                pontos %= pontosParaGanharEstrela; // Atualiza pontos com o restante
            }
        }

        debug.text = "Humanos: " + pontos.ToString() + " Estrelas: " + estrelas.ToString();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ParedeInvisivel"))
        {

            playerRigidbody.velocity = Vector3.zero;
        }
        if(collision.gameObject.CompareTag("Obstaculo"))
        {
            SceneManager.LoadScene(2);
        }
    }

    private void AjustarVelocidade()
    {
        velocidade = sliderVelocidade.value;
        textoVelocidade.text = "Velocidade: " + velocidade.ToString("F2");
    }

    private void AjustarVelocidadeGiro()
    {
        velocidadeGiro = sliderVelocidadeGiro.value;
        textoVelocidadeGiro.text = "Velocidade de Giro: " + velocidadeGiro.ToString("F2");
    }

    private void SalvarDados()
    {
        PlayerPrefs.SetInt("Pontos", pontos);
        PlayerPrefs.SetInt("Estrelas", estrelas);
        PlayerPrefs.Save();
    }
    public void ativarSlider()
    {
        isSliderAtivos = !isSliderAtivos;
    }
}
