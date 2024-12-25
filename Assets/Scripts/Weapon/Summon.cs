using UnityEngine;

public class Summon : MonoBehaviour
{
    [SerializeField] private Transform player; //�÷��̾��� ��ġ ����
    [SerializeField] private float followSpeed;
    [SerializeField] private float followDistance = 2f;
    //[SerializeField] �÷��̾�� ���� �Ÿ�

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
