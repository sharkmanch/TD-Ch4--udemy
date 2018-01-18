using UnityEngine;

public class TowerBtn : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    private GameObject towerObject;

    public GameObject TowerObject
    {
        get { return towerObject; }//getter to get the button set here.
    }

	}
