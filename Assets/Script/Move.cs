using UnityEngine;

public class Move : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool isFlipped = false; // ���� ��� ������������ �������� ��������� ��������

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            isFlipped = !isFlipped; // ����������� ��������� �����
            spriteRenderer.flipX = isFlipped; // ������������ ��������� � ����������� �� ��������� �����
        }
    }
}
