using UnityEngine;

public class PauseControl : MonoBehaviour
{
    private float _previousTimeScale = 1;
    [SerializeField] private GameObject _pauseLabel;

    public static bool IsPaused;

    private void Start()
    {
        _pauseLabel.SetActive(false);
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
            _pauseLabel.SetActive(true);

            IsPaused = true;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = _previousTimeScale;
            AudioListener.pause = false;
            _pauseLabel.SetActive(false);

            IsPaused = false;
        }
    }
}
