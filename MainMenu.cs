using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour {

    public Button Start;
    public Button Load;
    public Button Quit;

    //Name der zu ladenen Scene einfügen in Unity Reinschreiben!
    public string newGameSceneName;

    //Load Game Menu
    public GameObject loadGameMenu;

    // Läd neue Scene
    public void NewGame()
    {
        SceneManager.LoadScene(newGameSceneName);
    }

    // Öffnet den Lade Menü Tab 
    public void OpenLoadMenuPanel()
    {
        loadGameMenu.SetActive(true);
    }
    // Öffnet den Lade Menü Tab 
    public void CloseLoadMenuPanel()
    {
        loadGameMenu.SetActive(false);
    }


    // Schiest das Spiel (Funktionirt nur wenn Compeliert)
    public void ExitGame()
    {
        Debug.Log("Exit Game funktionirt nicht im Editor!");
        Application.Quit();
    }

}
