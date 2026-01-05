using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelingUpdate : MonoBehaviour
{
    [SerializeField] private uiUpgradesConfig uiUpgradesConfig;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private UnityEngine.UI.Image[] imageButtonAmelioration = new UnityEngine.UI.Image[3];
    [SerializeField] private UpdateButton[] buttonAmelioration = new UpdateButton[3];
    private int[] i_ = new int[3];
    private int iHasard(int a, int b) //Si 0 alors vaisseau ennemi, sinon asteroid
    {
        System.Random rdm = new System.Random();
        int hasard = rdm.Next(a, b + 1); //Aller jusqu'a le b inclu.
        return hasard;
    }
    private void OnEnable()
    {
        playerManager.pauseManager.PauseGame(true);
        ThreeChosenOnes();
        ButtonUpdates();
    }
    private void ButtonUpdates()
    {
        for(int i = 0; i<3; i++)
        {
            imageButtonAmelioration[i].sprite = uiUpgradesConfig.sprites_update[i_[i]];
            buttonAmelioration[i].iNumber = i_[i];
            if(i_[i] == 4 || i_[i] == 2 || i_[i] == 1 || i_[i] == 0)
            {
                if(i_[i] == 1 || i_[i] == 0)
                {
                    buttonAmelioration[i].SetTextes(uiUpgradesConfig.sTitleAmelioration[i_[i]], uiUpgradesConfig.sTextAmelioration[i_[i]], playerManager.ps.fUpdatesNumbers[i_[i]], uiUpgradesConfig.color_text[0], true);
                }
                else
                {
                    buttonAmelioration[i].SetTextes(uiUpgradesConfig.sTitleAmelioration[i_[i]], uiUpgradesConfig.sTextAmelioration[i_[i]], playerManager.ps.fUpdatesNumbers[i_[i]], uiUpgradesConfig.color_text[0], false);
                }
            }
            else if (i_[i] == 3 || i_[i] == 9 || i_[i] == 8)
            {
                if(i_[i] == 8)
                {
                    buttonAmelioration[i].SetTextes(uiUpgradesConfig.sTitleAmelioration[i_[i]], uiUpgradesConfig.sTextAmelioration[i_[i]], playerManager.ps.fUpdatesNumbers[i_[i]], uiUpgradesConfig.color_text[1], true);
                }
                else
                {
                    buttonAmelioration[i].SetTextes(uiUpgradesConfig.sTitleAmelioration[i_[i]], uiUpgradesConfig.sTextAmelioration[i_[i]], playerManager.ps.fUpdatesNumbers[i_[i]], uiUpgradesConfig.color_text[1], false);
                }
            }
            else
            {
                buttonAmelioration[i].SetTextes(uiUpgradesConfig.sTitleAmelioration[i_[i]], uiUpgradesConfig.sTextAmelioration[i_[i]], playerManager.ps.fUpdatesNumbers[i_[i]], uiUpgradesConfig.color_text[2], false);
            }
        }
    }
    private List <int> int_ten()
    {
        List <int> list = new List <int>();
        for(int i = 0; i < 10; i++)
        {
            if(i < playerManager.ps.iUpdate.Length && playerManager.ps.iUpdate[i] < 3)
            {
                list.Add(i);
            }
            else
            {
                list.Add(i);
            }
        }
        return list;
    }
    private void ThreeChosenOnes()
    {
        List<int> list = int_ten();
        for (int i =0; i<3; i++)
        {
            int index = iHasard(0, list.Count - i);
            i_[i] = list[index];
            list.RemoveAt(index);
        }
    }
    private void OnDisable()
    {
        playerManager.pauseManager.PauseGame(false);
    }
}
