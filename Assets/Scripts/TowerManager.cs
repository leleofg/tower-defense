using UnityEngine;

public class TowerManager : Singleton<TowerManager> {

    private TowerBtn towerBtnPressed;
    private SpriteRenderer spriteRenderer;

    protected override void Awake () {
        base.Awake();
    }

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update () {
        if (Input.GetMouseButton(0)) {
            Vector2 worldpoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldpoint, Vector2.zero);
            if (hit.collider.tag != "Path" && hit.collider.tag != "TowerPlaced") {
                hit.collider.tag = "TowerPlaced";
                PlaceTower(hit);
            }
        }

        if (spriteRenderer.enabled) {
            FollowMouse();
        }
    }

    public void PlaceTower (RaycastHit2D hit) {
        if (towerBtnPressed != null) {
            GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
            DisableDragSprite();
        }
    }

    public void selectedTower (TowerBtn towerSelected) {
        towerBtnPressed = towerSelected;
        EnableDragSprite(towerBtnPressed.DragSprite);
    }

    public void FollowMouse () {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    public void EnableDragSprite (Sprite sprite) {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
    }

    public void DisableDragSprite () {
        spriteRenderer.enabled = false;
    }
}
