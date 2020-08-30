using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletInteraction : MonoBehaviour, IObjectInteraction
{
    private Color baseColor_matPallet;
    private Color baseColor_matLeg;
    [SerializeField]
    private Color signalColor1 = Color.magenta;
    [SerializeField]
    private Color signalColor2 = Color.yellow;

    [SerializeField]
    private GameObject Pallet;

    private Material matPallet;
    private Material matLeg;

    private int hp;
    [SerializeField]
    private int maxHp = 2;

    void Start()
    {
        matPallet = Pallet.GetComponent<MeshRenderer>().materials[0];
        matLeg = Pallet.GetComponent<MeshRenderer>().materials[1];

        baseColor_matPallet = matPallet.color;
        baseColor_matLeg = matLeg.color;
        hp = maxHp;
    }

    public void Signal()
    {
        matPallet.color = signalColor1;
        matLeg.color = signalColor1;
    }

    public void SignalChange()
    {
        matPallet.color = signalColor2;
        matLeg.color = signalColor2;
    }

    public void SignalChangeBack()
    {
        matPallet.color = signalColor1;
        matLeg.color = signalColor1;
    }

    public void SignalEnd()
    {
        matPallet.color = baseColor_matPallet;
        matLeg.color = baseColor_matLeg;
    }

    public void Interact()
    {
        //if (gauge == 0f)
        //{
        //    matPallet.SetColor("_EmissionColor", new Color(0, 0, 1));
        //    matCap.SetColor("_EmissionColor", new Color(0, 0, 1));
        //}

        //gauge += Time.deltaTime;
        ////Debug.Log(gauge);

        //if (gauge >= requiredTime)
        //{
        //    gauge = requiredTime;

        //    matBoby.SetColor("_EmissionColor", new Color(0, 1, 0));
        //    matCap.SetColor("_EmissionColor", new Color(0, 1, 0));
        //}
    }
}
