using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static BusinessInventory BusinessInventory { get; private set; }

    public float BaseSaleCooldownInSeconds = 5f;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
        
        BusinessInventory = new BusinessInventory();
    }

    public float GetSellingCooldown()
    {
        return BaseSaleCooldownInSeconds - (BaseSaleCooldownInSeconds * GetBusinessQualityRating());
    }

    public float GetBusinessQualityRating(bool toPercent = false)
    {
        // TODO: Implement once item quality system is in place
        float quality = 0.1f;
        
        if (toPercent)
            return quality * 100f;
        else
            return quality; 
    }
}
