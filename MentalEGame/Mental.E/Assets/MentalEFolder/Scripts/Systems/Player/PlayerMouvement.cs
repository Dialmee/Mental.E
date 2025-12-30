using UnityEngine;
using UnityEngine.InputSystem;
using PrimeTween;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Animator rollAnimator;
    [SerializeField] private InputAction horMove;
    [SerializeField] private InputAction verMove;

    [SerializeField] private float fHorMove = 10f;
    [SerializeField] private float fVerMove = 8f;

    [SerializeField] private float moveSpeed = 15;

    [SerializeField] private int maxVerAxe = 2;
    [SerializeField] private int maxHorAxe = 2;

    private int iVerAxe = 1; 
    private int iHorAxe = 1;
    public bool bIsMoving = false;
    public bool bCanMove = true;
    public float fTimeToMoveAgain = 5f;
    public float fCurrentTimer = 5f;

    private Vector3 _nextPos;
    private Vector2 _dir;



    private void OnEnable()
    {
        fTimeToMoveAgain = playerManager.ps.moveCd;
        fCurrentTimer = fTimeToMoveAgain;
        bCanMove = true;
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
        ResetRoll();

        if (bCanMove)
        {
            InputDetection();
        }
        else
        {
            fTimeToMoveAgain = playerManager.ps.moveCd;
            fCurrentTimer += Time.deltaTime;
            if(fCurrentTimer>=fTimeToMoveAgain)
            {
                bCanMove = true;
            }
        }
            Move();
    }

    private void InputDetection()
    {
        if (horMove.WasPerformedThisFrame())
        {
            CalculateNewPlace(horMove.ReadValue<float>(), false);
        }

        if(verMove.WasPerformedThisFrame())
        {
            CalculateNewPlace(verMove.ReadValue<float>(), true);
        }
    }


    private void CalculateNewPlace(float dir, bool isVertical)
    {
        if (bIsMoving)
            return;
        
        bIsMoving = true;
        bCanMove = false;
        fCurrentTimer = 0;
        if (!isVertical && ((Mathf.Sign(dir) < 0 && iHorAxe > 0) || (Mathf.Sign(dir) > 0 && iHorAxe < maxHorAxe)))
        {
            _nextPos = new Vector3(transform.position.x + Mathf.Sign(dir) * fHorMove, transform.position.y, transform.position.z);
            iHorAxe += Mathf.RoundToInt(Mathf.Sign(dir));
            _dir = Vector2.right * dir;
        }
        else
        if (isVertical && ((Mathf.Sign(dir) < 0 && iVerAxe > 0) || (Mathf.Sign(dir) > 0 && iVerAxe < maxVerAxe)))
        {
            _nextPos = new Vector3(transform.position.x, transform.position.y + Mathf.Sign(dir) * fVerMove, transform.position.z);
            iVerAxe += Mathf.RoundToInt(Mathf.Sign(dir));
            _dir = Vector2.up * dir;
        }

        Roll();
    }

    private void Move()
    {
        if (!bIsMoving) {
            return;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _nextPos, moveSpeed * Time.deltaTime);

        if (playerManager.pauseManager.soundManager != null)
        {
            playerManager.pauseManager.soundManager.PlayOneShot(playerManager.pauseManager.soundManager.soundManagerConfig.sfxLazerGunPath, Vector3.zero);
        }
        else
        {
            Debug.LogWarning("no sound manager");
        }

        if (transform.position == _nextPos)
            bIsMoving = false;
            

    }
    private void Roll()
    {
        if (_dir == Vector2.right)
            rollAnimator.SetBool("rollRight", true);
        else 
        if (_dir == Vector2.left)
            rollAnimator.SetBool("rollLeft", true);
        else 
        if (_dir == Vector2.up)
            rollAnimator.SetBool("rollUp", true);
        else 
        if (_dir == Vector2.down)
            rollAnimator.SetBool("rollDown", true);
    }
    private void ResetRoll()
    {
        rollAnimator.SetBool("rollRight", false);
        rollAnimator.SetBool("rollLeft", false);
        rollAnimator.SetBool("rollUp", false);
        rollAnimator.SetBool("rollDown", false);
    }


    public int getiAxe()
    {
        return iHorAxe + ((2-iVerAxe)*3);
    }


}
