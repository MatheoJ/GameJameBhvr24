using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlideController : MonoBehaviour
{
    public GameObject[] slides; // Tableau contenant les références aux panels UI
    private int currentSlideIndex = 0; // Index du panel UI actuellement affiché

    public void ShowNextSlide()
    {
        // Masquer le panel UI actuel
        slides[currentSlideIndex].SetActive(false);

        // Augmenter l'index du panel UI actuel pour passer au suivant
        currentSlideIndex++;

        // Vérifier si l'index dépasse la taille du tableau
        if (currentSlideIndex >= slides.Length)
        {
            currentSlideIndex = 0; // Revenir au premier panel UI si l'index dépasse
        }

        // Afficher le nouveau panel UI
        slides[currentSlideIndex].SetActive(true);
    }

    public void ShowPreviousSlide()
    {
        // Masquer le panel UI actuel
        slides[currentSlideIndex].SetActive(false);

        // Diminuer l'index du panel UI actuel pour revenir au précédent
        currentSlideIndex--;

        // Vérifier si l'index est inférieur à zéro
        if (currentSlideIndex < 0)
        {
            currentSlideIndex = slides.Length - 1; // Aller au dernier panel UI si l'index est inférieur à zéro
        }

        // Afficher le nouveau panel UI
        slides[currentSlideIndex].SetActive(true);
    }

     public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("StartScene"); // Charger la scène spécifiée
    }

}
