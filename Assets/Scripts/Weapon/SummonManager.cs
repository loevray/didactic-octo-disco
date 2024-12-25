using UnityEngine;

public class SummonManager : MonoBehaviour
{

    public GameObject summonPrefab1;
    public GameObject summonPrefab2;
    public Transform player;

    public SummonType summonType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnEnable()
    {
        SummonPet();
    }

    void SummonPet()
    {
        Vector3 summonPosition = player.position + new Vector3(2, 0, 1);
        GameObject summonPrefab = null;

        switch (summonType)
        {
            case SummonType.summon1:
                summonPrefab = summonPrefab1;
                break;
            case SummonType.summon2:
                summonPrefab = summonPrefab2;
                break;
        }
        Instantiate(summonPrefab, summonPosition, Quaternion.identity);
    }

    public enum SummonType
    {
        summon1,
        summon2
    }
}
