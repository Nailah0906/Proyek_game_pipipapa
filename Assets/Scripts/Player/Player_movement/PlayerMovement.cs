using UnityEngine;

public class Player_movement : MonoBehaviour
{
    [Header("Pengaturan Player")]
    public float moveSpeed = 7f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        GerakBebas();      // WASD = Atas Bawah Kiri Kanan (Tetap)
        PutarKeMouse();    // Mouse = Arah Moncong
    }

    // --- 1. GERAKAN POSISI (WORLD SPACE) ---
    void GerakBebas()
    {
        float inputX = Input.GetAxis("Horizontal"); // A / D
        float inputY = Input.GetAxis("Vertical");   // W / S

        Vector3 arahGerak = new Vector3(inputX, inputY, 0).normalized;

        transform.position += arahGerak * moveSpeed * Time.deltaTime;
    }

    // --- 2. GERAKAN ROTASI (MOUSE AIMING) ---
    void PutarKeMouse()
    {
        if (mainCamera == null) return;

        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = transform.position.z; 

        Vector3 arahPandang = (mouseWorldPos - transform.position).normalized;

        transform.up = arahPandang;
    }
}