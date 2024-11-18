using UnityEngine;

public class QuadParallax : MonoBehaviour
{
    // Скорость прокрутки, добавляемая ко всем фонам
    public float additionalScrollSpeed;

    // Массив с объектами фона
    public GameObject[] backgrounds;

    // Массив скоростей прокрутки, соответствующих каждому фону
    public float[] scrollSpeed;

    // Ссылка на персонажа игрока
    public GameObject player;

    // Направление движения (-1 влево, 1 вправо)
    private float direction = 1;

    // Ссылка на компонент SpriteRenderer игрока
    private SpriteRenderer playerSpriteRenderer;

    private void Start()
    {
        // Инициализируем SpriteRenderer игрока
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // Изменение направления движения и поворота персонажа при нажатии на пробел или левую кнопку мыши
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction *= -1; // Меняем направление

            // Меняем поворот игрока
            if (playerSpriteRenderer != null)
            {
                playerSpriteRenderer.flipX = direction == -1; // Включаем flipX, если направление влево
            }
        }
    }

    private void FixedUpdate()
    {
        // Обрабатываем прокрутку для каждого фона
        for (int background = 0; background < Mathf.Min(backgrounds.Length, scrollSpeed.Length); background++)
        {
            Renderer rend = backgrounds[background].GetComponent<Renderer>();
            if (rend != null)
            {
                // Вычисляем смещение
                float offset = Time.time * (scrollSpeed[background] + additionalScrollSpeed) * direction;
                // Устанавливаем смещение текстуры
                rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            }
        }
    }
}
