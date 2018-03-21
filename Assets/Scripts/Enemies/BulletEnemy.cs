using UnityEngine;
using patternClass;
using utils;

public class BulletEnemy : MonoBehaviour {
    public GameObject PrefabsBullet;
    public Pattern[] patterns = new Pattern[1];
    string[] optionSpawnBullet = new string[]
        {
            "none", "matrix", "laser", "spiral", "solo", "circle", "particle"
        };
    string[] optionBullet = new string[]
        {
            "none", "follow", "forward", "curve", "looking",
        };

    void Start () {
     
    }
    float delayedPattern = 0;
    int currentPattern = -1;
	void Update () {
        if(patterns[0] != null)
        {
            if (Time.time >= delayedPattern)
            {
                currentPattern++;
                if (currentPattern >= patterns.Length)
                    currentPattern = 0;
                delayedPattern = Time.time + patterns[currentPattern].delaysPatternTotal;
            }
            switch (optionSpawnBullet[patterns[currentPattern].typeSpawnBullet])
            {
                case "matrix":
                    break;
                case "laser":
                    //laserBullet(patterns[currentPattern]);
                    break;
                case "spiral":
                    break;
                case "solo":
                    break;
                case "circle":
                    break;
                case "particle":
                    //particleBullet(patterns[currentPattern]);
                    break;
                default:
                    break;
            }
        } else
        {
            Debug.LogError("un enemy n'a pas de patern");
        }
    }
}
