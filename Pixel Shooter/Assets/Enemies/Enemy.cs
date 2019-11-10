using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public float moveSpeed;

    Player player;

    void Start() {
        player = FindObjectOfType<Player>();
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
    }

    public void TakeDamage(int amount) {
        if (amount < health) {
            health -= amount;
        } else {
            Die();
        }
    }

    public virtual void Die() {
        Destroy(gameObject);
    }
}
