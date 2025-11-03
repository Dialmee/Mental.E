using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] private InputAction horMove;
    [SerializeField] private InputAction verMove;



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
        transform.position= new Vector3(transform.position.x + Mathf.Sign(horDir)*15, transform.position.y, transform.position.z);
    }

    private void changeStage(float verDir)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sign(verDir) * 10, transform.position.z);
    }
}
