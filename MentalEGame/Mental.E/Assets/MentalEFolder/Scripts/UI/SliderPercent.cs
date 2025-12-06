using TMPro;
using UnityEngine;

public class SliderPercent : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private UnityEngine.UI.Slider slider;
    public void ValueChange()
    {
        text.text = Mathf.RoundToInt(slider.value*100).ToString()+"%";
    }
}
