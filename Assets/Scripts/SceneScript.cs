using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject gameStart;
    [SerializeField] GameObject[] level_thing;
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (Player == null)
                SceneManager.LoadScene("Scene_1");
            else Application.Quit();

        if (Input.GetKeyDown(KeyCode.S))
        {
            gameStart.SetActive(false);
            foreach (var i in level_thing)
                i.SetActive(true);
        }
    }
}
