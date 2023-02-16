using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerController player;

    public float followCameraCloseness;
    public Vector2 homePosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        Vector2 cameraPosition = Vector2.LerpUnclamped(homePosition, player.transform.position, followCameraCloseness);
        transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10);
    }
}
