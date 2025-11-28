using UnityEngine;
using UnityEngine.InputSystem;
using PrimeTween;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField]private PlayerManager playerManager;
    [SerializeField] private InputAction horMove;
    [SerializeField] private InputAction verMove;
    public int iAxe = 4;
    public bool bIsMoving = false;


    private void OnEnable()
    {
        horMove.Enable();
        verMove.Enable();
    }

    private void OnDisable()
    {
        horMove.Disable();
        verMove.Disable();
    }

    void Update()
    {
        InputDetection();
        CheckBugPosition();
    }

    private void InputDetection()
    {

        if (horMove.WasPerformedThisFrame())
        {
            changeLane(horMove.ReadValue<float>());
        }

        if(verMove.WasPerformedThisFrame())
        {
            changeStage(verMove.ReadValue<float>());
        }
    }

    //TO DO : meilleure anim si possible
    private void changeLane(float horDir)
    {
        if((Mathf.Sign(horDir)<0 && iAxe !=0 && iAxe != 3 && iAxe != 6) || (Mathf.Sign(horDir) > 0 && iAxe != 2 && iAxe != 5 && iAxe != 8))
        {
            //transform.position = new Vector3(transform.position.x + Mathf.Sign(horDir) * 15, transform.position.y, transform.position.z);
            bIsMoving = true;
            Tween.PositionX(transform, endValue: transform.position.x + Mathf.Sign(horDir) * 15, duration: playerManager.ps.moveCd, ease: Ease.InOutSine)
            .OnComplete(() => { iAxe += Mathf.RoundToInt(Mathf.Sign(horDir) * 1); bIsMoving = false; CheckBugPosition(); });
        }
    }
    private void changeStage(float verDir)
    {
        if ((Mathf.Sign(verDir) < 0 && iAxe<6) || (Mathf.Sign(verDir) > 0 && iAxe > 2))
        {
            //transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sign(verDir) * 10, transform.position.z);
            bIsMoving = true;
            Tween.PositionY(transform, endValue: transform.position.y + Mathf.Sign(verDir) * 10, duration: playerManager.ps.moveCd, ease: Ease.InOutSine)
            .OnComplete(() => { iAxe -= Mathf.RoundToInt(Mathf.Sign(verDir) * 3); bIsMoving = false; CheckBugPosition(); });
        }
    }
    //TO DO : la verif n'est pas de ouf fonctionnel #Sad
    private void CheckBugPosition()
    {
        Vector3 playerPos = transform.position;
        if (!bIsMoving && playerPos.x != 15 && playerPos.x != -15 && playerPos.x != 0 && playerPos.y != 0 && playerPos.y != 10 && playerPos.y != 20)
        {
            Debug.LogWarning("ERROR POSITION");
            if (iAxe == 0)
            {
                transform.position = new Vector3(-15f, 20f, transform.position.z);
            }
            else if (iAxe == 1)
            {
                transform.position = new Vector3(0f, 20f, transform.position.z);
            }
            else if (iAxe == 2)
            {
                transform.position = new Vector3(15f, 20f, transform.position.z);
            }
            else if (iAxe == 3)
            {
                transform.position = new Vector3(-15f, 10f, transform.position.z);
            }
            else if (iAxe == 4)
            {
                transform.position = new Vector3(0f, 10f, transform.position.z);
            }
            else if (iAxe == 5)
            {
                transform.position = new Vector3(15f, 10f, transform.position.z);
            }
            else if (iAxe == 6)
            {
                transform.position = new Vector3(-15f, 0f, transform.position.z);
            }
            else if (iAxe == 7)
            {
                transform.position = new Vector3(0f, 0f, transform.position.z);
            }
            else if (iAxe == 8)
            {
                transform.position = new Vector3(15f, 0f, transform.position.z);
            }
        }
    }
}
