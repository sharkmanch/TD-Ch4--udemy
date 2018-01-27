using UnityEngine.EventSystems;
using UnityEngine;

public class TowerManager : Singleton<TowerManager> {

    private TowerBtn towerBtnPressed;
    private SpriteRenderer spriteRenderer;



	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>(); //looking for the component in unity, it grab the ref of the renderer to this script. we need to have a sprite attached to the mouse, so that the sprite can follow the mouse (to remind you what tower you are dragging onto buildsite.)
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider.tag == "buildSite")
            {
                hit.collider.tag = "buildSiteFull"; //no == coz we are setting it not if.
                placeTower(hit);
            }
         
        }

        if (spriteRenderer.enabled)
        {
            followMouse();
        }//need 3 methods to tell sprite to follow the mouse, enable the sprite renderer, then we set the sprite render to follow the mouse, and disable it when dropped off.
    }

    public void placeTower(RaycastHit2D hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && towerBtnPressed != null)
        {
            GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
            disableDragSprite();
        }
    }


    public void selectedTower(TowerBtn towerSelected)
    {
        towerBtnPressed = towerSelected;
        enableDragSprite(towerBtnPressed.DragSprite);
    //    Debug.Log("pressed!!! " + towerBtnPressed.gameObject);

    }

    public void followMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    public void enableDragSprite(Sprite sprite)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
    }

    public void disableDragSprite()
    {
        spriteRenderer.enabled = false;

    }


}
