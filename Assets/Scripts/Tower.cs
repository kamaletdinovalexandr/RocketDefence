using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject Projectile;
    public GameObject SpawnPoint;
    public float RotationSpeed;
    public float CoolDownTime;
    private Transform _target;
    private float _coolDownTimer = 0f;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.GetComponent<Enemy>() != null) {
            _target = other.transform;
        }
    }

    private void Update() {
        _coolDownTimer += Time.deltaTime;

        if (_target !=null) {
            RotateToTarget();

            if (IsInFront() && _coolDownTimer >= CoolDownTime) {
                _coolDownTimer = 0f;
                Shoot();
            } 
        }
    }

    private bool IsInFront() {
        Vector3 targetDir = _target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
        return angle < 0.2f;
    }

    private void RotateToTarget() {
        var targetDir = _target.position - transform.position;
        var step = RotationSpeed * Time.deltaTime;
        var newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);
        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void Shoot() {
        if (_target == null)
            return;

        var projectile = Instantiate(Projectile, SpawnPoint.transform.position, Quaternion.identity).GetComponent<Projectile>();
        projectile.Direction = Vector3.Normalize(_target.position - transform.position);
        var targetDir = _target.position - transform.position;
        var angle = Vector3.RotateTowards(transform.forward, targetDir, 0.0f, 0.0f);
        projectile.transform.rotation = Quaternion.LookRotation(angle);
    }
}
