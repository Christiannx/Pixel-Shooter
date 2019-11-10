using UnityEngine;

public class Player : MonoBehaviour {
    public int health = 20;
    public int damage = 1;
    public float moveSpeed;
    [Header("Shooting")]
    public Bullet bullet;
    public Transform shootPoint;
    public float bulletForce;


    new Rigidbody rigidbody;
    Vector3 movement;

    void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.deltaTime);

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            var lookAt = new Vector3() {
                x = hit.point.x,
                y = transform.position.y,
                z = hit.point.z
            };
            transform.LookAt(lookAt);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            var bulletInstance = Instantiate(bullet, shootPoint.position, Quaternion.identity);
            bulletInstance.damage = damage;
            var bulletRB = bulletInstance.GetComponent<Rigidbody>();
            bulletRB.AddForce(shootPoint.forward * bulletForce, ForceMode.Impulse);
            Destroy(bulletInstance.gameObject, 5);
        }
    }
}
