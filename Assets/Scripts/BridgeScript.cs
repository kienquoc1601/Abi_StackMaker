using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    public GameObject bridge;
    public bool built = false;
    // Start is called before the first frame update
    void Start()
    {
        bridge = this.gameObject;
        bridge.GetComponent<MeshRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && built == false)
        {
            //bridge.SetActive(false);
            SendMessage("BuildBridge");
        }
    }

    void BuildBridge()
    {
        bridge.GetComponent<MeshRenderer>().enabled = true;
        bridge.gameObject.tag = "built";
        built = true;
        Debug.Log("aaa");
    }
}
