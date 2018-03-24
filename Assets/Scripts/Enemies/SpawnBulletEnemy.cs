using UnityEngine;
using patternClass;
using System.Collections;
using utils;

public class SpawnBulletEnemy : MonoBehaviour {
    public Pattern[] patterns = null;
    string[] optionSpawnBullet = new string[]
        {
            "none", "matrix", "laser", "spiral", "solo", "circle", "particle"
        };
    public bool Lock = false;
    int currentPattern = 0;
    int iterationPattern = 0;

    void Update ()
    {
        if (Lock == false)
        {
            switch (optionSpawnBullet[patterns[currentPattern].typeSpawnBullet])
            {
                case "matrix":
                    StartCoroutine(matrixBullet(patterns[currentPattern]));
                    break;
                case "laser":
//                    StartCoroutine(laserBullet(patterns[currentPattern]));
                    break;
                case "spiral":
                    StartCoroutine(spiralBullet(patterns[currentPattern]));
                    break;
                case "solo":
//                    StartCoroutine(bulletPrefabs(patterns[currentPattern]));
                    break;
                case "circle":
//                    StartCoroutine(circleBullet(patterns[currentPattern]));
                    break;
                case "particle":
//                    StartCoroutine(particleBullet(patterns[currentPattern]));
                    break;
                default:
                    break;
            }
            iterationPattern++;
            if (iterationPattern >= patterns[currentPattern].nbIteration)
            {
                iterationPattern = 0;
                currentPattern++;
                if (currentPattern >= patterns.Length)
                    currentPattern = 0;
            }
        }
    }

    void InstantiateBullet(Object original, Vector3 pos, Quaternion rot, Pattern currentPattern, Color color, Sprite sprite, float scaleBullet)
    {
        GameObject clone = Instantiate(original, pos, rot) as GameObject; 
        clone.name = original.name;
        clone.transform.localScale = clone.transform.localScale * scaleBullet;
        if (clone.GetComponent<SpriteRenderer>() != null)
        {
            clone.GetComponent<SpriteRenderer>().color = color;
            clone.GetComponent<SpriteRenderer>().sprite = sprite;
        }
        if (clone.GetComponent<BulletEnemy>() != null)
        {
            clone.GetComponent<BulletEnemy>().currentPattern = currentPattern;
        }
    }

    IEnumerator spiralBullet(Pattern currentPattern)
    {
        Lock = true;
        //champ sptials Spiral 
        //public float rotSpeed;
        //public bool sens;
        //public int nbSpawnPoint;
        yield return new WaitForSeconds(currentPattern.delaysPattern);
        Lock = false;
    }

    IEnumerator matrixBullet(Pattern currentPattern)
    {
        Lock = true;
        int xInc;
        int yInc;
        for (xInc = 0; xInc < currentPattern.width; xInc++)
        {
            for (yInc = 0; yInc < currentPattern.height; yInc++)
            {
                if (currentPattern.matrix[xInc + currentPattern.width * yInc] == true)
                {
                    int currentVisual = Random.Range(0, currentPattern.bulletVisual.Length - 1);
                    InstantiateBullet(currentPattern.bulletVisual[currentVisual].Prefab, transform.position + new Vector3(yInc * currentPattern.tailleMatrix, -xInc * currentPattern.tailleMatrix, 0), transform.rotation,
                        currentPattern, currentPattern.bulletVisual[currentVisual].color, currentPattern.bulletVisual[currentVisual].sprite, currentPattern.bulletVisual[currentVisual].scaleBullet);
                }
            }
        }
        yield return new WaitForSeconds(currentPattern.delaysPattern);
        Lock = false;
    }
}
