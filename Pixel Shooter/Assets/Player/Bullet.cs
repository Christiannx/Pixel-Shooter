using UnityEngine;

public class Bullet : MonoBehaviour {
    [HideInInspector] public int damage;
    void OnCollisionEnter(Collision c) {
        if (c.transform.GetComponent<Enemy>()) {
            c.transform.GetComponent<Enemy>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
