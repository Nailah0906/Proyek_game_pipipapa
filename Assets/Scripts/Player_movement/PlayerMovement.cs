using UnityEngine;

public class Player_movement : MonoBehaviour
{
    // Kecepatan Meriam
    public float speed = 7f;

    void Update()
    {
        // 1. Dapatkan Input Horizontal (Nilai antara -1 dan 1)
        float horizontalInput = Input.GetAxis("Horizontal");

        // 2. Hitung Perpindahan
        // Time.deltaTime digunakan untuk pergerakan yang mulus
        Vector3 movement = Vector3.right * horizontalInput * speed * Time.deltaTime;

        // 3. Terapkan Perpindahan
        transform.Translate(movement);
    }
}