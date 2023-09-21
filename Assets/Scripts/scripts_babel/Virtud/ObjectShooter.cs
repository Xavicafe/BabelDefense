using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectShooter : MonoBehaviour {
    public string poolTag;
    public float creationRate = .5f;
    public KeyCode keyToPress = KeyCode.Space;
    private float timeOfLastSpawn;
    void Start() {
        timeOfLastSpawn = -creationRate;
    }
    void Update() {
        if (Input.GetKey(keyToPress) &&
            Time.time >= timeOfLastSpawn + creationRate) {
            ObjectPooler.Instance.SpawnFromPool(poolTag, transform.position, Quaternion.identity);
            timeOfLastSpawn = Time.time;
        }
    }
}

