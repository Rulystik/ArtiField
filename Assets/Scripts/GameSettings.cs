using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private int widthFieldSimple;
    [SerializeField] private int heigtFieldSimple;
    
    [SerializeField] private int widthFieldAdvanced;
    [SerializeField] private int heigtFieldAdvanced;
    
    public int WidthField { get; private set; }
    public int HeightField { get; private set; }
    
    public static GameSettings Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SetFieldSize(GameType.Advanced);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetFieldSize(GameType type)
    {
        switch (type)
        {
            case GameType.Simple:
                WidthField = widthFieldSimple;
                HeightField = heigtFieldSimple;
                break;
            case GameType.Advanced:
                WidthField = widthFieldAdvanced;
                HeightField = heigtFieldAdvanced;
                break;
                
        }
    }
    
}
