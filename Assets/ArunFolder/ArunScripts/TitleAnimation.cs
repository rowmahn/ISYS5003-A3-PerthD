using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TitleAnimation : MonoBehaviour
{
    public float waveSpeed = 2.0f;
    public float waveHeight = 0.5f;
    public float waveLength = 2.0f;

    private TMP_Text textMeshPro;

    void Start()
    {
        textMeshPro = GetComponent<TMP_Text>();
    }

    void Update()
    {
        textMeshPro.ForceMeshUpdate();
        var textInfo = textMeshPro.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];
            if (!charInfo.isVisible)
                continue;

            float offset = i * waveLength + Time.time * waveSpeed;
            float y = Mathf.Sin(offset) * waveHeight;

            int materialIndex = charInfo.materialReferenceIndex;
            int vertexIndex = charInfo.vertexIndex;

            Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                Vector3 origin = vertices[vertexIndex + j];
                vertices[vertexIndex + j] = origin + new Vector3(0, y, 0);
            }
        }

        // Update the mesh with the new vertex data
        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textMeshPro.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
