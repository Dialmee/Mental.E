using UnityEngine;
using UnityEngine.UI;
using PrimeTween;

public class LifeUpdate : MonoBehaviour
{
    [SerializeField] private float fSpeedMoreHp = 2f;
    [SerializeField] private RectTransform rectTrLife;
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField]private PlayerManager playerManager;

    public void ChangeUI()
    {
        slider.value = playerManager.hp / playerManager.ps.hpMax;
    }
    public void MoreHPSlider()
    {
        if(rectTrLife.anchorMax.x < 1f)
        {
            Tween.UIAnchorMax(rectTrLife, new Vector2(rectTrLife.anchorMax.x + 0.1f, 1), fSpeedMoreHp)
                .Group(Tween.UIOffsetMax(rectTrLife, Vector2.zero, fSpeedMoreHp))
                .Group(Tween.UIOffsetMin(rectTrLife, Vector2.zero, fSpeedMoreHp));
            //rectTrLife.anchorMax = new Vector2(rectTrLife.anchorMax.x + 0.1f, 1);
        }
    }
}
