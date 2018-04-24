using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeFollowPlayer : MonoBehaviour {
    Transform target;
    Vector2 direction;
    GameObject player;
    [SerializeField] float speed;
    float dis;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        target = player.GetComponent<Transform>();
        direction = target.transform.position - transform.position;
        dis = Vector3.Distance(target.transform.position, transform.position);
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
