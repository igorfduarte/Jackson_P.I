using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour {
    Transform target;
    public float speed = 0.5f;
    public float originalSpeed;
    Animator anim;
    Color originalColor;
    public bool isSlow;
    float dis;
    GameObject player;


    Vector2 direction;
    // Use this for initialization
    public void SlowEffect(float slowSpeed)
    {
        isSlow = true;
        speed = slowSpeed;
        Invoke("StopSlow", 3f);


    }

    void StopSlow()
    {
        speed = originalSpeed;
        isSlow = false;
    }
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        originalColor = this.gameObject.GetComponent<SpriteRenderer>().color;
    

        originalSpeed = speed;
    }
	
	// Update is called once per frame
	void Update () {

        if (this.gameObject.GetComponent<SpriteRenderer>().color == Color.blue)
        {
            Invoke("ColorChangeBack", 3f);
        }
        if (this.gameObject.GetComponent<SpriteRenderer>().color == Color.red)
        {
            Invoke("ColorChangeBack", 5);
        }



        target = player.GetComponent<Transform>();
        direction = target.transform.position - transform.position;
        dis = Vector3.Distance(target.transform.position, transform.position);
        direction.Normalize();
        if (dis <= 95)
        {
            Move();
            AnimateMoviment(direction);
        }
        if (target.position.x < transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        

       // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       // anim.SetFloat("Vertical", rigid.velocity.y);
       // anim.SetFloat("Horizontal", rigid.velocity.x);
	}
    void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void AnimateMoviment(Vector2 direction)
    {
        
        anim.SetFloat("Horizontal", direction.x);
        anim.SetFloat("Vertical", direction.y);
    }



    public void ColorChangeBack()
    {
        print("era pra ter trocado de cor");


        this.gameObject.GetComponent<SpriteRenderer>().color = originalColor;


    }
    public void ColorChangeToBlue()
    {
        print("trocou de cor?");
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;


    }
    public void ColorChangeToRed()
    {
        print("trocou de cor?");
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;


    }

}
