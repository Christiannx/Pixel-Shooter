using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed;

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
    }
}
