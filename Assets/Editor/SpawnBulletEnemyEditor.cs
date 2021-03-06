﻿using utils;
using UnityEditor;
using UnityEngine;
using patternClass;

[CustomEditor(typeof(SpawnBulletEnemy))]
[CanEditMultipleObjects]
public class SpawnBulletEnemyEditor : Editor
{
    string[] optionSpawnBullet = new string[]
        {
            "none", "matrix", "laser", "spiral", "solo", "circle"
        };
    string[] optionBullet = new string[]
        {
            "none", "follow", "forward", "curve", "looking", "particle"
        };
    public override void OnInspectorGUI()
    {
        int nbPattern = -1;
        int currentPattern;
        SpawnBulletEnemy enemy = (SpawnBulletEnemy)target;
        if (enemy.patterns == null) enemy.patterns = new Pattern[1];
        if (enemy.patterns[0] == null) enemy.patterns[0] = new Pattern();
        nbPattern = EditorGUILayout.IntField("Nombre de Partern : ", enemy.patterns.Length);
        if (nbPattern != 0 && nbPattern != -1)
            enemy.patterns = new UtilsList().Resize<Pattern>(enemy.patterns, nbPattern).ToArray();
        for (currentPattern = 0; currentPattern < enemy.patterns.Length; currentPattern++)
        {
            EditorGUILayout.LabelField("______________________________________________________________________________");
            enemy.patterns[currentPattern].typeSpawnBullet = EditorGUILayout.Popup("Type spawn bullet", enemy.patterns[currentPattern].typeSpawnBullet, optionSpawnBullet);
            enemy.patterns[currentPattern].typeBullet = EditorGUILayout.Popup("Type bullet", enemy.patterns[currentPattern].typeBullet, optionBullet);
            enemy.patterns[currentPattern].delaysPattern = EditorGUILayout.FloatField("durrée du Partern : ", enemy.patterns[currentPattern].delaysPattern);
            enemy.patterns[currentPattern].nbIteration = EditorGUILayout.IntField("nb Iteration parttern : ", enemy.patterns[currentPattern].nbIteration);
            switch (optionSpawnBullet[enemy.patterns[currentPattern].typeSpawnBullet])
            {
                case "matrix":
                    bulletPrefabs(enemy.patterns[currentPattern]);
                    matrixBullet(enemy.patterns[currentPattern]);
                    break;
                case "laser":
                    laserBullet(enemy.patterns[currentPattern]);
                    break;
                case "spiral":
                    bulletPrefabs(enemy.patterns[currentPattern]);
                    spiralBullet(enemy.patterns[currentPattern]);
                    break;
                case "solo":
                    bulletPrefabs(enemy.patterns[currentPattern]);
                    break;
                case "circle":
                    bulletPrefabs(enemy.patterns[currentPattern]);
                    circleBullet(enemy.patterns[currentPattern]);
                    break;
                case "particle":
                    particleBullet(enemy.patterns[currentPattern]);
                    break;
                default:
                    break;
            }
            switch (optionBullet[enemy.patterns[currentPattern].typeBullet])
            {
                case "none":
                    break;
                case "follow":
                    followBullet(enemy.patterns[currentPattern]);
                    break;
                case "forward":
                    forwardBullet(enemy.patterns[currentPattern]);
                    break;
                case "curve":
                    curveBullet(enemy.patterns[currentPattern]);
                    break;
                case "looking":
                    lookingBullet(enemy.patterns[currentPattern]);
                    break;
                case "eloigne":
                    lookingBullet(enemy.patterns[currentPattern]);
                    break;
                default:
                    break;
            }
        }
    }

    void followBullet(Pattern currentPattern)
    {
        currentPattern.bulletSpeed = EditorGUILayout.FloatField("Speed bullet", currentPattern.bulletSpeed);
        currentPattern.bulletSlerp = Mathf.Clamp(EditorGUILayout.FloatField("Speed bullet", currentPattern.bulletSlerp), 0, 1);
    }

    void forwardBullet(Pattern currentPattern)
    {
        currentPattern.bulletSpeed = EditorGUILayout.FloatField("Speed bullet", currentPattern.bulletSpeed);
    }

    void curveBullet(Pattern currentPattern)
    {
        currentPattern.bulletSpeed = EditorGUILayout.FloatField("Speed bullet", currentPattern.bulletSpeed);
        currentPattern.curveX = EditorGUILayout.CurveField("Curve X", currentPattern.curveX);
        currentPattern.curveY = EditorGUILayout.CurveField("Curve Y", currentPattern.curveY);
        currentPattern.curveScale = EditorGUILayout.CurveField("Curve Scale", currentPattern.curveScale);
    }

    void lookingBullet(Pattern currentPattern)
    {
        currentPattern.bulletSpeed = EditorGUILayout.FloatField("Speed bullet", currentPattern.bulletSpeed);
    }

    void spiralBullet(Pattern currentPattern)
    {
        currentPattern.rotSpeed = EditorGUILayout.FloatField("Speed rotation", currentPattern.rotSpeed);
        currentPattern.sens = EditorGUILayout.Toggle("sens horaire", currentPattern.sens);
        currentPattern.nbSpawnPoint = EditorGUILayout.IntField("nombre spawn point", currentPattern.nbSpawnPoint);
    }

    void circleBullet(Pattern currentPattern)
    {
        currentPattern.nbSpawnPoint = EditorGUILayout.IntField("nombre spawn point", currentPattern.nbSpawnPoint);
    }

