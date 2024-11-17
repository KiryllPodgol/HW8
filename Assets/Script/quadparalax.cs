using UnityEngine;

public class QuadParallax : MonoBehaviour
{
    // Scroll speed added to all backgrounds 
    public float additionalScrollSpeed;
    // An array of all the background game objects
    public GameObject[] backgrounds;
    // An array that corresponds to the backgrounds array, where it gives the scroll speed for each individual background
    public float[] scrollSpeed;
    // Reference to the player character
    public GameObject player;

    // Direction of parallax movement (-1 for left, 1 for right)
    private float direction = 1; // по умолчанию направо

    private void Update()
    {
      

        // Change direction on a single press of Space or screen tap
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction *= -1; // toggle direction

            // Flip the player character
            Vector3 playerScale = player.transform.localScale;
            playerScale.x *= -1;
            player.transform.localScale = playerScale;
        }
    }

    private void FixedUpdate()
    {
        // Loop through array of objects, making scrolling occur for each
        for (int background = 0; background < backgrounds.Length; background++)
        {
            // Get the renderer for this item in the array
            Renderer rend = backgrounds[background].GetComponent<Renderer>();
            // Calculate the scroll offset based on direction and speed
            float offset = Time.time * (scrollSpeed[background] + additionalScrollSpeed) * direction;
            // Offset the texture of this item based on the offset calculated
            rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
