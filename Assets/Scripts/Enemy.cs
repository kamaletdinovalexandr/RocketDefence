using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform Target;
    public float Speed;

    private void Update() {
        var newPosition = new Vector3(Target.position.x, transform.position.y, Target.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, Speed * Time.deltaTime);
    }
}