    void bulletPrefabs(Pattern currentPattern)
    {
        int nbBulletVisual;
        EditorGUILayout.LabelField("/=====================\\");
        EditorGUILayout.LabelField("==== Visuel Bullet Random ====");
        if (currentPattern.bulletVisual == null) currentPattern.bulletVisual = new BulletVisual[1];
        nbBulletVisual = EditorGUILayout.IntField("nb : ", currentPattern.bulletVisual.Length);
        if (nbBulletVisual != currentPattern.bulletVisual.Length)
        {
            currentPattern.bulletVisual = new UtilsList().Resize<BulletVisual>(currentPattern.bulletVisual, nbBulletVisual).ToArray();
        }
        for (int i = 0; i < currentPattern.bulletVisual.Length; i++)
        {
            if (i != 0) EditorGUILayout.LabelField("~~~~~~~~~~~~~~~~");
            currentPattern.bulletVisual[i].scaleBullet = EditorGUILayout.FloatField("Scale bullet", currentPattern.bulletVisual[i].scaleBullet);
            currentPattern.bulletVisual[i].Prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", currentPattern.bulletVisual[i].Prefab, typeof(GameObject), false);
            currentPattern.bulletVisual[i].color = EditorGUILayout.ColorField("Color", currentPattern.bulletVisual[i].color);
            currentPattern.bulletVisual[i].sprite = (Sprite)EditorGUILayout.ObjectField("Sprite", currentPattern.bulletVisual[i].sprite, typeof(Sprite), false);
        }
        EditorGUILayout.LabelField("\\=====================/");
    }

    void particleBullet(Pattern currentPattern)
    {
        currentPattern.bulletMaterial = (Material)EditorGUILayout.ObjectField("Material", currentPattern.bulletMaterial, typeof(Material), false);
        currentPattern.Prefabs = (GameObject)EditorGUILayout.ObjectField("Prefabs", currentPattern.Prefabs, typeof(GameObject), false);
        currentPattern.startSpeed = EditorGUILayout.FloatField("StartSpeed : ", currentPattern.startSpeed);
        currentPattern.rateOverTime = EditorGUILayout.FloatField("rateOverTime : ", currentPattern.rateOverTime);
    }

    void laserBullet(Pattern currentPattern)
    {
        if (currentPattern.laserSpriteWarning == null || currentPattern.laserSpriteActif == null)
        {
            currentPattern.laserSpriteWarning = new Sprite[3];
            currentPattern.laserSpriteActif = new Sprite[3];
        }
        currentPattern.slerpWarning = EditorGUILayout.FloatField("delayWarning : ", currentPattern.slerpWarning);
        currentPattern.delayActif = EditorGUILayout.FloatField("delayActif : ", currentPattern.delayActif);
        currentPattern.slerpWarning = Mathf.Clamp(EditorGUILayout.FloatField("slerpWarning : ", currentPattern.slerpWarning), 0, 1);
        currentPattern.slerpActif = Mathf.Clamp(EditorGUILayout.FloatField("slerpActif : ", currentPattern.slerpActif), 0, 1);
        currentPattern.laserSpriteWarning[0] = (Sprite)EditorGUILayout.ObjectField("Sprite Debut warning", currentPattern.laserSpriteWarning[0], typeof(Sprite), false);
        currentPattern.laserSpriteWarning[1] = (Sprite)EditorGUILayout.ObjectField("Sprite Mileu warning", currentPattern.laserSpriteWarning[1], typeof(Sprite), false);
        currentPattern.laserSpriteWarning[2] = (Sprite)EditorGUILayout.ObjectField("Sprite Fin warning", currentPattern.laserSpriteWarning[2], typeof(Sprite), false);
        currentPattern.laserSpriteActif[0] = (Sprite)EditorGUILayout.ObjectField("Sprite Debut Actif", currentPattern.laserSpriteActif[0], typeof(Sprite), false);
        currentPattern.laserSpriteActif[1] = (Sprite)EditorGUILayout.ObjectField("Sprite Mileu Actif", currentPattern.laserSpriteActif[1], typeof(Sprite), false);
        currentPattern.laserSpriteActif[2] = (Sprite)EditorGUILayout.ObjectField("Sprite Fin Actif", currentPattern.laserSpriteActif[2], typeof(Sprite), false);
    }
    void matrixBullet(Pattern currentPattern)
    {
        int newX;
        int newY;
        int xInc;
        int yInc;
        if (currentPattern.matrix == null)
        {
            currentPattern.width = 5;
            currentPattern.height = 5;
            currentPattern.matrix = new bool[5 * 5];
        }
        currentPattern.tailleMatrix = EditorGUILayout.FloatField("taille matrix : ", currentPattern.tailleMatrix);
        newX = EditorGUILayout.IntField("X : ", currentPattern.width);
        newY = EditorGUILayout.IntField("Y : ", currentPattern.height);
        if (currentPattern.width != newX || currentPattern.height != newY || currentPattern.matrix == null)
        {
            currentPattern.width = newX;
            currentPattern.height = newY;
            currentPattern.matrix = new bool[newX * newY];
        }
        for (xInc = 0; xInc < currentPattern.width; xInc++)
        {
            EditorGUILayout.BeginHorizontal();
            for (yInc = 0; yInc < currentPattern.height; yInc++)
            {
                currentPattern.matrix[xInc + currentPattern.width * yInc] = EditorGUILayout.Toggle("", currentPattern.matrix[xInc + currentPattern.width * yInc], GUILayout.Width(10));
            }
            EditorGUILayout.EndHorizontal();
        }

    }

}
