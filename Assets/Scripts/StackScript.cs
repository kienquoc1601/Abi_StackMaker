using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScript : MonoBehaviour
{
    public GameObject upper;
    
    // Start is called before the first frame update
    void Start()
    {
        upper = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            upper.SetActive(false);
            
        }
    }
}
