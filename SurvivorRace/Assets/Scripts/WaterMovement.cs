using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    public float speed = 0.1f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * speed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, offset));
    }
}
