using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTypeMenu : MenuBase
{
    [SerializeField] private Button simpleGameButton;
    [SerializeField] private Button adnvancedGameButton;
    [SerializeField] private Button backButton;


    public Action<GameType> simpleOrAvancedGameAction;

    public override void Init()
    {
        InitListButtons();

        simpleGameButton.onClick.AddListener(SimpleGame);
        adnvancedGameButton.onClick.AddListener(AdvancedGame);
        backButton.onClick.AddListener(BackButtonDown);
        
        gameObject.SetActive(false);
    }
    private void SimpleGame()
    {
        simpleOrAvancedGameAction?.Invoke(GameType.Simple);
    }
    private void AdvancedGame()
    {
        simpleOrAvancedGameAction?.Invoke(GameType.Advanced);
    }
}
