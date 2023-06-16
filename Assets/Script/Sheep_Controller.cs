using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep_Controller : MonoBehaviour
{
    Vector3 mousePos;
    public float moveSpeed = 25;
    public float minX = -5.8f;
    public float maxX = 5.8f;
    public float minY = -3.5f;
    public float maxY = 3.5f;
    private GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        //khoi tao vi tri bat dau cua sheep
        mousePos = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {
        //neu nhan chuot trai
        if (Input.GetMouseButton(0))
        {
            //vi tri chuot chuyen doi tu toa do man hinh sang toa do the gioi
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos = new Vector3(Mathf.Clamp(mousePos.x, minX, maxX), Mathf.Clamp(mousePos.y, minY, maxY), 0);
        }
        //cap nhat vi tri cua sheep 
        transform.position = Vector3.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }

    //khi va cham
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        gameController.GetComponent<GameController>().EndGame();
    }
}
