using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLauncherSound : MonoBehaviour
{
    // Ajoutez un AudioClip pour le son du lancement
    public AudioClip launchSound;

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

        // Assurez-vous qu'il y a un AudioClip pour le son de lancement
        if (launchSound == null)
        {
            Debug.LogError("FoodLauncherSound: Launch sound clip is not assigned!");
        }
    }

    // Fonction appelée lors du lancement du bullet
    public void PlayLaunchSound()
    {
        // Vérifiez s'il y a un AudioClip pour le son de lancement
        if (launchSound != null)
        {
            // Jouez le son de lancement
            audioSource.PlayOneShot(launchSound);
        }
    }
}