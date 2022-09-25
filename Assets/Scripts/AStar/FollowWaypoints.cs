using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoints : MonoBehaviour {

    Transform goal;
    float speed = 5.0f;
    float accuracy = 1.0f;
    float rotSpeed = 5.0f;
    List<GameObject> wps;
    GameObject currentNode;
    int currentWP = 0;
    Graph g;

    private GameObject wpManager;

    void Start() {
        // Time.timeScale = 5.0f;
        wpManager = GameObject.Find("WaypointManager");
        wps = wpManager.GetComponent<WPManager>().waypoints;
        g = wpManager.GetComponent<WPManager>().graph;
        currentNode = wps[0];

        Invoke("GotoObjective", 2.0f);
    }

    // public void GotoHeli() {

    //     g.AStar(currentNode, wps[0]);
    //     currentWP = 0;
    // }

    // public void GotoRuin() {

    //     g.AStar(currentNode, wps[wps.Count]);
    //     currentWP = 0;
    // }

    // public void GotoRock() {

    //     g.AStar(currentNode, wps[1]);
    //     currentWP = 0;
    // }

    // public void GotoFactory() {

    //     g.AStar(currentNode, wps[4]);
    //     currentWP = 0;
    // }
    public void GotoObjective() {
        g.AStar(currentNode, wps[wps.Count-1]);
        currentWP = 0;
    }

    void LateUpdate() {

        if (g.pathList.Count == 0 || currentWP == g.pathList.Count) return;

        currentNode = g.getPathPoint(currentWP);

        if (Vector3.Distance(g.pathList[currentWP].getID().transform.position, transform.position) < accuracy) {

            currentWP++;
        }

        if (currentWP < g.pathList.Count) {

            goal = g.pathList[currentWP].getID().transform;
            Vector3 lookAtGoal = new Vector3(
                goal.position.x,
                transform.position.y,
                goal.position.z);

            Vector3 direction = lookAtGoal - this.transform.position;

            transform.rotation = Quaternion.Slerp(
                this.transform.rotation,
                Quaternion.LookRotation(direction),
                Time.deltaTime * rotSpeed);
            // transform.rotation = Quaternion.LookRotation(direction);

            transform.Translate(0.0f, 0.0f, speed * Time.deltaTime);
        }
    }
}
