using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Vector3 offset;
    Transform target;
    
    void Start() => target = GameObject.FindGameObjectWithTag("Player").transform;

    void Update() {
        transform.position = target.position + offset;
        transform.LookAt(target);
    }
}
