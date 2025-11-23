using UnityEngine;
using UnityEngine.UI;

public class LifeUpdate : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField]private PlayerManager playerManager;

    public void ChangeUI()
    {
        slider.value = playerManager.hp / playerManager.ps.hpMax;
    }
}
