using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private int expAmount = 1;


    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponen<Player>();
            player.IncreaseExp(expAmount);
            Destroy(gameObject);
        }
    }

}
