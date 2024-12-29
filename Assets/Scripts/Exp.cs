using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] public static int expAmount = 10;
    [SerializeField] private float expMoveSpeed = 8f;
    [SerializeField] private int expIncrement = 1;
    private void OnEnable()
    {
        MapTile.OnMapDeleted += IncreaseExpAmount;
    }

    private void OnDisable()
    {
        MapTile.OnMapDeleted -= IncreaseExpAmount;
    }

    private void Update()
    {
        MoveExp();
    }

    void MoveExp()
    {
        transform.position += Vector3.back * expMoveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player player = other.gameObject.GetComponent<Player>();
            player.IncreaseExp(expAmount);
            AudioManager.instance.PlaySfx(AudioManager.Sfx.GetExpOrb);
            Destroy(gameObject);
        }
    }

    private void IncreaseExpAmount()
    {
        expAmount += expIncrement;
    }
}
