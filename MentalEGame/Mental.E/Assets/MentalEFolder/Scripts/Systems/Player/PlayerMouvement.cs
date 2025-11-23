using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] private InputAction horMove;
    [SerializeField] private InputAction verMove;
    public int iAxe = 4;


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


    private void changeLane(float horDir)
    {
        if((Mathf.Sign(horDir)<0 && iAxe !=0 && iAxe != 3 && iAxe != 6) || (Mathf.Sign(horDir) > 0 && iAxe != 2 && iAxe != 5 && iAxe != 8))
        {
            transform.position = new Vector3(transform.position.x + Mathf.Sign(horDir) * 15, transform.position.y, transform.position.z);
            iAxe += Mathf.RoundToInt(Mathf.Sign(horDir) * 1);
        }
    }

    private void changeStage(float verDir)
    {
        if ((Mathf.Sign(verDir) < 0 && iAxe<6) || (Mathf.Sign(verDir) > 0 && iAxe > 2))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sign(verDir) * 10, transform.position.z);
            iAxe -= Mathf.RoundToInt(Mathf.Sign(verDir) * 3);
        }
    }
}
