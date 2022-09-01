
using Controls;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootStrapper : MonoBehaviour
{
    [SerializeField] private View _view;
    [SerializeField] private BattleFieldView _battleFieldView;
    private Controller controller;

    void Start()
    {
        controller = new Controller(_view, _battleFieldView);
    }
}
