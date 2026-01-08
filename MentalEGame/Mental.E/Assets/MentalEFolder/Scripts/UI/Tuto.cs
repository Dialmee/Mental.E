using NUnit.Framework.Internal;
using UnityEngine;
using PrimeTween;
using UnityEngine.UI;
using TMPro;

public class Tuto : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PauseManager pauseManager;
    [SerializeField] private RectTransform canvas;
    [SerializeField] private GameObject go_Tuto;
    [SerializeField] private RectTransform[] tr_Bubble;
    [SerializeField] private GameObject[] go_Text;
    [SerializeField] private GameObject go_Image;
    [SerializeField] private float fDurationBubbleActivate = 0.5f;
    [SerializeField] private int iNumberBubbleToImage = 2;
    [SerializeField] private float fWaitAfterStartLevel = 2f;
    [SerializeField] private float fWaitAfterOpenScreen = 1f;
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
        pauseManager.PauseGame(true);
        pauseManager.bIsTuto = true;
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
        Sequence.Create(useUnscaledTime: true) // left = rectTransform.offsetMin.x
                .ChainDelay(fWaitAfterOpenScreen)
                .OnComplete(() =>
                {
                    NextBubble();
                });
    }
    public void NextBubble()
    {
        if(i== tr_Bubble.Length)
        {
            OpenTuto(false);
            if (!playerStats.bTutoDone)
            {
                playerStats.bTutoDone = true;
            }
            pauseManager.PauseGame(false);
            pauseManager.bIsTuto = false;

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
}
