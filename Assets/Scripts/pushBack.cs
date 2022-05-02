using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushBack : MonoBehaviour
{

    public float knockForce;

    public float force = 1;
    Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
    if(other.gameObject.tag == "Enemy")
    {
        Vector3 pushDirection = other.transform.position = transform.position;
        pushDirection = pushDirection.normalized;
        GetComponent<Rigidbody>().AddForce(pushDirection * force * 100); 
        // velocity.x = Mathf.Sqrt(knockForce * -2);
        Debug.Log("enemypushback");
    }
    }

}
