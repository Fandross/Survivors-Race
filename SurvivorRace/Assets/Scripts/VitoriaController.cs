using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VitoriaController : MonoBehaviour
{
    public TextMeshProUGUI pontosText;
    public TextMeshProUGUI estrelasText;

    void Start()
    {
        int pontos = PlayerPrefs.GetInt("Pontos", 0);
        int estrelas = PlayerPrefs.GetInt("Estrelas", 0);

        pontosText.text = "Humanos restante: " + pontos.ToString();
        estrelasText.text = "Estrelas: " + estrelas.ToString();
    }
}
