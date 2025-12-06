using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.VolumeComponent;

public class ButtonSFX : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private SoundManager soundManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        soundManager.PlayOneShot(soundManager.soundManagerConfig.sfxUiPointerPath);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        soundManager.PlayOneShot(soundManager.soundManagerConfig.sfxUiClickPath);
    }
}
