using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link {

    public enum direction {

        BI,
        UNI
    }

    public GameObject node1, node2;
    public direction dir;
    public Link(GameObject _node1, GameObject _node2, direction _dir){
        node1 = _node1;
        node2 = _node2;
        dir = _dir;
    }
}

public class WPManager : MonoBehaviour {

    public List<GameObject> waypoints;
    public List<Link> links;
    public Graph graph = new Graph();

    public void CreateGraph() {
        if (waypoints.Count > 0) {

            foreach (GameObject wp in waypoints) {

                graph.AddNode(wp);

                foreach (Link l in links) {

                    graph.AddEdge(l.node1, l.node2);
                    if (l.dir == Link.direction.BI) {

                        graph.AddEdge(l.node2, l.node1);
                    }
                }
            }
        }
    }
    public void AddLink(GameObject node1, GameObject node2){
        links.Add(new Link(node1, node2, Link.direction.BI));
    }
    public List<GameObject> GetWaypoints => waypoints;
    public void AddWaypoint(GameObject node){
        waypoints.Add(node);
    }
}
