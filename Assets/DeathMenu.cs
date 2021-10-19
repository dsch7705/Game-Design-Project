using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public List<GameObject> disableGroup = new List<GameObject>();

    private void Start()
    {
        GameEvents.current.OnPlayerDied += Open;
        gameObject.SetActive(false);
    }

    void Open()
    {
        gameObject.SetActive(true);
        foreach (GameObject obj in disableGroup)
        {
            obj.SetActive(false);
        }

        Time.timeScale = 0f;
        gameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Close()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
