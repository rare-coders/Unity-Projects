using UnityEngine;

public class DragManager : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    Transform endPointTop; //Boundry On Top

    [SerializeField]
    Transform endPointBottom; //Boundry on Bottom;

    Vector3 inputVector;
    Vector3 unclampedVector;
    Vector3 clampedVector;

    private void OnMouseDrag()
    {
        inputVector = Input.mousePosition;
        inputVector.z = mainCamera.WorldToScreenPoint(transform.position).z;
        unclampedVector = mainCamera.ScreenToWorldPoint(inputVector);
        //We will need to clamp our value to keep object inside the screen
        ClampValue();
        transform.position = clampedVector; 
    }

    void ClampValue()
    {
        clampedVector.x = Mathf.Clamp(unclampedVector.x, endPointTop.position.x + 0.5f, endPointBottom.position.x - 0.5f);
        clampedVector.y = Mathf.Clamp(unclampedVector.y, endPointBottom.position.y + 0.5f, endPointTop.position.y - 0.5f);
        clampedVector.z = unclampedVector.z;
    }
}
