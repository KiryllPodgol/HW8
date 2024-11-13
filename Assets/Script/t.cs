using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestPx : MonoBehaviour
{
    public GameObject[] background;
    public Transform player;            // Изменено на public
    public Transform StartPlayerPos;     // Изменено на public
    public float movingSpeed;            // Изменено на public

    // Update is called once per frame
    void Update()
    {
        if (player != null && StartPlayerPos != null)
        {
            for (int i = 0; i < background.Length; i++)
            {
                background[i].transform.position = new Vector3(
                    (player.position.x - StartPlayerPos.position.x) * movingSpeed * i,
                    background[i].transform.position.y,
                    background[i].transform.position.z
                );
            }
        }
    }
}
