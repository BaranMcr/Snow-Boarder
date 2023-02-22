using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // sahne y�netimi

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();  // ba�ka dosyadan method �a��rmak
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", loadDelay); // sahneyi tekrar ba�latmak i�in
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0); // 0 indexli(ilk) sahneyi tekrar ba�latmak i�in
    }
}
