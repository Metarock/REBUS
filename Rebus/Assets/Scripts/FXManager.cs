using System.Collections;
using UnityEngine;

//This Class is used to store the Sound Effects. This class does NOT store Background Music.
public class FXManager : MonoBehaviour
{
    //Sound Effects

    public AudioSource pistolShot;
    public AudioSource uziShot;
    public AudioSource shotgunShot;
    public AudioSource shotgunReload;
    public AudioSource buttonPress;

    public static bool fxmanagerExists;

    // Start is called before the first frame update
    void Start()
    {
        //For having only one instance of FXManager
        if (!fxmanagerExists)
        {
            fxmanagerExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
