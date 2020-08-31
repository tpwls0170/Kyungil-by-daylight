using UnityEngine;

public class UIRotate : MonoBehaviour
{
    Transform CamTransform;

    void Start()
    {
        CamTransform = Camera.main.transform;
    }

    void Update()
    {
        transform.LookAt(transform.position + CamTransform.rotation * Vector3.forward, CamTransform.rotation * Vector3.up);
    }
}
