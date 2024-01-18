using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // TODO caprazlara giderken hiz kok 2 oluyor olabilir, buna bak
        Vector3 movement = new Vector3(horizontalInput, verticalInput).normalized;
        transform.Translate(movement * Time.deltaTime * speed);
    }
}
