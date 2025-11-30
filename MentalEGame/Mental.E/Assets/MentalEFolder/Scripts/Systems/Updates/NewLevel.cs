using PrimeTween;
using UnityEngine;
using UnityEngine.UI;

public class NewLevel : MonoBehaviour
{
    [SerializeField] private RectTransform rect_Text;
    [SerializeField] private UnityEngine.UI.Image imBlack;
    [SerializeField] private Color32 colorBlack;
    [SerializeField] private float fDuration = 1f;
    [SerializeField] private GameObject GO_levelingUpdate = null;
    public void NewLevelIn()
    {
        Tween.GlobalTimeScale(0f, 3f);
        Sequence.Create(useUnscaledTime: true) // left = rectTransform.offsetMin.x
            .Group(Tween.UIOffsetMinX(rect_Text, 0f, fDuration / 2f))
            .ChainDelay(1f)
            .Chain(Tween.UIOffsetMinX(rect_Text, 5000f, fDuration / 2f)) //Custom(Color.white, Color.black, duration: 1, onValueChange: newVal => colorField = newVal)
            .Group(Tween.Custom(new Color32(0, 0, 0, 0), colorBlack, fDuration, onValueChange: newVal => imBlack.color = newVal))
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
