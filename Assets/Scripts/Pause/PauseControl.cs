using UnityEngine;
using UnityEngine.Serialization;

public class PauseControl : MonoBehaviour
{
    private float _previousTimeScale = 1;
    [SerializeField] private GameObject pauseLabel;

    public static bool isPaused;

    private void Start()
    {
        pauseLabel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (Time.timeScale > 0)
        {
            _previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
            AudioListener.pause = true;
            pauseLabel.SetActive(true);

            isPaused = true;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = _previousTimeScale;
            AudioListener.pause = false;
            pauseLabel.SetActive(false);

            isPaused = false;
        }
    }
}
