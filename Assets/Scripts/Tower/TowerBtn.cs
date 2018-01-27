using UnityEngine;

public class TowerBtn : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject towerObject;
    [SerializeField]
    private Sprite dragSprite;
    public GameObject TowerObject
    {
        get { return towerObject; }//getter to get the button set here.
       
    }

    public Sprite DragSprite
    {
        get { return dragSprite; }//getter to get the button set here.

    }

}
