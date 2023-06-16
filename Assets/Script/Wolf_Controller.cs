using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Controller : MonoBehaviour
{
    public GameObject boom;
    public float minBoomTime = 2;
    public float maxBoomTime = 4;
    private float boomTime = 0;
    private float lastBoomTime = 0;
    public float throughBoomTime = 0.5f;
    private GameObject Sheep;
    private Animator anim;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        UpdateBoomTime();
        Sheep = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isBoom", false);
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time >= lastBoomTime + boomTime - throughBoomTime)
        {
            anim.SetBool("isBoom", true);

        }

        //neu thoi gian(time) >= thoi gian truoc do da duoc nem boom(lastBoomTime) + thoi gian gian cach giua moi lan nem boom(boomTime)
        if (Time.time >= lastBoomTime + boomTime)
        {
            ThroughBoom();

        }
    }

    void UpdateBoomTime()
    {
        lastBoomTime = Time.time;
        boomTime = Random.Range(minBoomTime, maxBoomTime + 1);
    }

    //Nem boom
    void ThroughBoom()
    {
        GameObject bom = Instantiate(boom, transform.position, Quaternion.identity) as GameObject;

        bom.GetComponent<Boom_Controller>().target = Sheep.transform.position;
        UpdateBoomTime();
        anim.SetBool("isBoom", false);
        gameController.GetComponent<GameController>().GetPoint();
    }
}
