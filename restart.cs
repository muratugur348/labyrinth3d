using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour
{
// Start is called before the first frame update
    void Start()
    {
        audioSource.volume = float.Parse(sesdegeri.name);
    resume.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public UnityEngine.UI.Image pause;
    public UnityEngine.UI.Image resume;
    public GameObject sphere;
    public Material sesdegeri;
    public AudioSource audioSource;
    public void PauseGame()
    {
        if (sphere.GetComponent<Renderer>().material.GetColor("_Color") == new Color(0, 1, 0))
        { }
        else if (sphere.GetComponent<Renderer>().material.GetColor("_Color") == new Color(1, 0, 0))
        { }
        else
        {
            Time.timeScale = 0;
            pause.enabled = false;
            resume.enabled = true;
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;

        pause.enabled = true;
        resume.enabled = false;
    }
    public int isPlaying = 0;
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        Time.timeScale = 1;
        

    }
}
