using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class XPUpdate : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private PlayerManager playerManager;
    private void Start()
    {
        ChangeUIStart();
    }

    public void ChangeUI()
    {
        // Animate 'floatField' from 0 to 10 in 1 second
        Tween.Custom(slider.value, playerManager.fXP / playerManager.ps.fXPmax, duration: 2, onValueChange: newVal => slider.value = newVal);
        //slider.value = playerManager.fXP / playerManager.ps.fXPmax;
    }
    public void ChangeUIStart()
    {
        slider.value = playerManager.fXP / playerManager.ps.fXPmax;
    }
}
