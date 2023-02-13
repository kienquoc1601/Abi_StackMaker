using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public GameObject parent;
    public GameObject upper;
    public GameObject bbase ;


    
    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject;
        upper = parent.transform.GetChild(0).gameObject;
        bbase = parent.transform.GetChild(1).gameObject;
        upper.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        upper.SetActive(false);
    //    }
    //}

}
