using UnityEngine;

public class Enemy : MonoBehaviour {
    #pragma warning disable 0649
    [SerializeField] private Transform exitPoint1;
    [SerializeField] private Transform exitPoint2;
    [SerializeField] private Transform[] waypoints1;
    [SerializeField] private Transform[] waypoints2;
    #pragma warning restore 0649
    private int target1 = 0;
    private int target2 = 0;
    private Transform enemy;
    private bool spawnOnLine1;
    private float navigationTime = 0;

    void Start() {
        enemy = GetComponent<Transform> ();
        spawnOnLine1 = !GameManager.Instance.IsSpawnLine1();
    }

    void Update() {
        navigationTime += Time.deltaTime;
        if (spawnOnLine1) {
            if (target1 < waypoints1.Length) {
                enemy.position = Vector2.MoveTowards(enemy.position, waypoints1[target1].position, navigationTime);
            } else {
                enemy.position = Vector2.MoveTowards(enemy.position, exitPoint1.position, navigationTime);
            }
        } else {
            if (target2 < waypoints2.Length) {
                enemy.position = Vector2.MoveTowards(enemy.position, waypoints2[target2].position, navigationTime);
            } else {
                enemy.position = Vector2.MoveTowards(enemy.position, exitPoint2.position, navigationTime);
            }
        }
        navigationTime = 0;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Checkpoint") {
            target1 += 1;
        } else if (other.tag == "Checkpoint2") {
            target2 += 1;
        } else if (other.tag == "Finish") {
            Destroy(gameObject);
        }
    }
}
