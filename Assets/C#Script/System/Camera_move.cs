using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Vector3 distance;
    float cameraSpeed = 5f;

    void Update(){
        Vector3 dir = Player.position - this.transform.position;
        Vector3 move = new Vector3(distance.x, dir.y + distance.y, distance.z);
        transform.position = Vector3.MoveTowards(this.transform.position, move, cameraSpeed* Time.deltaTime);
    }
}
