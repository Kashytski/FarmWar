using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (Player == null)
                SceneManager.LoadScene("Scene_1");
            else Application.Quit();
    }
}
