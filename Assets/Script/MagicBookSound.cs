using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBookSound : MonoBehaviour
{
    public AudioSource soundEffect; // Référence à l'AudioSource pour le son à jouer
    public float scrollThreshold = 0.1f; // Seuil de mouvement de la molette de la souris pour déclencher le son

    void Start()
    {
        // Assurez-vous que l'AudioSource est attaché à cet objet ou à un autre objet accessible depuis l'inspecteur Unity
        if (soundEffect == null)
        {
            Debug.LogError("Veuillez attacher un AudioSource à ce script.");
        }
    }

    void Update()
    {
        // Récupération du mouvement de la molette de la souris
        float mouseScroll = Input.mouseScrollDelta.y;

        // Si le mouvement de la molette de la souris dépasse le seuil défini
        if (Mathf.Abs(mouseScroll) > scrollThreshold)
        {
            // Vérifier si l'AudioSource est valide et prêt à jouer un son
            if (soundEffect != null && !soundEffect.isPlaying)
            {
                // Jouer le son
                soundEffect.Play();
            }
        }
    }
}