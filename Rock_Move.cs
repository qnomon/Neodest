using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Transform transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move(){
        transform.position += new Vector3(5 * Time.deltaTime, 0,0);
    }


}
