using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject Go_this;

    void Awake()
    {
        if (Go_this == null)
        {
            Go_this = this.gameObject;
        }
        NotHovered();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Sequence.Create(useUnscaledTime: true)
            .Chain(Tween.Scale(Go_this.transform, 0.9f, 0.6f));
    }
    public void OnMouseDown()
    { //useUnscaledTime: true
        Sequence.Create(useUnscaledTime: true)
            .Chain(Tween.Scale(Go_this.transform, 0.8f, 0.2f))
            .Chain(Tween.Scale(Go_this.transform, 1f, 0.4f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Sequence.Create(useUnscaledTime: true)
            .Chain(Tween.Scale(Go_this.transform, 0.8f, 0.2f))
            .Chain(Tween.Scale(Go_this.transform, 1f, 0.4f));
    }

    public void NotHovered()
    {
        Go_this.transform.localScale = Vector3.one;
    }
}
