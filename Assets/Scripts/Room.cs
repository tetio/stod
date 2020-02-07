using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Linq.Enumerable;
using System.Linq;

public class Room 
{
    public Vector2 center {set; get; }
    public int width {set; get; }
    public int height {set; get; }


    List<Door> doors;

    public List<Vector3> generate() {
        List<Vector3> walls = new List<Vector3>();
        foreach(int x in Range(0, width)) {
            walls.Add(new Vector3(x, 0.5f, center.y+height/2));
            walls.Add(new Vector3(x, 0.5f, center.y-height/2));
        }
        foreach(int y in Range(1, height-1)) {
            walls.Add(new Vector3(center.x-(width/2), 0.5f, y));
            walls.Add(new Vector3(center.x+(width/2), 0.5f, y));
        }
        return walls.Where(b => notIn(b)).ToList();
    }

    private bool notIn(Vector2 b) {
       return  doors.Where(door => door.center.x == b.x && door.center.y == b.y).Count() == 0;

    }

}
