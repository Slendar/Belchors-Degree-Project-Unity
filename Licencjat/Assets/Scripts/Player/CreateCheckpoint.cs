using UnityEngine;

public class CreateCheckpoint : MonoBehaviour
{
    [System.NonSerialized]public Vector2 checkpoint;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.collider.name)
        {
            case "Ground Left":
                checkpoint.Set(1f, 1.6f);
                break;
            case "Platform Water":
                checkpoint.Set(9.5f, 5f);
                break; 
            case "Ground Middle":
                if(checkpoint.y != 20.3f) { 
                    checkpoint.Set(19f, 1.55f);
                }
                break;
            case "Platform Lava":
                checkpoint.Set(28.5f, 5.1f);
                break;
            case "Ground Right":
                checkpoint.Set(37f, 1.55f);
                break;
            case "World Upper Ground Left":
                checkpoint.Set(-4f, 16.55f);
                break;
            case "Cloud Left":
                checkpoint.Set(10f, 20.3f);
                break;
            case "Cloud Right":
                checkpoint.Set(28f, 20.3f);
                break;
            case "World Upper Ground Right":
                checkpoint.Set(42f, 16.55f);
                break; 
        }
    }
}
