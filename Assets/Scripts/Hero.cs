using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private float speed = 1;
    private float lastMovement = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis= Input.GetAxis("Vertical");
        float dirX = (hAxis != 0)? Mathf.Sign(hAxis)*1:0;
        float dirZ= (vAxis != 0)? Mathf.Sign(vAxis)*1:0;
        if (Time.time > lastMovement + .5) {
            lastMovement = Time.time;
            transform.Translate(new Vector3(dirX, 0, dirZ) * speed);
        }
    }
}
