
// This class contains functions related to the main menu of the game.

using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject resumeButtonBackground;
    [SerializeField] private GameObject resumeText;

    string path;

    // Sets the color of the continue button to gray and its text to gray if the game state file which is save file does not exist.
    private void Awake()
    {
        path = Application.dataPath + "/Saves/GameState.json";

        if (!File.Exists(path))
        {
            resumeButtonBackground.GetComponent<SpriteRenderer>().color = Color.gray;
            resumeText.GetComponent<TMP_Text>().color = Color.gray;
        }
    }

    // The StartButton method is called when the start button is clicked.
    // If the game state file which is save file exists, it deletes the file.
    // It then sets the initial resource values ​​and loads the game scene.
    public void StartButton()
    {
        try
        {
            if (File.Exists(path))
                File.Delete(path);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while deleting the JSON file: " + ex.Message);
        }

        ResourcesManager.ownedGold = 10;
        ResourcesManager.ownedGem = 10;

        SceneManager.LoadScene(1);
    }

    // The ResumeButton method is called when the resume button is clicked.
    // Loads the game scene from where it left off if the game state file which is save file exists.
    public void ResumeButton()
    {
        if (File.Exists(path))
        {
            SceneManager.LoadScene(1);
        }  
    }

    // The Exit Button method is called when the exit button is clicked. The game is stopped.
    public void ExitButton()
    {

    }

    // This function for the Sound button. The SoundOnOff method opens and closes the soundtrack that is playing background.
    public void SoundOnOff()
    {
        if (GameObject.FindGameObjectWithTag("SoundtrackManager").GetComponent<AudioSource>().enabled)
            GameObject.FindGameObjectWithTag("SoundtrackManager").GetComponent<AudioSource>().enabled = false;
        else
            GameObject.FindGameObjectWithTag("SoundtrackManager").GetComponent<AudioSource>().enabled = true;
    }
}
 
