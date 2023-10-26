using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class Colisstion : MonoBehaviour
{
    [SerializeField] ParticleSystem ExplosionParticles;
    [SerializeField] ParticleSystem SuccessParticles;

    bool colissionDisable = false;
    void Start()
    {
        
    }
    void Update() 
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if(UnityEngine.Input.GetKeyDown(KeyCode.C))
        {
           colissionDisable = !colissionDisable;
        }
        else if(UnityEngine.Input.GetKeyDown(KeyCode.N))
        {
            NextLevel();
        }    
    }
    void OnCollisionEnter(Collision other)                  //Check colider with gameObject.
    {
        if(colissionDisable) {return;}
        switch (other.gameObject.tag)                       // Using "Tag" at Inspector to get Gameobject.
        {
            case "Launchpad":
                Debug.Log("can stay here");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            case "Fuel":
                Debug.Log("Add fuel");
                break;
            default:
                StartCrashSequence();
                break;
        }
    
    }

    void StartCrashSequence()                           //todo stop 1s when colider with gameObject defaut.
    {
        GetComponent<Moverment>().enabled = false;
        Invoke("RealoadLevel", 1f);
        ExplosionParticles.Play();
    }

    void StartSuccessSequence()                         //todo next level when you finish game with time 1s.
    {
        GetComponent<Moverment>().enabled = false;
        Invoke("NextLevel", 1f);
        SuccessParticles.Play();
    }

    void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void RealoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
