
using UnityEngine;

public class GameBootStrapper : MonoBehaviour
{
    [SerializeField] private View view;
    [SerializeField] private BattleFieldView battleFieldView;
    private Controller controller;

    void Start()
    {
        controller = new Controller(view, battleFieldView);
    }
}
