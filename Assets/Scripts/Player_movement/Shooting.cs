using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Variabel publik untuk menampung Prefab Peluru. Wajib dihubungkan di Inspector.
    public GameObject bulletPrefab;

    // Cooldown: Waktu tunggu (dalam detik) antar tembakan. 0.5f = 2 peluru per detik.
    public float fireRate = 0.5f;

    // Variabel pribadi untuk melacak kapan tembakan berikutnya diperbolehkan.
    private float nextFireTime = 0f;

    void Update()
    {
        // 1. Cek Cooldown: Pastikan waktu sekarang (Time.time) lebih besar 
        //    dari waktu tembakan berikutnya yang dijadwalkan (nextFireTime).
        // 2. Cek Input: Pastikan tombol Spasi baru saja ditekan (Input.GetKeyDown).
        if (Time.time > nextFireTime && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();

            // Jadwalkan waktu tembakan berikutnya (Waktu sekarang + Cooldown)
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Fungsi utama untuk menembak:
        // Membuat salinan (Instantiate) dari Prefab Peluru
        // Muncul di: Posisi Meriam (transform.position)
        // Dengan Rotasi: Rotasi Meriam (transform.rotation)
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}