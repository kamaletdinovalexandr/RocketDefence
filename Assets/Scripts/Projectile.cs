using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Vector3 Direction;
    public float Speed;
    public float lifeTime;
    private  float timer = 0;

    private void Update() {
        timer += Time.deltaTime;
        if (timer > lifeTime) {
            Destroy(gameObject);
            return;
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + Direction, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision) {
        var enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
            Destroy(enemy.gameObject);
    }
}
