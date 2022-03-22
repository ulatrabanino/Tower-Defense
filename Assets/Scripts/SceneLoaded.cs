using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoaded : MonoBehaviour
{
    Button start;
    bool hasStarted = true;
    public static SceneLoaded loader = null;
    // Start is called before the first frame update
    private void Awake()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (loader == null)
        {
            DontDestroyOnLoad(this.gameObject);
            loader = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (this != loader) return;

        if (!hasStarted)
        {
            if (this == null) return;
            start = GameObject.Find("Start").GetComponent<Button>();
            start.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else { Time.timeScale = 0; }
    }

    public void ReloadScene()
    {
        hasStarted = false;
        SceneManager.LoadScene("SampleScene");
    }
}
