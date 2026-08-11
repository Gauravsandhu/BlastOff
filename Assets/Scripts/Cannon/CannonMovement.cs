using Unity.GraphToolkit.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CannonInput))]
public class CannonMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;

    private CannonInput input;

    private void Awake()
    {
        input = GetComponent<CannonInput>();
    }

    private void Update()
    {

        bool canMove = GameManager.Instance.CurrentState == GameState.RoundLive;
       
        if(canMove){
        float vertical = input.GetVerticalInput();
        Vector3 pos = transform.position;
        pos.y += vertical * moveSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
        }
    }
}