using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    [SerializeField] public AudioSource levelMusic;
    [SerializeField] int sceneNumber;
    [SerializeField] Text scoreText;
    private int score;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeScene(sceneNumber);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }



    public void UpdateScore(int pointValue)
    {
        score += pointValue;
        scoreText.text = "Score: " + score.ToString();
    }
    
    public void panelManager(GameObject screen)
    {
        screen.SetActive(true);
        levelMusic.Stop();

        Time.timeScale = 0;
    }


    public void ChangeScene(int sceneNumber)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneNumber);
    }
}
