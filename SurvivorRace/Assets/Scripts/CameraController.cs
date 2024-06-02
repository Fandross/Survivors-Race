using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variaveis
    public GameObject jogadorRef;

    // Atualizar a camera a cada frame
    void Update()
    {
        transform.LookAt(jogadorRef.transform);
    }
}
