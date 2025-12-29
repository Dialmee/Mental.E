using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.VolumeComponent;

public class ButtonSFX : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private bool bIsUpgrade = false;
    [SerializeField] private SoundManager soundManager;

    public void OnPointerEnter(PointerEventData eventData)
    {
        soundManager.PlayOneShot(soundManager.soundManagerConfig.sfxUiPointerPath);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(bIsUpgrade) 
        {
            soundManager.PlayOneShot(soundManager.soundManagerConfig.sfxUiUpgradeButtonPath);
        }
        else
        {
            soundManager.PlayOneShot(soundManager.soundManagerConfig.sfxUiClickPath);
        }
    }
}
