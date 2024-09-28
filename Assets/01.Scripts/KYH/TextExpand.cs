using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Flags]
public enum TextStyle
{
    None = 0,
    FadeIn = 1 << 0,
    Moving = 1 << 1,
    UI = 1 << 2
}

public static class TextExpand
{


    public static bool HasStyle(this TextStyle style, TextStyle checkingStyle)
        => (style & checkingStyle) > 0;


    public static void TextUpDownMove(this TMP_Text text, float time, Color color, float fadeoutTime = 2.5f, TextStyle textStyle = default)
    {
        text.StartCoroutine(TextUpDownMoveRoutine(text, time, color, fadeoutTime, textStyle));
        //TextUpDownMove(parameter, isStart);
    }

    private static IEnumerator TextUpDownMoveRoutine(TMP_Text text, float time, Color color, float fadeoutTime, TextStyle textStyle)
    {
        Vector3[] startVertices;
        Vector3[] vertices;
        var oneFrameWait = new WaitForEndOfFrame();

        float currTime = time;
        while (currTime > 0)
        {
            text.ForceMeshUpdate();
            Mesh mesh = text.mesh;
            vertices = mesh.vertices;
            Color[] colors = mesh.colors;


            for (int i = 0; i < vertices.Length; ++i)
            {
                if (textStyle.HasStyle(TextStyle.Moving))
                {
                    float amount = textStyle.HasStyle(TextStyle.UI) ? 5f : 0.5f;

                    vertices[i] += Mathf.Sin(Time.time * 5 + (i / 4) * 2) * amount * Vector3.up;
                }

                if (textStyle.HasStyle(TextStyle.FadeIn))
                {
                    if (1 - (currTime / time) >= ((i / 2) / (float)(vertices.Length / 2)))
                        colors[i] = color;
                    else
                        colors[i] = Color.clear;
                }

            }

            mesh.SetVertices(vertices);
            mesh.SetColors(colors);

            if (textStyle.HasStyle(TextStyle.UI))
                text.canvasRenderer.SetMesh(mesh);

            currTime -= Time.deltaTime;
            yield return oneFrameWait;
        }


        startVertices = text.mesh.vertices.Clone() as Vector3[];
        text.ForceMeshUpdate();
        vertices = text.mesh.vertices.Clone() as Vector3[];

        float currFadeoutTime = fadeoutTime;

        while (currFadeoutTime > 0)
        {
            Mesh mesh = text.mesh;
            Color[] colors = mesh.colors;


            for (int i = 0; i < startVertices.Length; ++i)
            {
                startVertices[i] = Vector3.Lerp(startVertices[i], vertices[i]
                    , t: 1 - (currFadeoutTime / fadeoutTime));
            }

            mesh.SetVertices(startVertices);
            mesh.SetColors(colors);


            if (textStyle.HasStyle(TextStyle.UI))
                text.canvasRenderer.SetMesh(mesh);

            currFadeoutTime -= Time.deltaTime;
            yield return oneFrameWait;
        }
    }
}
