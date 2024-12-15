using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed = 20f;
    [SerializeField]
    private float moveStopThreshold = 15f;

    void Start()
    {
        
    }
    
     void Move()
    {
        /* 
        Input.GetAxis = 가속과 감속을 이용한 부드러운 입력변화
        Input.GetAxisRaw = 디지털 신호처럼 입력이 바로변화함
        Input.GetKeyDown을 이용한 움직임 = 위와 동일하게 감가속이 없음
        */
        
        Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        bool canMoveLeft =  transform.position.x > -Math.Abs(moveStopThreshold);
        bool canMoveRight = transform.position.x < Math.Abs(moveStopThreshold);
        
        if (Input.GetKey(KeyCode.LeftArrow)&& canMoveLeft)
        {
            transform.position -= moveTo;

        }
        else if (Input.GetKey(KeyCode.RightArrow) && canMoveRight)
        {
            transform.position += moveTo;
        }
    }
    

    void Update()
    {
            Move();
    }
}
