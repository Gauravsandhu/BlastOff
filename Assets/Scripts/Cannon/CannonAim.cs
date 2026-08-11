using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;



public class CannonAim : MonoBehaviour
{

    //initializations
    [SerializeField] private Transform barrelTransform;
    [SerializeField] private float maxBarrelAngle = 60f;
    
    public float rotationSpeed = 250f;
    [SerializeField] private bool facingRight = true;

    [SerializeField] private CannonInput input;


    //UPDATE FUNCTION

    private void Update()
    {
        float vertical = input.GetVerticalInput();
      
        float baseAngle = facingRight ? -90f : 90f;
        float direction = facingRight ? -1f : 1f;
        float targetAngle = direction * vertical * maxBarrelAngle + baseAngle;

        // Smooth Rotation for Barrel
        if(vertical != 0f){
            float currentAngle = barrelTransform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);

            barrelTransform.localRotation = Quaternion.Euler(0f,0f,newAngle);
        }

        if(vertical == 0f)
        {
            float currentAngle = barrelTransform.eulerAngles.z;
            float restAngle = baseAngle+direction*maxBarrelAngle;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, restAngle, 100 * Time.deltaTime);
            barrelTransform.localRotation = Quaternion.Euler(0f,0f,newAngle);
        }
       
       
    }


}

