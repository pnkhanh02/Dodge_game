using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom_Controller : MonoBehaviour
{
    public Vector3 target;
    public float moveSpeed = 5;
    public float destroyTime = 2;
    public GameObject explor; 
    // Start is called before the first frame update
    void Start()
    {
        //ham huy doi tuong
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        //cap nhat vi tri doi tuong de huong boom toi muc tieu
        transform.Translate((transform.position - target) * moveSpeed * Time.deltaTime * -1);
    }

    //huy doi tuong boom
    void OnDestroy()
    {
        GameObject exp = Instantiate(explor, transform.position, Quaternion.identity) as GameObject;
        Destroy(exp, 0.5f);
    }

    
}
