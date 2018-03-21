using utils;
using UnityEditor;
using UnityEngine;
using typeSpawnBullet;
using patternClass;
using System.Collections.Generic;

[CustomEditor(typeof(BulletEnemy))]
[CanEditMultipleObjects]
public class BulletEnemyEditor : Editor
{
    List<T> Resize<T>(List<T> list, int sz) where T : new()
    {
        if (list.Count < sz)
        {
            while (list.Count < sz)
            {
                list.Add(new T());
            }
        } else if ((list.Count > sz))
        {
            list.RemoveRange(sz, list.Count);
        }
        return list;
    }

    string[] optionSpawnBullet = new string[]
        {
            "none", "matrix", "laser", "spiral", "solo", "circle", "particle"
        };
    string[] optionBullet = new string[]
        {
            "none", "follow", "forward", "curve", "looking",
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
            enemy.patterns = Resize<Pattern>(new List<Pattern>(enemy.patterns), nbPattern).ToArray();
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
                    matrixBullet(enemy.patterns[currentPattern]);
                    break;
                case "laser":
                    laserBullet(enemy.patterns[currentPattern]);
                    break;
                case "spiral":
                    break;
                case "solo":
                    break;
                case "circle":
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

    /*public Material bulletMaterial;
    //public Color bulletColor;
    public GameObject particle;
    public float startSpeed = 2;
    public float RateOverTime = 2;*/
    void particleBullet(Pattern currentPattern)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Material");
        currentPattern.bulletMaterial = (Material)EditorGUILayout.ObjectField(currentPattern.bulletMaterial, typeof(Material), false);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Color");
        currentPattern.bulletColor = EditorGUILayout.ColorField(currentPattern.bulletColor);
        EditorGUILayout.EndHorizontal();
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
        if (currentPattern.motifMatrix == null)
        {
            Debug.Log("reset Matrix");
            currentPattern.motifMatrix = new Matrix<bool>(5, 5);
        }
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefab");
        currentPattern.Prefabs = (GameObject)EditorGUILayout.ObjectField(currentPattern.Prefabs, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Color");
        currentPattern.bulletColor = EditorGUILayout.ColorField(currentPattern.bulletColor);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Delay tir : ");
        currentPattern.delaysPattern = EditorGUILayout.FloatField(currentPattern.delaysPattern);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("X : ");
        newX = EditorGUILayout.IntField(currentPattern.motifMatrix.width);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Y : ");
        newY = EditorGUILayout.IntField(currentPattern.motifMatrix.height);
        EditorGUILayout.EndHorizontal();
        if (currentPattern.motifMatrix.width != newX || currentPattern.motifMatrix.height != newY || currentPattern.motifMatrix == null)
        {
            Debug.Log("reset Matrix size");
            currentPattern.motifMatrix = new Matrix<bool>(newX, newY);
        }
        for (xInc = 0; xInc < currentPattern.motifMatrix.width; xInc++)
        {
            EditorGUILayout.BeginHorizontal();
            for (yInc = 0; yInc < currentPattern.motifMatrix.height; yInc++)
            {
                currentPattern.motifMatrix.set(xInc, yInc, EditorGUILayout.Toggle("", currentPattern.motifMatrix.get(xInc, yInc), GUILayout.Width(10)));
            }
            EditorGUILayout.EndHorizontal();
        }

    }

}