using UnityEngine;
using System;

namespace patternClass
{
    [Serializable]
    public class BulletVisual
    {
        public GameObject Prefab;
        public Sprite sprite;
        public Color color;
        public float scaleBullet;
    }

    [Serializable]
    public class Pattern
    {
        public int typeSpawnBullet = 0;
        public int typeBullet = 0;
        public float delaysPattern = 0;
        public int nbIteration = 0;

        public BulletVisual[] bulletVisual;
        // champ spetials matrix
        //        public MatrixOfBool motifMatrix;
        public float tailleMatrix;
        public bool[] matrix;
        public int width;
        public int height;

        // champ sptials laser
        public float delayWarning = 0;
        public float delayActif = 0;
        public Sprite[] laserSpriteWarning;
        public float slerpWarning = 0.5f;
        public Sprite[] laserSpriteActif;
        public float slerpActif = 0.5f;

        //champ spetials particle;
        public Material bulletMaterial;
        public GameObject Prefabs;
        public float startSpeed = 2;
        public float rateOverTime = 2;

        //champ sptials Spiral 
        public float rotSpeed;
        public bool sens;
        public int nbSpawnPoint;

        public float bulletSpeed;
        public float bulletSlerp;
        public AnimationCurve curveX = AnimationCurve.Linear(0, 0, 10, 10);
        public AnimationCurve curveY = AnimationCurve.Linear(0, 0, 10, 10);
        public AnimationCurve curveScale = AnimationCurve.Linear(0, 0, 10, 10);
    }
}