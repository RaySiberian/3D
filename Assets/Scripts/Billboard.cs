using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera mainCamera;
    private Transform cachedTransform;

    private void Start()
    {
        mainCamera = Camera.main;
        cachedTransform = transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(mainCamera.transform);
        cachedTransform.rotation = Quaternion.Euler(0f,cachedTransform.rotation.eulerAngles.y,0f);
    }
}
