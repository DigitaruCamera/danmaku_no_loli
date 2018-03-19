using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using typeSpawnBullet;
using patternClass;

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
                delayedPattern = Time.time + patterns[currentPattern].delaysPartern;
            }
            switch (optionSpawnBullet[patterns[currentPattern].typeSpawnBullet])
            {
                case "matrix":
                    if (Time.time >= delayedPattern)
                    {
                        currentPattern++;
                        if (currentPattern >= patterns.Length)
                            currentPattern = 0;
                        delayedPattern = Time.time + patterns[currentPattern].delaysPartern;
                    }
                    matrixBullet(patterns[currentPattern]);
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

    float delayedShoot = 0;
    void matrixBullet(Pattern currentPattern)
    {
        print("coucou");
        if (Time.time >= delayedShoot)
        {
            delayedShoot = Time.time + currentPattern.motifMatrix.delayTir;
            int x;
            int y;
            for (x = 0; x < currentPattern.motifMatrix.x; x++)
            {
                for (y = 0; y < currentPattern.motifMatrix.y; y++)
                {
                    if (currentPattern.motifMatrix.matrix[x][y] != false)
                    {
                        GameObject clone = Instantiate(currentPattern.Prefabs, transform.position + new Vector3(x, y, 0), transform.rotation) as GameObject;
                        clone.name = currentPattern.Prefabs.name;
                        clone.GetComponent<SpriteRenderer>().color = currentPattern.bulletColor;
                    }
                }

            }
        }
    }
}
