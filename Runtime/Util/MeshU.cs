using System;
using UnityEditor;
using UnityEngine;

namespace WiseMonkeES.Util
{
    public static class MeshU
    {
        public static void CreateEmptyMeshArrays(int quadCount, out Vector3[] vertices, out Vector2[] uvs, out int[] triangles)
        {
            vertices = new Vector3[4 * quadCount];
            uvs = new Vector2[4 * quadCount];
            triangles = new int[6 * quadCount];
        }
        
        public static void AddToMeshArrays(Vector3[] vertices, Vector2[] uvs, int[] triangles, int index, Vector3 pos, float rot, Vector3 baseSize, Vector2 uv00, Vector2 uv11)
        {
            // Relocate vertices
            int vIndex = index * 4;
            int vIndex0 = vIndex;
            int vIndex1 = vIndex + 1;
            int vIndex2 = vIndex + 2;
            int vIndex3 = vIndex + 3;
            
            baseSize *= 0.5f;
            
            bool skewed = baseSize.x != baseSize.y;

            if (skewed)
            {
                vertices[vIndex0] = pos + Quaternion.Euler(0f, 0f, rot) * new Vector3(-baseSize.x, baseSize.y);
                vertices[vIndex1] = pos + Quaternion.Euler(0f, 0f, rot) * new Vector3(-baseSize.x, -baseSize.y);
                vertices[vIndex2] = pos + Quaternion.Euler(0f, 0f, rot) * new Vector3(baseSize.x, -baseSize.y);
                vertices[vIndex3] = pos + Quaternion.Euler(0f, 0f, rot) * baseSize;
            }
            else
            {
                vertices[vIndex0] = pos + Quaternion.Euler(0f, 0f, rot-270) * baseSize;
                vertices[vIndex1] = pos + Quaternion.Euler(0f, 0f, rot-180) * baseSize;
                vertices[vIndex2] = pos + Quaternion.Euler(0f, 0f, rot-90) * baseSize;
                vertices[vIndex3] = pos + Quaternion.Euler(0f, 0f, rot) * baseSize;
            }
            // Relocate UVs
            uvs[vIndex0] = new Vector2(uv00.x, uv11.y);
            uvs[vIndex1] = new Vector2(uv00.x, uv00.y);
            uvs[vIndex2] = new Vector2(uv11.x, uv00.y);
            uvs[vIndex3] = new Vector2(uv11.x, uv11.y);
            
            // Create triangles
            int tIndex = index * 6;
            triangles[tIndex + 0] = vIndex0;
            triangles[tIndex + 1] = vIndex3;
            triangles[tIndex + 2] = vIndex1;
            triangles[tIndex + 3] = vIndex1;
            triangles[tIndex + 4] = vIndex3;
            triangles[tIndex + 5] = vIndex2;
        }
        

        public static Mesh SpriteToMesh(Sprite sprite)
        {
            Mesh mesh = new Mesh();
            mesh.vertices = Array.ConvertAll(sprite.vertices, i => (Vector3)i);
            mesh.uv = sprite.uv;
            mesh.triangles = Array.ConvertAll(sprite.triangles, i => (int)i);

            return mesh;
        }


        public static void SetUVs(ref Vector2[] uvs, int index, Vector2 p2, Vector2 p3, Vector2 p4, Vector2 p5)
        {
            uvs[index] = p2;
            uvs[index + 1] = p3;
            uvs[index + 2] = p4;
            uvs[index + 3] = p5;
        }
        
        public static void SaveMesh(this Mesh mesh, string name)
        {
            AssetDatabase.CreateAsset(mesh, "Assets/" + name + ".asset");
        }
        
    }
}