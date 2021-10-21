using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    [SerializeField] private int fps = 75;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = fps;

        float timestep = 1f / fps;
        UnityEngine.Time.fixedDeltaTime = timestep;

        Time.timeScale = 1f;
    }

    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("[APPLICATION QUIT]");
    }
}
