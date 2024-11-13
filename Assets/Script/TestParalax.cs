using UnityEngine;

public class TestParallax : MonoBehaviour
{
    public GameObject[] backgroundLayers;    // Массив слоев фона
    public float[] parallaxSpeeds;           // Скорости параллакса для каждого слоя
    private Vector3[] initialPositions;      // Начальные позиции слоев

    private Camera mainCamera;
    private float screenHalfWidth;

    void Start()
    {
        mainCamera = Camera.main;
        screenHalfWidth = mainCamera.orthographicSize * mainCamera.aspect; // Половина ширины экрана для камеры

        // Инициализация начальных позиций для каждого слоя
        initialPositions = new Vector3[backgroundLayers.Length];
        for (int i = 0; i < backgroundLayers.Length; i++)
        {
            initialPositions[i] = backgroundLayers[i].transform.position;
        }

        // Убедимся, что у каждого слоя есть соответствующая скорость
        if (parallaxSpeeds.Length != backgroundLayers.Length)
        {
            parallaxSpeeds = new float[backgroundLayers.Length];
            for (int i = 0; i < parallaxSpeeds.Length; i++)
            {
                parallaxSpeeds[i] = 0.1f * (i + 1); // Примерные значения для параллакса
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < backgroundLayers.Length; i++)
        {
            // Смещаем слой влево на его скорость параллакса
            backgroundLayers[i].transform.position += Vector3.left * parallaxSpeeds[i] * Time.deltaTime;

            // Проверяем, вышел ли слой за левую границу камеры
            float layerRightEdge = backgroundLayers[i].transform.position.x + (backgroundLayers[i].GetComponent<SpriteRenderer>().bounds.size.x / 2);
            if (layerRightEdge < mainCamera.transform.position.x - screenHalfWidth)
            {
                // Перемещаем слой вправо, за пределы видимости
                backgroundLayers[i].transform.position = new Vector3(
                    initialPositions[i].x + screenHalfWidth * 2,
                    backgroundLayers[i].transform.position.y,
                    backgroundLayers[i].transform.position.z
                );
            }
        }
    }
}
