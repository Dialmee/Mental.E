using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class UpdateButton : MonoBehaviour
{
    [SerializeField] private TMP_Text textTitle = null;
    [SerializeField] private TMP_Text text = null;
    [SerializeField] private TMP_Text textUpgrade = null;
    [SerializeField] private GameObject GO_levelingUpdate = null;
    [SerializeField] private GameObject GO_newLevel = null;
    [SerializeField] private GameObject GO_newLevelBlackBackground = null;
    public int iNumber = 0;
    public void Upgrading(PlayerManager playerManager)
    {
        playerManager.ps.Upgrade(iNumber, playerManager);
        GO_levelingUpdate.SetActive(false);
        GO_newLevelBlackBackground.SetActive(false);
        GO_newLevel.SetActive(false);
    }
    public void SetTextes(string sTitle, string sText, float fNumber, Color color, bool bTransparent)
    {
        textTitle.text = sTitle;
        text.text = sText;
        text.color = color;
        if(!bTransparent)
        {
            textUpgrade.color = color;
        }
        else
        {
            textUpgrade.color = new Color32(0,0,0,0);
        }
        if (fNumber > 0)
        {
            textUpgrade.text = "+ " + fNumber;
        }
        else
        {
            textUpgrade.text = fNumber.ToString();
        }
    }
}
