using UnityEngine;

public class creditsScrolling : MonoBehaviour
{
    [SerializeField] private RectTransform rectCanvas;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GameObject[] Go_Title;
    [SerializeField] private GameObject[] Go_Text;
    [Tooltip("one is title, two is text")][SerializeField] private float[] fHeight = new float[2];
    [SerializeField] private float fSpeed = 1f;
    private float fAdd = 0f;
    private float fMaxHeight = 0f;
    [SerializeField] private GameObject GO_BackButton = null;
    [SerializeField] private RectTransform Canvas_model = null;
    [SerializeField] private RectTransform Canvas_toChange = null;
    private void Start()
    {
        Canvas_toChange.sizeDelta = new Vector2(Canvas_model.sizeDelta.x, Canvas_model.sizeDelta.y);
        fAdd = -rectCanvas.rect.height;
        /*Top*/
        rectTransform.offsetMax = new Vector2(0f, fAdd);
        fMaxHeight = Go_Title.Length * fHeight[0] + Go_Text.Length * fHeight[1];
    }
    private void OnEnable()
    {
        GO_BackButton.SetActive(true);
        fAdd = -rectCanvas.rect.height;
        /*Top*/
        rectTransform.offsetMax = new Vector2(0f, fAdd);
    }
    private void Update()
    {
        fAdd += Time.unscaledDeltaTime * fSpeed;
        rectTransform.offsetMax = new Vector2(0f, fAdd);
        if (fAdd >= fMaxHeight)
        {
            fAdd = -rectCanvas.rect.height;
            rectTransform.offsetMax = new Vector2(0f, fAdd);
        }
    }
    private void OnDisable()
    {
        GO_BackButton.SetActive(false);
    }
}
