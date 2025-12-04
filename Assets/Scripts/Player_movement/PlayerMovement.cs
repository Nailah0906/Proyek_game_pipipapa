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

        // LOGIKA BARU:
        // Kita pakai Vector3(x, y, 0) murni.
        // W akan selalu nambah Y (Ke Atas Layar), biarpun meriam lagi nungging.
        Vector3 arahGerak = new Vector3(inputX, inputY, 0).normalized;

        // Terapkan posisi (Manual Transform)
        transform.position += arahGerak * moveSpeed * Time.deltaTime;
    }

    // --- 2. GERAKAN ROTASI (MOUSE AIMING) ---
    void PutarKeMouse()
    {
        if (mainCamera == null) return;

        // Ambil posisi mouse di dunia game
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);
        mouseWorldPos.z = transform.position.z; // Samakan Z biar akurat

        // Hitung arah dari Player ke Mouse
        Vector3 arahPandang = (mouseWorldPos - transform.position).normalized;

        // Terapkan Rotasi
        // Asumsi: Gambar meriam menghadap ke ATAS.
        // Kalau gambarmu menghadap KANAN, ganti transform.up jadi transform.right
        transform.up = arahPandang;
    }
}