using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private SpawnAxe[] spawnAxes = new SpawnAxe[9];
    [SerializeField]private PlayerMouvement playerMouvement;
    [SerializeField] private PlayerManager playerManager;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform tr_ProjectilParent;
    [SerializeField] private List<GameObject> GO_Projectil = new List<GameObject>(10);
    private int iCurrentProjectil = 0;
    private float[] fTimer = new float[5] {0f,0f,0f,0f,0f };

    private void Update()
    {
        if(!playerManager.playerMouvement.bIsMoving)
        {
            CheckFoeInDirection();
        }
    }
    private void Shoot(Transform target)
    {
        if(target!=null)
        {
            CheckProjectilEnable();
            GO_Projectil[iCurrentProjectil].SetActive(true);
            PlayerProjectile proj = GO_Projectil[iCurrentProjectil].GetComponent<PlayerProjectile>();
            proj.target = target;
            proj.playerTr = this.transform;
            proj.iDamage = playerManager.ps.bulletDamages;
            proj.fSpeed = playerManager.ps.bulletSpeed;
            iCurrentProjectil += 1;
        }
    }
    private void CheckProjectilEnable()
    {
        if (iCurrentProjectil >= GO_Projectil.Count && GO_Projectil[0].activeInHierarchy)
        {
            GO_Projectil.Add(Instantiate(GO_Projectil[0], this.transform.position, Quaternion.identity, tr_ProjectilParent));
        }
        else if (iCurrentProjectil >= GO_Projectil.Count)
        {
            iCurrentProjectil = 0;
        }
    }
    private void CheckFoeInDirection()
    {
        if (playerManager.ps.nbBullets[0] != 0) //forward
        {
            fTimer[0] += Time.deltaTime;
            if (fTimer[0] > playerManager.ps.fireRate)
            {
                Transform target = spawnAxes[playerMouvement.iAxe].WhatFoe();
                if(target != null)
                {
                    Shoot(target);
                    fTimer[0] = 0f;
                }
            }
        }
        if (playerManager.ps.nbBullets[1] != 0 && playerMouvement.iAxe != 2 && playerMouvement.iAxe != 5 && playerMouvement.iAxe != 8) //right
        {
            fTimer[1] += Time.deltaTime;
            if (fTimer[1] > playerManager.ps.fireRate)
            {
                Transform target = spawnAxes[playerMouvement.iAxe + 1].WhatFoe();
                if(target != null)
                {
                    Shoot(target);
                    fTimer[1] = 0f;
                }
            }
        }
        if (playerManager.ps.nbBullets[2] != 0 && playerMouvement.iAxe != 0 && playerMouvement.iAxe != 3 && playerMouvement.iAxe != 6) //left
        {
            fTimer[2] += Time.deltaTime;
            if (fTimer[2] > playerManager.ps.fireRate)
            {
                Transform target = spawnAxes[playerMouvement.iAxe - 1].WhatFoe();
                if (target != null)
                {
                    Shoot(target);
                    fTimer[2] = 0f;
                }
            }
        }
        if (playerManager.ps.nbBullets[3] != 0 && playerMouvement.iAxe >2) //up
        {
            fTimer[3] += Time.deltaTime;
            if (fTimer[3] > playerManager.ps.fireRate)
            {
                Transform target = spawnAxes[playerMouvement.iAxe - 3].WhatFoe();
                if (target != null)
                {
                    Shoot(target);
                    fTimer[3] = 0f;
                }
            }
        }
        if (playerManager.ps.nbBullets[4] != 0 && playerMouvement.iAxe < 6) //down
        {
            fTimer[4] += Time.deltaTime;
            if (fTimer[4] > playerManager.ps.fireRate)
            {
                Transform target = spawnAxes[playerMouvement.iAxe + 3].WhatFoe();
                if (target != null)
                {
                    Shoot(target);
                    fTimer[4] = 0f;
                }
            }
        }
    }
}
