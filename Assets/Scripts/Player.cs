using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField]
    private float moveSpeed = 20f;
    
    private int lastDirection = 0;
    void Start()
    {
        
    }
    
    void GetLastKeyDirection(){
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            lastDirection = 1;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lastDirection = -1;
        }
    }

     void Move(int direction)
    {
        /* 
        Input.GetAxis = 가속과 감속을 이용한 부드러운 입력변화
        Input.GetAxisRaw = 디지털 신호처럼 입력이 바로변화함
        Input.GetKeyDown을 이용한 움직임 = 위와 동일하게 감가속이 없음
        */
        Vector3 moveDirection = new Vector3(direction, 0, 0);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
    void Update()
    {
         if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            GetLastKeyDirection();
            Move(lastDirection);
        }
    }
}
