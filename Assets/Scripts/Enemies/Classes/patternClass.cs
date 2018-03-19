using UnityEngine;
using typeSpawnBullet;
using System;

namespace patternClass
{
    [Serializable]
    public class Pattern
    {
        public int typeSpawnBullet = 0;
        public int typeBullet = 0;
        public float delaysPartern = 0;

        // champ spetials matrix
        public matrixSpawnBullet motifMatrix;
        public Sprite bulletSprite;
        public Color bulletColor;

        // champ sptials laser
        public float delayWarning = 0;
        public float delayActif = 0;
        public Sprite[] laserSpriteWarning;
        public float slerpWarning = 0.5f;
        public Sprite[] laserSpriteActif;
        public float slerpActif = 0.5f;

        //champ spetials particle;
        public Material bulletMaterial;
        //public Color bulletColor;
        public GameObject Prefabs;
        public float startSpeed = 2;
        public float rateOverTime = 2;
    }
}