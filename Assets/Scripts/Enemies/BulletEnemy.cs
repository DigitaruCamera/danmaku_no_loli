using UnityEngine;
using patternClass;

public class BulletEnemy : MonoBehaviour {
    public Pattern currentPattern;

    private void Update()
    {
        string[] optionBullet = new string[]
            {
                "none", "follow", "forward", "curve", "looking", "eloigne"
            };
        switch (optionBullet[currentPattern.typeBullet])
        {
            case "none":
                break;
            case "follow":
                break;
            case "forward":
                break;
            case "curve":
                break;
            case "looking":
                break;
            case "eloigne":
                break;
            default:
                break;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
