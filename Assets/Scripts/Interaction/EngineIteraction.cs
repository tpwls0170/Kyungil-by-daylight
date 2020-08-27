using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineIteraction : MonoBehaviour, IObjectInteraction
{
    [SerializeField]
    private GameObject BoxBody;
    [SerializeField]
    private GameObject BoxCap;

    Material matBoby;
    Material matCap;

    void Start()
    {
        matBoby = BoxBody.GetComponent<MeshRenderer>().materials[0];
        matCap = BoxCap.GetComponent<MeshRenderer>().materials[0];
    }

    void Update()
    {
        
    }

    public void Signal()
    {

    }

    public void SignalChange()
    {

    }

    public void SignalChangeBack()
    {

    }

    public void SignalEnd()
    {

    }

    public void Interact()
    {
        matBoby.SetColor("_EmissionColor", new Color(0, 1, 0));
        matCap.SetColor("_EmissionColor", new Color(0, 1, 0));
    }
}
