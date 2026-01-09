using PrimeTween;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    public bool bGameIsEnded = false;
    public GameObject GO_RestartScreen = null;
    public UpdateButton deathUpdateButton;
    public UnityEngine.UI.Image imageDeathButtonAmelioration;
    public GameObject go_deathButtonAmelioration;
    [SerializeField]private PauseManager pauseManager;
    [SerializeField] private ButtonAnim buttonAnim;
    private int iHasard(int a, int b) //Si 0 alors vaisseau ennemi, sinon asteroid
    {
        System.Random rdm = new System.Random();
        int hasard = rdm.Next(a, b + 1); //Aller jusqu'a le b inclu.
        return hasard;
    }
    public void StartDeath()
    {
        bGameIsEnded = true;
        GO_RestartScreen.SetActive(true);
    }
    public void StartAgain(bool bAmeliorationFirst)
    {
        if (bAmeliorationFirst)
        {
            int i = iHasard(0, 9);
            pauseManager.uiUpgradesConfig.iNextUpgrade = i;
            imageDeathButtonAmelioration.sprite = pauseManager.uiUpgradesConfig.sprites_update[i];
            deathUpdateButton.iNumber = i;
            if (i == 4 || i == 2 || i == 1 || i == 0)
            {
                if (i == 1 || i == 0)
                {
                    deathUpdateButton.SetTextes(pauseManager.uiUpgradesConfig.sTitleAmelioration[i], pauseManager.uiUpgradesConfig.sTextAmelioration[i], pauseManager.playerStats.fUpdatesNumbers[i], pauseManager.uiUpgradesConfig.color_text[0], true);
                }
                else
                {
                    deathUpdateButton.SetTextes(pauseManager.uiUpgradesConfig.sTitleAmelioration[i], pauseManager.uiUpgradesConfig.sTextAmelioration[i], pauseManager.playerStats.fUpdatesNumbers[i], pauseManager.uiUpgradesConfig.color_text[0], false);
                }
            }
            else if (i == 3 || i == 9 || i == 8)
            {
                if (i == 8)
                {
                    deathUpdateButton.SetTextes(pauseManager.uiUpgradesConfig.sTitleAmelioration[i], pauseManager.uiUpgradesConfig.sTextAmelioration[i], pauseManager.playerStats.fUpdatesNumbers[i], pauseManager.uiUpgradesConfig.color_text[1], true);
                }
                else
                {
                    deathUpdateButton.SetTextes(pauseManager.uiUpgradesConfig.sTitleAmelioration[i], pauseManager.uiUpgradesConfig.sTextAmelioration[i], pauseManager.playerStats.fUpdatesNumbers[i], pauseManager.uiUpgradesConfig.color_text[1], false);
                }
            }
            else
            {
                deathUpdateButton.SetTextes(pauseManager.uiUpgradesConfig.sTitleAmelioration[i], pauseManager.uiUpgradesConfig.sTextAmelioration[i], pauseManager.playerStats.fUpdatesNumbers[i], pauseManager.uiUpgradesConfig.color_text[2], false);
            }
            go_deathButtonAmelioration.transform.localScale = new Vector3(0, 0, 0);
            Debug.Log(go_deathButtonAmelioration.transform.localScale);
            buttonAnim.enabled = false;
            GO_RestartScreen.SetActive(false);
            go_deathButtonAmelioration.SetActive(true);
            Sequence.Create(useUnscaledTime: true)
            .Chain(Tween.Scale(go_deathButtonAmelioration.transform, endValue: 1, duration: 1f, ease: Ease.OutBack).OnComplete(() => buttonAnim.enabled = true));
        }
        else
        {
            pauseManager.LoaderScene(SceneManager.GetActiveScene().name);
        }
    }

}
