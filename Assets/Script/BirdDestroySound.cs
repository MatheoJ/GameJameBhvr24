using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdDestroySound : MonoBehaviour
{
    // Ajoutez un AudioClip pour le son de destruction
    public AudioClip destructionSound;

    // Ajoutez un AudioSource pour jouer le son
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Assurez-vous qu'il y a un AudioSource attaché à ce GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assurez-vous qu'il y a un AudioClip pour le son de destruction
        if (destructionSound == null)
        {
            Debug.LogError("BirdDestroySound: Destruction sound clip is not assigned!");
        }
    }

    // Fonction appelée lorsque l'oiseau est détruit
    void OnDestroy()
    {
        // Vérifiez s'il y a un AudioClip pour le son de destruction
        if (destructionSound != null)
        {
            // Jouez le son de destruction
            audioSource.PlayOneShot(destructionSound);
        }
    }
}