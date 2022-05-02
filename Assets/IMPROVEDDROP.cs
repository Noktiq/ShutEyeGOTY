using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMPROVEDDROP : MonoBehaviour
{
    public Rigidbody rb;
    public IMPROVEDCUT script;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(script.playerCut == true)
        rb.isKinematic = false;
    }
}
