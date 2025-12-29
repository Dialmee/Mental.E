using UnityEngine;

public class SettingsSoundActivator : MonoBehaviour
{
    [SerializeField]private PauseManager pauseManager;
    private void OnEnable()
    {
        pauseManager.soundManager.PausedVolume(false);
    }
    private void OnDisable()
    {
        pauseManager.soundManager.PausedVolume(true);
    }
}
