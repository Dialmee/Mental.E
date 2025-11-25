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

    public int[] iUpdate = new int[4] { 0, 0, 0, 0 };

    public void Upgrade(int i, PlayerManager playerManager)
    {
        if(i==9)
        {
            upgradeMaxHp();
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
    public void upgradeMaxHp()
    {
        hpMax += 2f;
    }
    public void moreHp(PlayerManager playerManager)
    {
        playerManager.hp = hpMax;
    }
    public void upgradeBullDamage()
    {
        bulletDamages += 1;
    }
    public void upgradeBullSpeed()
    {
        bulletSpeed += 1f;
    }
    public void upgradeFireRate()
    {
        fireRate += 1f;
    }
    public void upgradeMoveCd()
    {
        moveCd -= 1f;
    }
    public void upgradeRegeneration()
    {
        healthRegeneration += 0.1f;
        iUpdate[3] += 1;
    }
    public void upgradeBullRange()
    {
        if (_upBullRange >= _maxUpBullRange)
            return;

        _upBullRange += 1;
        bulletRange += 20f;
        iUpdate[2] += 1;
    }
    public void upgradeVertBullets()
    {
        int nbVerMax = 3;
        if (nbBullets[3] >= nbVerMax)
            return;
        nbBullets[0] += 1;
        nbBullets[3] += 1;
        nbBullets[4] += 1;
        iUpdate[1] += 1;
    }
    public void upgradeHorBullets()
    {
        int nbHorMax = 3;
        if (nbBullets[3] >= nbHorMax)
            return;
        nbBullets[0] += 1;
        nbBullets[1] += 1;
        nbBullets[2] += 1;
        iUpdate[0] += 1;
    }
}
