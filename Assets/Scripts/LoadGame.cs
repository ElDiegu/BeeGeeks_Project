using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    int currentLevel = 0;
    private void Awake()
    {
        LoadFile();
    }
    public void GoToGame()
    {
        switch (currentLevel)
        {
            case 0:
                SceneManager.LoadScene("DialogueLevel1");
                break;
            case 1:
                SceneManager.LoadScene("Level_1");
                    break;
            case 2:
                SceneManager.LoadScene("Level_2");
                break;
            case 3:
                SceneManager.LoadScene("Level_3");
                break;
        }
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        currentLevel = (int)bf.Deserialize(file);
        file.Close();

        Debug.Log(currentLevel);
    }
}
