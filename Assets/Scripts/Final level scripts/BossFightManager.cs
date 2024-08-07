using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightManager : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject door;
    public GameManager Manager;



    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Manager.panelManager(startPanel);
    }


    private void Update()
    {
        if (boss != null && boss.GetComponent<EnemyHealth>().health <= 0)
        {
            door.SetActive (false);
            Manager.levelMusic.Stop();
        }
    }


   public void QuitPause()
    {
        Time.timeScale = 1;
        Manager.levelMusic.Play();
        startPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }
}
