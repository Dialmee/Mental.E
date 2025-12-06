using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

public class NewLevel : MonoBehaviour
{
    [SerializeField] private RectTransform rect_Text;
    [SerializeField] private UnityEngine.UI.Image imBlack;
    [SerializeField] private Color32 colorBlack;
    [SerializeField] private float fDurationTextSwap = 0.5f;
    [SerializeField] private float fDurationTextStay = 1f;
    [SerializeField] private float fDurationBlackFade = 0.5f;
    [SerializeField] private GameObject GO_levelingUpdate = null;
    public void NewLevelIn()
    {
        Tween.GlobalTimeScale(0f, fDurationBlackFade + fDurationTextSwap *2 + fDurationTextStay);
        Sequence.Create(useUnscaledTime: true) // left = rectTransform.offsetMin.x
            .Group(Tween.UIOffsetMinX(rect_Text, 0f, fDurationTextSwap))
            .ChainDelay(fDurationTextStay)
            .Chain(Tween.UIOffsetMinX(rect_Text, 5000f, fDurationTextSwap)) //Custom(Color.white, Color.black, duration: 1, onValueChange: newVal => colorField = newVal)
            .Group(Tween.Custom(new Color32(0, 0, 0, 0), colorBlack, fDurationBlackFade, onValueChange: newVal => imBlack.color = newVal))
        .OnComplete(() =>
        {
            GO_levelingUpdate.SetActive(true);
            rect_Text.gameObject.SetActive(false);
        });
    }
    private void OnEnable()
    {
        rect_Text.offsetMin = new Vector2(-5000f,0f);
        rect_Text.gameObject.SetActive(true);
        imBlack.gameObject.SetActive(true);
        imBlack.color = new Color32(0, 0, 0, 0);
    }
}
