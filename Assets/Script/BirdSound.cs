using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSound : MonoBehaviour
{
    public AudioClip[] alertSounds; // Tableau de clips audio pour les sons 
    public AudioClip[] raceSounds; // Tableau de clips audio pour les sons de chaque race d'oiseau

    private AudioSource audioSource;
    private WAZO wazoScript;
    private UnityEngine.AI.NavMeshAgent agent;
    private float previousSpeed;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        wazoScript = GetComponent<WAZO>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        previousSpeed = agent.speed;

        // S'assurer que les composants nécessaires sont attachés
        if (audioSource == null || wazoScript == null || agent == null)
        {
            Debug.LogError("BirdSound: AudioSource, WAZO, or NavMeshAgent component is missing!");
            return;
        }

        // Jouer un son spécifique à la race d'oiseau lorsqu'il est créé
        PlayRaceSound(wazoScript.wazoRace);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (agent.speed > previousSpeed)
        {
            
            HandleSpeedAlert();
        }

        
        previousSpeed = agent.speed;
    }

    
    void HandleSpeedAlert()
    {
        
        if (alertSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, alertSounds.Length);
            audioSource.PlayOneShot(alertSounds[randomIndex]);
        }
    }

    // Jouer un son spécifique à la race d'oiseau
    void PlayRaceSound(WazoRace race)
    {
        
        if (raceSounds.Length == 0)
        {
            Debug.LogWarning("BirdSound: No race sounds assigned!");
            return;
        }

        // Déterminer l'index du son de race correspondant à la race de l'oiseau
        int raceIndex = (int)race;

        
        if (raceIndex < 0 || raceIndex >= raceSounds.Length || raceSounds[raceIndex] == null)
        {
            Debug.LogWarning("BirdSound: Race sound not assigned for this race!");
            return;
        }

        // Jouer le son de race correspondant
        audioSource.PlayOneShot(raceSounds[raceIndex]);
    }
}