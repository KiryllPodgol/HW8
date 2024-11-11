using UnityEngine;

public class Move : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            spriteRenderer.flipX = true; // Поворачиваем персонажа влево
        }
        else if (Input.GetKey(KeyCode.D))
        {
            spriteRenderer.flipX = false; // Поворачиваем персонажа вправо
        }
    }
}

