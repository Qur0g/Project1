using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;

public class SceneController : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void NextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
            SceneManager.LoadScene("Level" + SceneManager.GetActiveScene().buildIndex);

        else
            SceneManager.LoadScene("Levels");          
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void SelectLevel()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        SceneManager.LoadScene("Level" + obj.GetComponentInChildren<TextMeshProUGUI>().text);
    }
}
