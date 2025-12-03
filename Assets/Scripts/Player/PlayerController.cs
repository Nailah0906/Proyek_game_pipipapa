using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Camera mainCamera;
    private Vector2 movement;
    private Vector2 mousePos;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        ManualMovement();
        ManualRotation();
    }

    private void ManualMovement()
    {
        Vector3 displacement = new Vector3(movement.x, movement.y, 0).normalized * moveSpeed * Time.deltaTime;
        transform.position += displacement;
    }

    private void ManualRotation()
    {
        Vector2 lookDir = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}