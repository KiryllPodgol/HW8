using UnityEngine;

public class QuadParallax : MonoBehaviour
{
   
    public float additionalScrollSpeed;

  
    public GameObject[] backgrounds;


    public float[] scrollSpeed;

    public GameObject player;

    // Направление движения (-1 влево, 1 вправо)
    private float direction = 1;

    private SpriteRenderer playerSpriteRenderer;

    private void Start()
    {
    
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction *= -1; 

            if (playerSpriteRenderer != null)
            {
                playerSpriteRenderer.flipX = direction == -1;
            }
        }
    }

    private void FixedUpdate()
    {
      
        for (int background = 0; background < Mathf.Min(backgrounds.Length, scrollSpeed.Length); background++)
        {
            Renderer rend = backgrounds[background].GetComponent<Renderer>();
            if (rend != null)
            {
              
                float offset = Time.time * (scrollSpeed[background] + additionalScrollSpeed) * direction;
                
                rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            }
        }
    }
}
