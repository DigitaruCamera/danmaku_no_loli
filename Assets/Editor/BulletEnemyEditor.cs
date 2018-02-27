using UnityEditor;
using UnityEngine;
using typeSpawnBullet;
using patternClass;
using System.Collections.Generic;

[CustomEditor(typeof(BulletEnemy))]
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
            "none", "matrix", "laser", "spiral", "unique"
        };
    string[] optionBullet = new string[]
        {
            "none", "follow", "forward", "curve",
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
            EditorGUILayout.LabelField("===========================");
            enemy.patterns[currentPattern].typeSpawnBullet = EditorGUILayout.Popup("Type spawn bullet", enemy.patterns[currentPattern].typeSpawnBullet, optionSpawnBullet);
            enemy.patterns[currentPattern].typeBullet = EditorGUILayout.Popup("Type bullet", enemy.patterns[currentPattern].typeBullet, optionBullet);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("durrée du Partern : ");
            enemy.patterns[currentPattern].delaysPartern = EditorGUILayout.FloatField(enemy.patterns[currentPattern].delaysPartern);
            EditorGUILayout.EndHorizontal();
            switch (optionSpawnBullet[enemy.patterns[currentPattern].typeSpawnBullet])
            {
                case "matrix":
                    matrixBullet(enemy.patterns[currentPattern]);
                    break;
                case "laser":
                    break;
                case "spiral":
                    break;
                case "unique":
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

    void matrixBullet(Pattern currentPattern)
    {
        int newX;
        int newY;
        int xInc;
        int yInc;
        currentPattern.bulletSprite = (Sprite)EditorGUILayout.ObjectField("Sprite", currentPattern.bulletSprite, typeof(Sprite), false);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Color");
        currentPattern.bulletColor = EditorGUILayout.ColorField(currentPattern.bulletColor);
        EditorGUILayout.EndHorizontal();
        if (currentPattern.motifMatrix == null)
            currentPattern.motifMatrix = new matrixSpawnBullet();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Delay tir : ");
        currentPattern.motifMatrix.delayTir = EditorGUILayout.FloatField(currentPattern.motifMatrix.delayTir);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("X : ");
        newX = EditorGUILayout.IntField(currentPattern.motifMatrix.x);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Y : ");
        newY = EditorGUILayout.IntField(currentPattern.motifMatrix.y);
        EditorGUILayout.EndHorizontal();
        if (currentPattern.motifMatrix.x != newX || currentPattern.motifMatrix.y != newY || currentPattern.motifMatrix.matrix == null)
        {
            currentPattern.motifMatrix.x = newX;
            currentPattern.motifMatrix.y = newY;
            currentPattern.motifMatrix.matrix = new bool[newX, newY];
        }
        for (xInc = 0; xInc < currentPattern.motifMatrix.x; xInc++)
        {
            EditorGUILayout.BeginHorizontal();
            for (yInc = 0; yInc < currentPattern.motifMatrix.y; yInc++)
            {

                currentPattern.motifMatrix.matrix[xInc, yInc] = EditorGUILayout.Toggle("", currentPattern.motifMatrix.matrix[xInc, yInc], GUILayout.Width(10));
            }
            EditorGUILayout.EndHorizontal();
        }

    }

}using UnityEditor;
using UnityEngine;
using typeSpawnBullet;
using patternClass;
using System.Collections.Generic;

[CustomEditor(typeof(BulletEnemy))]
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
        } else if (list.Count > sz)
        {
            list.RemoveRange(sz, list.Count - sz);
        }
        return list;
    }

    string[] optionSpawnBullet = new string[]
        {
            "none", "matrix", "laser", "spiral", "unique"
        };
    string[] optionBullet = new string[]
        {
            "none", "follow", "forward", "curve",
        };
    public override void OnInspectorGUI()
    {
        int nbPattern = -1;
        int currentPattern;
        BulletEnemy enemy = (BulletEnemy)target;
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
            EditorGUILayout.LabelField("===========================");
            enemy.patterns[currentPattern].typeSpawnBullet = EditorGUILayout.Popup("Type spawn bullet", enemy.patterns[currentPattern].typeSpawnBullet, optionSpawnBullet);
            enemy.patterns[currentPattern].typeBullet = EditorGUILayout.Popup("Type bullet", enemy.patterns[currentPattern].typeBullet, optionBullet);
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("durrée du Partern : ");
            enemy.patterns[currentPattern].delaysPartern = EditorGUILayout.FloatField(enemy.patterns[currentPattern].delaysPartern);
            EditorGUILayout.EndHorizontal();
            switch (optionSpawnBullet[enemy.patterns[currentPattern].typeSpawnBullet])
            {
                case "matrix":
                    matrixBullet(enemy.patterns[currentPattern]);
                    break;
                case "laser":
                    break;
                case "spiral":
                    break;
                case "unique":
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

    void matrixBullet(Pattern currentPattern)
    {
        int newX;
        int newY;
        int xInc;
        int yInc;
        currentPattern.bulletSprite = (Sprite)EditorGUILayout.ObjectField("Sprite", currentPattern.bulletSprite, typeof(Sprite), false);
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Color");
        currentPattern.bulletColor = EditorGUILayout.ColorField(currentPattern.bulletColor);
        EditorGUILayout.EndHorizontal();
        if (currentPattern.motifMatrix == null)
            currentPattern.motifMatrix = new matrixSpawnBullet();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Delay tir : ");
        currentPattern.motifMatrix.delayTir = EditorGUILayout.FloatField(currentPattern.motifMatrix.delayTir);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("X : ");
        newX = EditorGUILayout.IntField(currentPattern.motifMatrix.x);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Y : ");
        newY = EditorGUILayout.IntField(currentPattern.motifMatrix.y);
        EditorGUILayout.EndHorizontal();
        if (currentPattern.motifMatrix.x != newX || currentPattern.motifMatrix.y != newY || currentPattern.motifMatrix.matrix == null)
        {
            currentPattern.motifMatrix.x = newX;
            currentPattern.motifMatrix.y = newY;
            currentPattern.motifMatrix.matrix = new bool[newX, newY];
        }
        for (xInc = 0; xInc < currentPattern.motifMatrix.x; xInc++)
        {
            EditorGUILayout.BeginHorizontal();
            for (yInc = 0; yInc < currentPattern.motifMatrix.y; yInc++)
            {

                currentPattern.motifMatrix.matrix[xInc, yInc] = EditorGUILayout.Toggle("", currentPattern.motifMatrix.matrix[xInc, yInc], GUILayout.Width(10));
            }
            EditorGUILayout.EndHorizontal();
        }

    }

}
