using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public Button[] menuButtons;

    private int currentIndex = 0;

    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject creditsButton;

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject mainMenuButtons;

    void Start()
    {
        LoadMainMenu();
    }

    public void LoadGameplayScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadCredits()
    {
        mainMenuPanel.SetActive(false);
        mainMenuButtons.SetActive(false);

        creditsPanel.SetActive(true);
        creditsButton.SetActive(true);
    }

    public void LoadMainMenu()
    {
        creditsPanel.SetActive(false);
        creditsButton.SetActive(false);

        mainMenuPanel.SetActive(true);
        mainMenuButtons.SetActive(true);
    }
}
