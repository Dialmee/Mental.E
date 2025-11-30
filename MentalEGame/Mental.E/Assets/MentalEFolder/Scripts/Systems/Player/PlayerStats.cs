using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    public float hpMax = 2f;
    public float healthRegeneration = 0.2f;
    public int bulletDamages = 2;
    public float bulletSpeed = 2f;
    public float bulletRange = 2f;
    public float fireRate = 2f;
    public float moveCd = 2f;
    [Tooltip("0 is forward, 1 is right, 2 is left, 3 is up, 4 is down")] public int[] nbBullets = new int[5] { 1, 0, 0, 0, 0 };
    public int iLevel = 0;
    public float fXPmax = 100f;

    private int _maxUpBullRange = 3;
    private int _upBullRange = 0;
    public float[] fUpdatesNumbers = new float[10] { 1f, 1f, 20f, 0.1f, -1f, 1f, 1f, 1f, 0f, 2f };
    public int[] iUpdate = new int[4] { 0, 0, 0, 0 };

    public void Upgrade(int i, PlayerManager playerManager)
    {
        if(i==9)
        {
            upgradeMaxHp(playerManager);
        }
        else if (i == 8)
        {
            moreHp(playerManager);
        }
        else if (i == 7)
        {
            upgradeBullDamage();
        }
        else if (i == 6)
        {
            upgradeBullSpeed();
        }
        else if (i == 5)
        {
            upgradeFireRate();
        }
        else if (i == 4)
        {
            upgradeMoveCd();
        }
        else if (i == 3)
        {
            upgradeRegeneration();
        }
        else if (i == 2)
        {
            upgradeBullRange();
        }
        else if (i == 1)
        {
            upgradeVertBullets();
        }
        else if (i == 0)
        {
            upgradeHorBullets();
        }
    }
    public void upgradeMaxHp(PlayerManager playerManager)//9
    {
        hpMax += fUpdatesNumbers[9];
        playerManager.lifeUpdate.MoreHPSlider();
    }
    public void moreHp(PlayerManager playerManager)//8
    {
        playerManager.hp = hpMax;
    }
    public void upgradeBullDamage()//7
    {
        bulletDamages += Mathf.RoundToInt(fUpdatesNumbers[7]);
    }
    public void upgradeBullSpeed()//6
    {
        bulletSpeed += fUpdatesNumbers[6];
    }
    public void upgradeFireRate()//5
    {
        fireRate += fUpdatesNumbers[5];
    }
    public void upgradeMoveCd()//4
    {
        moveCd += fUpdatesNumbers[4];
    }
    public void upgradeRegeneration()//3
    {
        healthRegeneration += 0.1f;
        iUpdate[3] += Mathf.RoundToInt(fUpdatesNumbers[3]);
    }
    public void upgradeBullRange()//2
    {
        if (_upBullRange >= _maxUpBullRange)
            return;

        _upBullRange += 1;
        bulletRange += fUpdatesNumbers[2];
        iUpdate[2] += 1;
    }
    public void upgradeVertBullets()//1
    {
        int nbVerMax = 3;
        if (nbBullets[3] >= nbVerMax)
            return;
        nbBullets[0] += Mathf.RoundToInt(fUpdatesNumbers[1]);
        nbBullets[3] += Mathf.RoundToInt(fUpdatesNumbers[1]);
        nbBullets[4] += Mathf.RoundToInt(fUpdatesNumbers[1]);
        iUpdate[1] += 1;
    }
    public void upgradeHorBullets() //0
    {
        int nbHorMax = 3;
        if (nbBullets[3] >= nbHorMax)
            return;
        nbBullets[0] += Mathf.RoundToInt(fUpdatesNumbers[0]);
        nbBullets[1] += Mathf.RoundToInt(fUpdatesNumbers[0]);
        nbBullets[2] += Mathf.RoundToInt(fUpdatesNumbers[0]);
        iUpdate[0] += 1;
    }
}
