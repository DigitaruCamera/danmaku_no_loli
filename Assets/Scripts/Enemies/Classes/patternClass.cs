using UnityEngine;
using typeSpawnBullet;
using System;
using utils;

namespace patternClass
{
    [Serializable]
    public class Pattern
    {
        public int typeSpawnBullet = 0;
        public int typeBullet = 0;
        public float delaysPatternTotal = 0;
        public float delaysPattern = 0;

        // champ spetials matrix
//        public MatrixOfBool motifMatrix;
        public bool[] test;
        public int width;
        public int height;
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