using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public bool startFromTV;
    public float timeToMove;
    public float masterVolume;
    public float masterBrightness;
    public bool DebugMode;
    public int maxFps = 144;

    public int[] levelStars;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            levelStars = new int[100];
            _instance = this;
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = maxFps;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (DebugMode)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void LoadScenewithDelay(string sceneName, float delay)
    {
        StartCoroutine(LoadScene(sceneName, delay));
    }

    public IEnumerator LoadScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);

        yield return null;
    }
}





