using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.VolumeComponent;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField]
    private PauseManager pauseManager;
    [SerializeField]
    private VolumeType volumeType;

    [SerializeField]
    private UnityEngine.UI.Slider thisSlider;
    private void Start()
    {
        pauseManager.soundManager.PreResetVolume(volumeType);
        ResetVolume();
    }
    private void OnEnable()
    {
        pauseManager.soundManager.PreResetVolume(volumeType);
        ResetVolume();
    }
    private void ResetVolume()
    {
        switch (volumeType)
        {
            case VolumeType.None:
                return;
            case VolumeType.Music:
                thisSlider.value = pauseManager.soundManager.fPlayingVolume;
                break;
            case VolumeType.Sfx:
                thisSlider.value = pauseManager.soundManager.soundManagerConfig.fVolumeSfx;
                break;
        }
    }
    public void VolumeChange()
    {
        pauseManager.soundManager.ChangeVolume(volumeType, thisSlider.value);
        switch (volumeType)
        {
            case VolumeType.None:
                return;
            case VolumeType.Music:
                pauseManager.soundManager.fPlayingVolume = thisSlider.value;
                break;
        }
    }
}
