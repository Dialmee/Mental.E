using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tuto : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private GameObject go_Tuto;
    [SerializeField] private RectTransform[] tr_Bubble;
    [SerializeField] private GameObject[] go_Text;
    [SerializeField] private TextMeshProUGUI[] txt_Text;
    [SerializeField] private GameObject go_Image;
    [SerializeField] private float fDurationBubbleActivate = 0.5f;
    [SerializeField] private int iNumberBubbleToImage = 2;
    [SerializeField] private float fWaitAfterStartLevel = 1f;
    [SerializeField] private float fWaitAfterOpenScreen = 1f;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI textButton;
    private int i = 0;
    private void Start()
    {
        if(!playerStats.bTutoDone)
        {
            OpenTutoAfterSceneLoad();
        }
    }
    private void OpenTutoAfterSceneLoad()
    {
        Sequence.Create(useUnscaledTime: true) // left = rectTransform.offsetMin.x
                .ChainDelay(fWaitAfterStartLevel)
                .OnComplete(() =>
                {
                    OpenTuto(true);
                });
    }
    public void OpenTuto(bool bToOpen)
    {
        go_Tuto.SetActive(bToOpen);
        if(bToOpen)
        {
            Starttuto();
        }
    }
    private void Starttuto()
    {
        pauseManager.bIsTuto = true;
        CheckTypo();
        i = 0;
        go_Image.SetActive(false);
        textButton.text = "Next";
        foreach (GameObject go in go_Text)
        {
            go.SetActive(false);
        }
        for(int i =0; i< tr_Bubble.Length; i++)
        {
            if(i % 2 == 0) //pair => bloup
            {
                tr_Bubble[i].offsetMin = new Vector2(0f, -canvas.rect.height);
                tr_Bubble[i].offsetMax = new Vector2(0f, -canvas.rect.height);
            }
            else //impaire => player
            {
                tr_Bubble[i].offsetMin = new Vector2(0f, canvas.rect.height);
                tr_Bubble[i].offsetMax = new Vector2(0f, canvas.rect.height);
            }
        }

        SlowTime(true);
    }
    public void SlowTime(bool bToSlow)
    {
        if(bToSlow)
        {
            Tween.GlobalTimeScale(0f, fWaitAfterOpenScreen);
            Sequence.Create(useUnscaledTime: true) // left = rectTransform.offsetMin.x
                .Group(Tween.Custom(0f, 1f, fWaitAfterOpenScreen, onValueChange: newVal => canvasGroup.alpha = newVal))
            .OnComplete(() =>
            {
                pauseManager.PauseGame(true);
                NextBubble();
            });
        }
        else
        {
            Tween.GlobalTimeScale(0f, fWaitAfterOpenScreen);
            Sequence.Create(useUnscaledTime: true) // left = rectTransform.offsetMin.x
                .Group(Tween.Custom(1f, 0f, fWaitAfterOpenScreen, onValueChange: newVal => canvasGroup.alpha = newVal))
            .OnComplete(() =>
            {
                OpenTuto(false);
                if (!playerStats.bTutoDone)
                {
                    playerStats.bTutoDone = true;
                }
                pauseManager.PauseGame(false);
                pauseManager.bIsTuto = false;
            });
        }
    }
    public void NextBubble()
    {
        if(i== tr_Bubble.Length)
        {
            SlowTime(false);
        }
        else
        {
            Sequence.Create(useUnscaledTime: true) // left = rectTransform.offsetMin.x
                .Group(Tween.UIOffsetMinY(tr_Bubble[i], 0f, fDurationBubbleActivate))
                .Group(Tween.UIOffsetMaxY(tr_Bubble[i], 0f, fDurationBubbleActivate))
            .OnComplete(() =>
            {
                go_Text[i].SetActive(true);
                if(i== iNumberBubbleToImage)
                {
                    go_Image.SetActive(true);
                }
                else if (i == tr_Bubble.Length - 1)
                {
                    textButton.text = "End Tuto";
                }
                i += 1;
            });
        }
    }
    private void CheckTypo()
    {
        float fTypo = 64f;
        for(int i =0; i< txt_Text.Length; i++)
        {
            if(i==0)
            {
                fTypo = txt_Text[i].fontSize;
            }
            else
            {
                if(txt_Text[i].fontSize< fTypo)
                {
                    fTypo = txt_Text[i].fontSize;
                }
            }
        }
        foreach(TextMeshProUGUI text in txt_Text)
        {
            text.autoSizeTextContainer = false;
            text.fontSize = fTypo;
        }
    }
}
