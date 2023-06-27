
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

    private void Awake()
    {
        path = Application.dataPath + "/Saves/GameState.json";

        if (!File.Exists(path))
        {
            resumeButtonBackground.GetComponent<SpriteRenderer>().color = Color.gray;
            resumeText.GetComponent<TMP_Text>().color = Color.gray;
        }
    }

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

    public void ResumeButton()
    {
        if (File.Exists(path))
        {
            SceneManager.LoadScene(1);
        }  
    }

    public void ExitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
 
