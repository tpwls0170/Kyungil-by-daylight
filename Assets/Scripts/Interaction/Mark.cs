using UnityEngine;

public class Mark : MonoBehaviour
{
    //private Camera cam;
    [SerializeField]
    private GameObject mark;


    void Start()
    {
        //cam = Camera.main;
    }

    //void Update()
    //{
    //Ray ray = cam.ScreenPointToRay(mark.transform.position + Vector3.up);
    //RaycastHit hit;

    //if (Physics.Raycast(ray, out hit, 999f))
    //{
    //    if ((hit.point - mark.transform.position).magnitude <= 10f)
    //    {
    //        if (mark.activeSelf == false)
    //            return;
    //        mark.SetActive(false);
    //    }
    //    else
    //    {
    //        if (mark.activeSelf == true)
    //            return;
    //        mark.SetActive(true);
    //    }
    //}
    //}

    private void OnTriggerEnter(Collider other)
    {
        mark.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        mark.SetActive(true);
    }
}
