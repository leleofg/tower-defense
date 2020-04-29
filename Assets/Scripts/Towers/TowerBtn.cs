using UnityEngine;

public class TowerBtn : MonoBehaviour {
    #pragma warning disable 0649
    [SerializeField] private GameObject towerObject;
    [SerializeField] private Sprite dragSprit;
    #pragma warning restore 0649

    public GameObject TowerObject {
        get {
            return towerObject;
        }
    }

    public Sprite DragSprite {
        get {
            return dragSprit;
        }
    }
}
