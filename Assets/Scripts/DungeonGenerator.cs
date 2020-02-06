using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour {
    List<Vector3> wall = new List<Vector3> ();
    [SerializeField]
    private GameObject brick;
    void Awake () {
        wall.Add (new Vector3 (9.5f, 0.5f, 5.5f));
        wall.Add (new Vector3 (11.5f, 0.5f, 5.5f));
        wall.Add (new Vector3 (9.5f, 0.5f, 6.5f));
        wall.Add (new Vector3 (11.5f, 0.5f, 6.5f));

        foreach (Vector3 position in wall) {
            Instantiate(brick, position, Quaternion.identity);
        }
    }

}