using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    //lets create a getter for instance coz we want this to be private instead of public.

    public static T Instance
    {
        get
        {
            if (instance == null)

                instance = FindObjectOfType<T>();
            //going to look thru the hierarchy and find anything names T and create an instance for it.
            else if (instance != FindObjectOfType<T>())
                Destroy(FindObjectOfType<T>());
            DontDestroyOnLoad(FindObjectOfType<T>());
            return instance;
        }
    }
    /* "where T: Monobehaviour"thats saying if we pass in game manager as the type, it would say game manager is inheriting type of the library monobehaviour */
    //end of Singleton
}
