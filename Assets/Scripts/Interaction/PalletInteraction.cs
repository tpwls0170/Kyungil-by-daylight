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
    private GameObject palletBody;

    private Material matPallet;
    private Material matLeg;

    private Rigidbody palletRigidbody;

    [SerializeField]
    private Vector3 pushForce;
    private int interNum = 0;

    private int hp;
    [SerializeField]
    private int maxHp = 2;

    void Start()
    {
        matPallet = palletBody.GetComponent<MeshRenderer>().materials[0];
        matLeg = palletBody.GetComponent<MeshRenderer>().materials[1];
        palletRigidbody = GetComponentInParent<Rigidbody>();

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
        switch(interNum)
        {
            case 0:
                ++interNum;
                palletRigidbody.AddForce(pushForce);
                break;
        }
    }
}
