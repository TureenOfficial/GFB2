using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public GameObject SelectCanvas;
    public string namescene;
    public GameObject MainCanvas;
    public GameObject OpenFlarpCanvas;
    public GameObject CreditCanvas;
    public GameObject LoadingCanvas;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OpenMyFlarp()
    {
        OpenFlarpCanvas.SetActive(true);
    }
    public void OpenCredits()
    {
        CreditCanvas.SetActive(true);
    }
    public void ReturnSpecific()
    {
        SelectCanvas.SetActive(false);
        MainCanvas.SetActive(true);
    }
    public void ReturnToMain()
    {
        SelectCanvas.SetActive(false);
        OpenFlarpCanvas.SetActive(false);
        MainCanvas.SetActive(true);
        CreditCanvas.SetActive(false);
    }
    public void PlayMain()
    {
        SelectCanvas.SetActive(false);
        LoadingCanvas.SetActive(true);
        Invoke(nameof(LoadScene), 1f);
    }
    private void LoadScene()
    {
        SceneManager.LoadScene("FlarpMain");
    }
    public void CustomSceneChange()
    {
        SceneManager.LoadScene(namescene);
    }
    public void PlaySelect()
    {
        SelectCanvas.SetActive(true);
        MainCanvas.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void XPLevelMenu()
    {
        SceneManager.LoadScene("LevelMenu");
    }
    public void Options()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
}
