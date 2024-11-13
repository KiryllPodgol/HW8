using UnityEngine;

public class TestParallax : MonoBehaviour
{
    public GameObject[] backgroundLayers;    // ������ ����� ����
    public float[] parallaxSpeeds;           // �������� ���������� ��� ������� ����
    private Vector3[] initialPositions;      // ��������� ������� �����

    private Camera mainCamera;
    private float screenHalfWidth;

    void Start()
    {
        mainCamera = Camera.main;
        screenHalfWidth = mainCamera.orthographicSize * mainCamera.aspect; // �������� ������ ������ ��� ������

        // ������������� ��������� ������� ��� ������� ����
        initialPositions = new Vector3[backgroundLayers.Length];
        for (int i = 0; i < backgroundLayers.Length; i++)
        {
            initialPositions[i] = backgroundLayers[i].transform.position;
        }

        // ��������, ��� � ������� ���� ���� ��������������� ��������
        if (parallaxSpeeds.Length != backgroundLayers.Length)
        {
            parallaxSpeeds = new float[backgroundLayers.Length];
            for (int i = 0; i < parallaxSpeeds.Length; i++)
            {
                parallaxSpeeds[i] = 0.1f * (i + 1); // ��������� �������� ��� ����������
            }
        }
    }

    void Update()
    {
        for (int i = 0; i < backgroundLayers.Length; i++)
        {
            // ������� ���� ����� �� ��� �������� ����������
            backgroundLayers[i].transform.position += Vector3.left * parallaxSpeeds[i] * Time.deltaTime;

            // ���������, ����� �� ���� �� ����� ������� ������
            float layerRightEdge = backgroundLayers[i].transform.position.x + (backgroundLayers[i].GetComponent<SpriteRenderer>().bounds.size.x / 2);
            if (layerRightEdge < mainCamera.transform.position.x - screenHalfWidth)
            {
                // ���������� ���� ������, �� ������� ���������
                backgroundLayers[i].transform.position = new Vector3(
                    initialPositions[i].x + screenHalfWidth * 2,
                    backgroundLayers[i].transform.position.y,
                    backgroundLayers[i].transform.position.z
                );
            }
        }
    }
}
