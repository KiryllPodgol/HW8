using UnityEngine;

public class ParallaxEffectLoop : MonoBehaviour
{
    public GameObject cam;
    float startPosX;
    public float Parallax;

    private void Start()
    {
        startPosX = transform.position.x;
    }

    private void Update()
    {
        float distX = (cam.transform.position.x * (1 - Parallax));
        transform.position = new Vector3(startPosX + distX, transform.position.y, transform.position.z);
    }
}
