using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickMovement:MonoBehaviour {

    public bool movable = true;
    GameObject[] bricks = new GameObject[4];
    Camera main;
    float movementOffset;
    int rotation, height, width;

    IEnumerator Start() {
        main = Camera.main;
        for(int i = 0; i < 4; i++) {
            bricks[i] = transform.GetChild(i).gameObject;
            bricks[i].GetComponent<Bricks>().enabled = false;
        }

        while(movable) {
            yield return new WaitForSeconds(1f);
            if(!movable)
                break;

            transform.position -= main.transform.up;
            foreach(GameObject brick in bricks) {
                if(brick.transform.position.y <= 0) {
                    RockBottom();
                }
            }

        }
    }

    void Update() {
        //if(Input.GetKeyDown(KeyCode.DownArrow))
        //    transform.position -= main.transform.up;

        if(Input.GetKeyDown(KeyCode.UpArrow))
            RotateBrick();

        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            transform.position -= main.transform.right;
            CheckWalls();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            transform.position += main.transform.right;
            CheckWalls();
        }

        CheckWalls();
    }

    void CheckWalls() {
        foreach(GameObject brick in bricks) {
            if(brick.transform.position.x <= 0)
                transform.position += main.transform.right;
        }
    }

    void RotateBrick() {
        rotation += 90;
        if(rotation == 180)
            rotation = -rotation;

        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
    void RockBottom() {
        movable = false;
        for(int i = 0; i < 4; i++) {
            bricks[i].transform.parent = GameObject.Find("PlayerMap").transform;
            bricks[i].GetComponent<Bricks>().enabled = true;
        }
        Destroy(gameObject);
    }
}
