using UnityEngine;

public class Shooting : MonoBehaviour
{
    [Header("Pengaturan Senjata")]
    public Transform firePoint;     
    public GameObject bulletPrefab; 
    public float fireRate = 0.5f;   

    private float nextFireTime = 0f;

    void Update()
    {
        if (Time.time > nextFireTime && Input.GetButtonDown("Fire1"))
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (firePoint == null) return;

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}