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
        PutarBadanKeMouse(); // Rotasi harus dihitung duluan biar arah majunya bener
        GerakRelatif();
    }

    // --- 1. GERAKAN POSISI (RELATIF TERHADAP MONCONG) ---
    void GerakRelatif()
    {
        float inputX = Input.GetAxis("Horizontal"); // A / D
        float inputY = Input.GetAxis("Vertical");   // W / S

        // Logika Matematika Vektor (Manual Transform):
        // W/S menggerakkan player searah "Atas/Moncong" (transform.up)
        // A/D menggerakkan player searah "Kanan-nya Player" (transform.right)
        
        Vector3 gerakMaju = transform.up * inputY;
        Vector3 gerakSamping = transform.right * inputX;

        // Gabungkan kedua vektor
        Vector3 totalGerak = (gerakMaju + gerakSamping).normalized;

        // Terapkan ke posisi
        transform.position += totalGerak * moveSpeed * Time.deltaTime;
    }

    // --- 2. GERAKAN ROTASI (MOUSE AIMING) ---
    void PutarBadanKeMouse()
    {
        if (mainCamera == null) return;

        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = transform.position.z;

        Vector3 arahPandang = (mouseWorldPos - transform.position).normalized;

        // Hadapkan sumbu Y (atas/moncong) ke arah mouse
        transform.up = arahPandang;
    }
}