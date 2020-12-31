using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void toMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void toGame()
    {
        SceneManager.LoadScene(1);
    }

    public void toBadEnd()
    {

    }

    public void toGoodEnd()
    {

    }

    public void toQuitGame()
    {
        // From https://forum.unity.com/threads/how-to-detect-application-quit-in-editor.344600/
        // If we are running in a standalone build of the game
// #if UNITY_STANDALONE
//         // Quit the application
//         Application.Quit();
// #endif
 
//         // If we are running in the editor
// #if UNITY_EDITOR
//         // Stop playing the scene
//         UnityEditor.EditorApplication.isPlaying = false;
// #endif
        SceneManager.LoadScene(4);
    }
}
