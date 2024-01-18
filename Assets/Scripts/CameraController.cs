using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");    
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -30);
    }
}
