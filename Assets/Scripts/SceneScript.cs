using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject gameStart;
    [SerializeField] GameObject[] level_thing;

    [SerializeField] GameObject buttonStart;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void StartLevel()
    {
        gameStart.SetActive(false);
        buttonStart.SetActive(false);
        foreach (var i in level_thing)
            i.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Scene_1");
    }
}
