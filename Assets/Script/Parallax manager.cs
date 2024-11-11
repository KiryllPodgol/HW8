using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    public static ParallaxManager Instance; 
    public float virtualPositionX;         
    private void Start()
    {
     
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void SetVirtualPosition(float newPosition)
    {
        virtualPositionX = newPosition; 
    }

    public void MoveVirtualPosition(float delta)
    {
        virtualPositionX += delta; 
    }
}
