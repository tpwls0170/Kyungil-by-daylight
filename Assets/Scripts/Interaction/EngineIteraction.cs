using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineIteraction : MonoBehaviour, IObjectInteraction
{
    private Color baseColor;
    [SerializeField]
    private Color signalColor1;
    [SerializeField]
    private Color signalColor2;

    [SerializeField]
    private GameObject BoxBody;
    [SerializeField]
    private GameObject BoxCap;

    private Material matBoby;
    private Material matCap;

    void Start()
    {
        matBoby = BoxBody.GetComponent<MeshRenderer>().materials[0];
        matCap = BoxCap.GetComponent<MeshRenderer>().materials[0];

        baseColor = Color.white;
    }

    void Update()
    {

    }

    public void Signal()
    {
        matBoby.color = signalColor1;
        matCap.color = signalColor1;
    }

    public void SignalChange()
    {
        matBoby.color = signalColor2;
        matCap.color = signalColor2;
    }

    public void SignalChangeBack()
    {
        matBoby.color = signalColor1;
        matCap.color = signalColor1;
    }

    public void SignalEnd()
    {
        matBoby.color = baseColor;
        matCap.color = baseColor;
    }

    public void Interact()
    {
        matBoby.SetColor("_EmissionColor", new Color(0, 1, 0));
        matCap.SetColor("_EmissionColor", new Color(0, 1, 0));
    }
}
