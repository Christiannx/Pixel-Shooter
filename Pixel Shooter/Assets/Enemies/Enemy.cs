using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public float moveSpeed;
    [Header("Attack")]
    public int attackDamage;
    public float attackRange;
    public float attackSpeed;

    Player player;
    bool attacking = false;

    void Start() {
        player = FindObjectOfType<Player>();
    }

    void Update() {
        if (!attacking)
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);


        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (!attacking && distance < attackRange) {
            attacking = true;
            InvokeRepeating(nameof(Attack), 0, attackSpeed);
        } else if (attacking && distance > attackRange) {
            attacking = false;
            CancelInvoke(nameof(Attack));
        }
    }

    public void TakeDamage(int amount) {
        if (amount < health) {
            health -= amount;
        } else {
            Die();
        }
    }

    public virtual void Attack() {
        player.health -= attackDamage;
    }

    public virtual void Die() {
        Destroy(gameObject);
    }
}
