using System.Collections; // required for arrays and other collections
using System.Collections.Generic; // required to use Lists or dictionaries
using UnityEngine; // required for unity
using UnityEngine.SceneManagement;  // for loading and reloading of scenes

public class Main : MonoBehaviour {
    static public Main S; // singleton for main

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies; // array of enemy prefabs
    public float enemySpawnPerSecond = 0.5f; // # enemies/second
    public float enemyDefaultPadding = 1.5f; // padding for position

    private BoundsCheck bndCheck;

	// Use this for initialization
	void Awake () {
        S = this;
        // set bndCheckto reference the BoundsCheck component on this GameObject
        bndCheck = GetComponent<BoundsCheck>();
        // invoke SpawnEnemy () once (in 2 seconds, based on default values)
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
	}

    public void SpawnEnemy() {
        //Debug.Log("Spawningsomethiong at" + Time.time);
        // pick a random Enemy prefab to instantiate
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]); //Error here

        // position the enemy above the screen with a random x position
        float enemyPadding = enemyDefaultPadding; // book typo?
        //float enemyDefaultPadding; 
        if (go.GetComponent<BoundsCheck>() != null) {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);

            // set the initial position for the spawned enemy
            Vector3 pos = Vector3.zero;
            float xMin = -bndCheck.camWidth + enemyPadding;
            float xMax = bndCheck.camWidth - enemyPadding;
            pos.x = Random.Range(xMin, xMax);
            pos.y = bndCheck.camHeight + enemyPadding;
            go.transform.position = pos;

            // invoke SpawnEnemy () again
            Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
        }
    }

    public void DelayedRestart(float delay) {
        // invoke the restart () method in delay seconds
        Invoke("Restart", delay);
    }

    public void Restart() {
        // reload _Scene_0 to restart the game
        SceneManager.LoadScene("_Scene_0");
    }
} // first bracket

		

