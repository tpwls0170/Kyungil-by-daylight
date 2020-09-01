using System.Collections;
using System;
using UnityEngine;

public class EngineIteraction : MonoBehaviour, IObjectInteraction
{
    static private int generatorNum = 0;
    static public event Action generatorClear;

    private Color baseColor_matBody;
    private Color baseColor_matCap;
    [SerializeField]
    private Color signalColor1 = Color.magenta;
    [SerializeField]
    private Color signalColor2 = Color.yellow;

    [SerializeField]
    private GameObject BoxBody;
    [SerializeField]
    private GameObject BoxCap;

    private Material matBoby;
    private Material matCap;

    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject gaugeBar;
    private float maxGaugeBarWidth;
    private float gauge;
    [SerializeField]
    private float plusGaugePerSec = 5;
    private Vector3 gaugeScaleVec;



    void Start()
    {
        ++generatorNum;

        matBoby = BoxBody.GetComponent<MeshRenderer>().materials[0];
        matCap = BoxCap.GetComponent<MeshRenderer>().materials[0];

        baseColor_matBody = matBoby.color;
        baseColor_matCap = matCap.color;

        gauge = 0f;
        maxGaugeBarWidth = gaugeBar.transform.localScale.x;
        gaugeScaleVec = new Vector3(0, 1, 1);
        gaugeBar.transform.localScale = gaugeScaleVec;
    }

    public void Signal()
    {
        if (gauge >= 100f)
            return;

        matBoby.color = signalColor1;
        matCap.color = signalColor1;

        canvas.SetActive(true);
    }

    public void SignalChange()
    {
        if (gauge >= 100f)
            return;

        matBoby.color = signalColor2;
        matCap.color = signalColor2;
    }

    public void SignalChangeBack()
    {
        if (gauge >= 100f)
            return;

        matBoby.color = signalColor1;
        matCap.color = signalColor1;
    }

    public void SignalEnd()
    {
        matBoby.color = baseColor_matBody;
        matCap.color = baseColor_matCap;

        canvas.SetActive(false);
    }

    public void Interact()
    {
        if (gauge <= 0f)
        {
            matBoby.SetColor("_EmissionColor", new Color(0, 0, 1));
            matCap.SetColor("_EmissionColor", new Color(0, 0, 1));
        }

        else if (gauge >= 100f)
            return;

        gauge += Time.deltaTime * plusGaugePerSec;
        gaugeScaleVec = new Vector3(gauge * 0.01f, 1, 1);
        gaugeBar.transform.localScale = gaugeScaleVec;
        //Debug.Log(gauge);

        if (gauge >= 100f)
        {
            gauge = 100f;

            matBoby.SetColor("_EmissionColor", new Color(0, 1, 0));
            matCap.SetColor("_EmissionColor", new Color(0, 1, 0));

            SignalEnd();

            --generatorNum;
            if (generatorNum == 0)
                generatorClear();
        }
    }
}
