using utils;
using UnityEditor;
using UnityEngine;
using patternClass;
using System.Collections.Generic;

[CustomEditor(typeof(BulletEnemy))]
[CanEditMultipleObjects]
public class BulletEnemyEditor : Editor
{
    string[] optionSpawnBullet = new string[]
        {
            "none", "matrix", "laser", "spiral", "solo", "circle", "particle"
        };
    string[] optionBullet = new string[]
        {
            "none", "follow", "forward", "curve", "looking"
        };
    public override void OnInspectorGUI()
    {
        int nbPattern = -1;
        int currentPattern;
        BulletEnemy enemy = (BulletEnemy)target;
        if (enemy.patterns == null) enemy.patterns = new Pattern[1];
        if (enemy.patterns[0] == null) enemy.patterns[0] = new Pattern();
        // Recupere le nombre de paterne
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Nombre de Partern : ");
        nbPattern = EditorGUILayout.IntField(enemy.patterns.Length);
        EditorGUILayout.EndHorizontal();
        if (nbPattern != 0 && nbPattern != -1)
            enemy.patterns = new UtilsList().Resize<Pattern>(enemy.patterns, nbPattern).ToArray();
        // Recupere les info pour tout les paterne selon leurs type
        for (currentPattern = 0; currentPattern < enemy.patterns.Length; currentPattern++)
        {
            EditorGUILayout.LabelField("______________________________________________________________________________");
            enemy.patterns[currentPattern].typeSpawnBullet = EditorGUILayout.Popup("Type spawn bullet", enemy.patterns[currentPattern].typeSpawnBullet, optionSpawnBullet);
            enemy.patterns[currentPattern].typeBullet = EditorGUILayout.Popup("Type bullet", enemy.patterns[currentPattern].typeBullet, optionBullet);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("durrée du Partern : ");
            enemy.patterns[currentPattern].delaysPatternTotal = EditorGUILayout.FloatField(enemy.patterns[currentPattern].delaysPatternTotal);
            EditorGUILayout.EndHorizontal();
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
                    break;
                case "solo":
                    bulletPrefabs(enemy.patterns[currentPattern]);
                    break;
                case "circle":
                    bulletPrefabs(enemy.patterns[currentPattern]);
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
                    //Debug.Log("follow");
                    break;
                case "follow":
                    break;
                case "forward":
                    break;
                default:
                    break;
            }
        }
    }
    
    void bulletPrefabs(Pattern currentPattern)
    {
        int nbBulletVisual;
        EditorGUILayout.LabelField("/=====================\\");
        EditorGUILayout.LabelField("==== Visuel Bullet Random ====");
        if (currentPattern.bulletVisual == null) currentPattern.bulletVisual = new BulletVisual[1];
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("nb : ");
        nbBulletVisual = EditorGUILayout.IntField(currentPattern.bulletVisual.Length);
        EditorGUILayout.EndHorizontal();
        if (nbBulletVisual != currentPattern.bulletVisual.Length)
        {
            currentPattern.bulletVisual = new UtilsList().Resize<BulletVisual>(currentPattern.bulletVisual, nbBulletVisual).ToArray();
        }
        for (int i = 0; i < currentPattern.bulletVisual.Length; i++)
        {
            if (i != 0) EditorGUILayout.LabelField("~~~~~~~~~~~~~~~~");
            currentPattern.bulletVisual[i].Prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", currentPattern.bulletVisual[i].Prefab, typeof(GameObject), false);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Color");
            currentPattern.bulletVisual[i].color = EditorGUILayout.ColorField(currentPattern.bulletVisual[i].color);
            EditorGUILayout.EndHorizontal();
            currentPattern.bulletVisual[i].sprite = (Sprite)EditorGUILayout.ObjectField("Sprite", currentPattern.bulletVisual[i].sprite, typeof(Sprite), false);
        }
        EditorGUILayout.LabelField("\\=====================/");
    }

    void particleBullet(Pattern currentPattern)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Material");
        currentPattern.bulletMaterial = (Material)EditorGUILayout.ObjectField(currentPattern.bulletMaterial, typeof(Material), false);
        EditorGUILayout.EndHorizontal();
        /*EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Color");
        currentPattern.bulletColor = EditorGUILayout.ColorField(currentPattern.bulletColor);
        EditorGUILayout.EndHorizontal();*/
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefabs");
        currentPattern.Prefabs = (GameObject)EditorGUILayout.ObjectField(currentPattern.Prefabs, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("StartSpeed : ");
        currentPattern.startSpeed = EditorGUILayout.FloatField(currentPattern.startSpeed);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("rateOverTime : ");
        currentPattern.rateOverTime = EditorGUILayout.FloatField(currentPattern.rateOverTime);
        EditorGUILayout.EndHorizontal();
    }

    void laserBullet(Pattern currentPattern)
    {
        if (currentPattern.laserSpriteWarning == null || currentPattern.laserSpriteActif == null)
        {
            currentPattern.laserSpriteWarning = new Sprite[3];
            currentPattern.laserSpriteActif = new Sprite[3];
        }
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("delayWarning : ");
        currentPattern.slerpWarning = EditorGUILayout.FloatField(currentPattern.slerpWarning);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("delayActif : ");
        currentPattern.delayActif = EditorGUILayout.FloatField(currentPattern.delayActif);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("slerpWarning : ");
        currentPattern.slerpWarning = Mathf.Clamp(EditorGUILayout.FloatField(currentPattern.slerpWarning), 0, 1);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("slerpActif : ");
        currentPattern.slerpActif = Mathf.Clamp(EditorGUILayout.FloatField(currentPattern.slerpActif), 0, 1);
        EditorGUILayout.EndHorizontal();
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
        if (currentPattern.test == null)
        {
            Debug.Log("reset Matrix");
            currentPattern.width = 5;
            currentPattern.height = 5;
            currentPattern.test = new bool[5 * 5];
        }
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Delay tir : ");
        currentPattern.delaysPattern = EditorGUILayout.FloatField(currentPattern.delaysPattern);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("X : ");
        newX = EditorGUILayout.IntField(currentPattern.width);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Y : ");
        newY = EditorGUILayout.IntField(currentPattern.height);
        EditorGUILayout.EndHorizontal();
        if (currentPattern.width != newX || currentPattern.height != newY || currentPattern.test == null)
        {
            Debug.Log("reset Matrix size");
            currentPattern.width = newX;
            currentPattern.height = newY;
            currentPattern.test = new bool[newX * newY];
        }
        for (xInc = 0; xInc < currentPattern.width; xInc++)
        {
            EditorGUILayout.BeginHorizontal();
            for (yInc = 0; yInc < currentPattern.height; yInc++)
            {
                currentPattern.test[xInc + currentPattern.width * yInc] = EditorGUILayout.Toggle("", currentPattern.test[xInc + currentPattern.width * yInc], GUILayout.Width(10));
            }
            EditorGUILayout.EndHorizontal();
        }

    }

}
