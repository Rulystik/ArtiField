using System;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BattleFieldView : MonoBehaviour
    {
        [SerializeField] private GameObject battleFields;
        [SerializeField] private GameObject gameTilePrefab;
        [SerializeField] private GameObject playerField;
        [SerializeField] private GameObject enemyField;
    
        [SerializeField] private Button shootButton;
        [SerializeField] private Button readyForGameButton;
    
        [SerializeField] private Sprite crossSprite;
        [SerializeField] private Sprite missedSprite;
        [SerializeField] private Sprite damagedSprite;
        [SerializeField] private Sprite artySprite;

        private float sizeBackTile;
        private bool ableToShoot;

        private RectTransform playerFieldRect;
        private RectTransform enemyFieldRect; 

        public Dictionary<int, GameTile> playerViewObjects;
        public Dictionary<int, GameTile> enemyViewObjects;
    
        public Action<int> ShootMarkAction;
        public Action ShootButtonDownAction;
        public Action EnemyFieldOnPosAction;

    

        void Start()
        {
            Init();
        }

        void Update()
        {
            if (ableToShoot && Input.GetMouseButtonDown(0))
            {
                Vector3 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);

                if (hit.collider != null)
                {
                    var click = hit.collider.gameObject.GetComponent<GameTile>();
                    ShootMarkAction?.Invoke(click.Id);
                }
            }
        }
    
        public void PrepareFields()
        {
            DeactivateAllCell();
        
            var widthField = GameSettings.Instance.WidthField;
            var heightField = GameSettings.Instance.HeightField;
        
            sizeBackTile = playerFieldRect.rect.width / widthField;
        
            playerFieldRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,sizeBackTile * heightField );
            enemyFieldRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,sizeBackTile * heightField);

            var scale = playerFieldRect.rect.width / (widthField * 100) - 0.1f ;

            float XPos = sizeBackTile / 2;
            float YPos = -XPos;
        
            for (int i = 0; i < widthField; i++)
            {
                if (i > 0) XPos += sizeBackTile;
            
                for (int j = 0; j < heightField; j++)
                {
                    int id = i == 0? j :  i*100 + j;

                    var player = playerViewObjects[id];
                    player.SetPosition(new Vector2(XPos, YPos));
                    player.SetScale(scale);
                    player.gameObject.SetActive(true);

                    var enemy = enemyViewObjects[id];
                    enemy.SetPosition(new Vector2(XPos,YPos));
                    enemy.SetScale(scale);
                    enemy.gameObject.SetActive(true);

                    if (j == heightField - 1)
                    {
                        YPos = -(sizeBackTile / 2);
                    }
                    else
                    {
                        YPos -= sizeBackTile;
                    }
                }
            }
        
        }
        public void Init()
        {
            ableToShoot = false;
            playerViewObjects = new Dictionary<int, GameTile>();
            enemyViewObjects = new Dictionary<int, GameTile>();
        
            playerFieldRect = playerField.GetComponent<RectTransform>();
            enemyFieldRect = enemyField.GetComponent<RectTransform>();
            playerFieldRect.anchoredPosition = Vector3.zero;
            enemyFieldRect.anchoredPosition = new Vector3(Screen.width * 2, 0,0);
        
            shootButton.onClick.AddListener(ShootButtonDown);
            shootButton.gameObject.SetActive(false);
        
            readyForGameButton.onClick.AddListener(SwapFields);

            CreateFieldsPool();
        
        }
        private void CreateFieldsPool()
        {
            var widthField = GameSettings.Instance.WidthField;
            var heightField = GameSettings.Instance.HeightField;

            for (int i = 0; i < widthField; i++)
            {
                for (int j = 0; j < heightField; j++)
                {
                    var playerGameTile = Instantiate(gameTilePrefab, Vector3.zero, quaternion.identity, this.playerField.transform)
                        .GetComponent<GameTile>();
                    var enemyGameTile = Instantiate(gameTilePrefab, Vector3.zero, quaternion.identity, this.enemyField.transform)
                        .GetComponent<GameTile>();
                    int id = i == 0? j :  i*100 + j;
                
                    playerGameTile.Init(id);
                    playerGameTile.gameObject.SetActive(false);
                    enemyGameTile.Init(id);
                    enemyGameTile.gameObject.SetActive(false);
                
                    playerViewObjects.Add(id, playerGameTile);
                    enemyViewObjects.Add(id, enemyGameTile);
                }
            }
        
            battleFields.SetActive(false);
        }
    
        public void BattleFieldActiveOnOff()
        {
            battleFields.SetActive(!battleFields.activeSelf);
        }

        public void SwapFields()
        {

            if (playerFieldRect.localPosition == Vector3.zero)
            {
                playerFieldRect.DOAnchorPos(new Vector2(Screen.width * -2, 0), 0.5f);
                enemyFieldRect.DOAnchorPos(Vector2.zero, 0.5f).OnComplete(()=>EnemyFieldOnPos());
            }
            else
            {
                enemyFieldRect.DOAnchorPos(new Vector2(Screen.width * 2,0), 0.5f);
                playerFieldRect.DOAnchorPos(Vector2.zero, 0.5f).OnComplete(()=> PlayerFieldOnPos());
            }
        }
    

        public Sprite GetCrossImage()
        {
            return crossSprite;
        }

        public Sprite GetArtySprite()
        {
            return artySprite;
        }

        public void ShootButtonDown()
        {
            ShootButtonDownAction?.Invoke();
        }

        public Sprite GetSpriteForCell(CellState state)
        {
            switch (state)
            {
                case CellState.Clear :
                    return null;
                case CellState.Missed:
                    return missedSprite;
                case CellState.Damaged:
                    return damagedSprite;
                case CellState.Destroyed:
                    return damagedSprite;
                default:
                    return null;
            }
        }

        private void EnemyFieldOnPos()
        {
            ableToShoot = true;
            shootButton.gameObject.SetActive(true);
            EnemyFieldOnPosAction?.Invoke();
        }

        private void PlayerFieldOnPos()
        {
            ableToShoot = false;
            shootButton.gameObject.SetActive(false);
        }

        public void SetImageOnEnemyField(int id, CellState state)
        {
            var sprite = GetSpriteForCell(state);
            var obj = enemyViewObjects[id];
        
            obj.SetStateIcon(sprite);
            if (state == CellState.Clear)
            {
                obj.DeactivateStateTile();
            }
            else
            {
                obj.ActivateStateTile();
            }
        }

        public void SetImageOnPlayerField(int id, CellState state)
        {
            var sprite = GetSpriteForCell(state);
            var obj = playerViewObjects[id];
        
            obj.SetStateIcon(sprite);
            if (state == CellState.Clear)
            {
                obj.DeactivateStateTile();
            }
            else
            {
                obj.ActivateStateTile();
            }
        }
        private void DeactivateAllCell()
        {
            foreach (var viewObject in playerViewObjects)
            {
                viewObject.Value.gameObject.SetActive(false);
                enemyViewObjects[viewObject.Key].gameObject.SetActive(false);
            }
        }
    }
}
