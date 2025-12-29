using TMPro;
using UnityEngine;

public class SliderPercent : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private UnityEngine.UI.Slider slider;
    [SerializeField] private VolumeChanger volumeChanger;

    private void OnEnable()
    {
        text.text = Mathf.RoundToInt(slider.value * 100).ToString() + "%";
        volumeChanger.VolumeChange();
    }
    public void ValueChange()
    {
        text.text = Mathf.RoundToInt(slider.value*100).ToString()+"%";
        volumeChanger.VolumeChange();
    }
}
