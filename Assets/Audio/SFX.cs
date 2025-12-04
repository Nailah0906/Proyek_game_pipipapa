using UnityEngine;

public class AudioConnector : MonoBehaviour
{
    // Ini adalah slot baru di Inspector Anda
    public AudioClip MusikLatar; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        // Hubungkan AudioClip dari script ke AudioSource
        if (MusikLatar != null)
        {
            audioSource.clip = MusikLatar;
            audioSource.Play();
            audioSource.loop = true; // Jika ini untuk BGM
        }
    }
}