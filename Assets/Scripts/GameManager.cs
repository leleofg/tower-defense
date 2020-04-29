using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    #pragma warning disable 0649
    [SerializeField] private GameObject spawnPoint1;
    [SerializeField] private GameObject spawnPoint2;
    [SerializeField] private GameObject[] enemies;
    #pragma warning restore 0649
    private bool spawnOnLine1 = true;

    protected override void Awake () {
        base.Awake();
    }

    void Update() {
        if (Input.GetKeyDown("down")) {
            if (spawnOnLine1) {
                GameObject newEnemy1 = Instantiate(enemies[0]) as GameObject;
                newEnemy1.transform.position = spawnPoint1.transform.position;
            } else {
                GameObject newEnemy2 = Instantiate(enemies[0]) as GameObject;
                newEnemy2.transform.position = spawnPoint2.transform.position;
            }
            spawnOnLine1 = !spawnOnLine1;
        }
    }

    public bool IsSpawnLine1 () {
        return spawnOnLine1;
    }
}