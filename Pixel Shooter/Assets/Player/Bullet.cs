using UnityEngine;

public class Bullet : MonoBehaviour {
    void OnCollisionEnter(Collision c) {
        Destroy(gameObject);
    }
}
