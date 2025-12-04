using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Pengaturan Senjata")]
    public Transform firePoint;     // <-- INI BARU: Titik moncong meriam
    public GameObject bulletPrefab; // Cetakan Peluru
    public float fireRate = 0.5f;   // Jeda tembakan

    private float nextFireTime = 0f;

    void Update()
    {
        // GANTI INPUT: Dari "Space" jadi "Fire1" (Klik Kiri Mouse)
        // Biar enak dimainkan bareng mouse aiming.
        if (Time.time > nextFireTime && Input.GetButtonDown("Fire1"))
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // PENTING: Cek dulu FirePoint ada atau gak, biar gak error
        if (firePoint == null) return;

        // GANTI POSISI:
        // Muncul di: firePoint.position (Ujung Moncong)
        // Rotasi: firePoint.rotation (Mengikuti arah moncong)
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}