using UnityEngine;
using UnityEngine.UI;

public class RestartActivator : MonoBehaviour
{
    [SerializeField] private WinWatcher _watcher;
    [SerializeField] private SpikeStucker _stucker;
    [SerializeField] private Text _resultText;
    [SerializeField] private GameObject _window;

    private void Awake()
    {
        _watcher.Win += ActivateWindow;
        _watcher.Win += SetCongratulations;

        _stucker.Dead += ActivateWindow;
        _stucker.Dead += SetLose;

        if(_window.activeSelf)
        {
            DeactivateWindow();
        }
    }
    private void OnDestroy()
    {
        _watcher.Win -= ActivateWindow;
        _watcher.Win -= SetCongratulations;

        _stucker.Dead -= ActivateWindow;
        _stucker.Dead -= SetLose;
    }


    private void ActivateWindow()
    {
        _window.SetActive(true);
        Time.timeScale = 0;
    }
    private void SetCongratulations()
    {
        _resultText.text = "you win!";
    }
    private void SetLose()
    {
        _resultText.text = "you lose :(";
    }

    private void DeactivateWindow()
    {
        _window.SetActive(false);
        Time.timeScale = 1;
    }
}
