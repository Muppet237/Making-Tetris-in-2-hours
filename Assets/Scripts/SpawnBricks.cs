using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBricks:MonoBehaviour {

    GameObject spawnPoint, holdBrickInPlay;
    public GameObject[] prefabs;

    int randomBrick;

    IEnumerator Start() {
        spawnPoint = GameObject.Find("SpawnPoint");
        randomBrick = Random.Range(0, prefabs.Length);
        holdBrickInPlay = Instantiate(prefabs[randomBrick], spawnPoint.transform.position, Quaternion.identity);

        while(true) {
            yield return new WaitForSeconds(0.25f);
            randomBrick = Random.Range(0, prefabs.Length);

            if(holdBrickInPlay == null) {
                holdBrickInPlay = Instantiate(prefabs[randomBrick], spawnPoint.transform.position, Quaternion.identity);

            }
        }
    }
}
