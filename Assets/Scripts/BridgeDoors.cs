using UnityEngine;

public class BridgeDoors : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bridgeDoors;
    
    void Start()
    {
        EngineIteraction.generatorClear += RandomDoorInactive;
    }

    private void RandomDoorInactive()
    {
        int randNum = Random.Range(0, 4);
        bridgeDoors[randNum].SetActive(false);
        Debug.Log("OK");
    }
}
