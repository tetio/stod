using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour {
    [SerializeField]
    private float speed = 1;
    private float lastMovement = 0;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start () {
        rb = this.GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {
        float hAxis = Input.GetAxis ("Horizontal");
        float vAxis = Input.GetAxis ("Vertical");
        float dirX = (hAxis != 0) ? Mathf.Sign (hAxis) * 1 : 0;
        float dirZ = (vAxis != 0) ? Mathf.Sign (vAxis) * 1 : 0;
        Vector3 dir = Vector3.zero;
        if (dirX > 0) {
            dir = Vector3.right;
        } else if (dirX < 0) {
            dir = Vector3.left;
        } else if (dirZ > 0) {
            dir = Vector3.forward;
        } else if (dirZ < 0) {
            dir = Vector3.back;
        }
        if (dirX != 0) {
            dirZ = 0;
        }
        if (Time.time > lastMovement + .2 && canMove (dir)) {
            lastMovement = Time.time;
            transform.Translate (new Vector3 (dirX, 0, dirZ) * speed);
        }
    }

    private bool canMove (Vector3 dir) {
        if (dir == Vector3.zero) {
            return false;
        }
        RaycastHit hit;
        Ray ray = new Ray (transform.position, dir);
        if (Physics.Raycast (ray, out hit, 0.6f)) {
            Debug.Log("Something on the way!!!!");
            if (hit.collider.gameObject.name.StartsWith("Brick")) {
                return false;
            }
        }
        return true;
    }

    // void OnCollisionEnter(Collision collision) {
    //     if (collision.gameObject.name == "Brick") {
    //         rb.velocity = Vector3.zero;
    //     }
    // }

    // void FixedUpdate() {
    //     float x = Input.GetAxis("Horizontal");
    //     float z = Input.GetAxis("Vertical");
    //     rb.position += transform.right * x * speed * Time.deltaTime;
    //     rb.position += transform.forward * z * speed * Time.deltaTime;
    // }
}