using UnityEngine;
using UnityEngine.UI;

public class XPUpdate : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private PlayerManager playerManager;
    private void Start()
    {
        ChangeUI();
    }

    public void ChangeUI()
    {
        slider.value = playerManager.fXP / playerManager.ps.fXPmax;
    }
}
