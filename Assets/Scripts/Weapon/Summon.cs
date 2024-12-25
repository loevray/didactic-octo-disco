using UnityEngine;

public class Summon : MonoBehaviour
{
    [SerializeField] private Transform player; //플레이어의 위치 참조
    [SerializeField] private float followSpeed;
    [SerializeField] private float followDistance = 2f;
    //[SerializeField] 플레이어와 붙을 거리

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void Move()
    {

    }

    void FollowPlayer()
    {
        float distance = DistanceWithPlayer();
        if (distance > followDistance)
        {
            //Move;
        }
    }
    
    float DistanceWithPlayer()
    {
        return Mathf.Abs(transform.position.z - player.position.z);
    }

}
