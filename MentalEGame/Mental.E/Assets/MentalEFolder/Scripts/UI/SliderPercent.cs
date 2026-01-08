using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class SliderPercent : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image imageSlider;
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private VolumeChanger volumeChanger;

    private void OnEnable()
    {
        text.text = Mathf.RoundToInt(slider.value * 100).ToString() + "%";
        Color32 color = new Color(0f, slider.value, 1f, 1f);
        text.color = color;
        Color32 color2 = new Color(1f, slider.value, 1f, 1f);
        imageSlider.color = color2;
        volumeChanger.VolumeChange();
    }
    public void ValueChange()
    {
        text.text = Mathf.RoundToInt(slider.value*100).ToString()+"%";
        Color32 color = new Color(0f, slider.value, 1f, 1f);
        text.color = color;
        Color32 color2 = new Color(1f, slider.value, 1f, 1f);
        imageSlider.color = color2;
        volumeChanger.VolumeChange();
    }
}
