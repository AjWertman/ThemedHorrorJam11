using System;
using System.Collections.Generic;
using UnityEngine;

public enum PaperBagFaceKey { Default, Sad, Giddy, Indifferent}
public class PaperBagSwitcher : MonoBehaviour
{
    [SerializeField] PaperBagFace[] paperBagFaces = null;

    MeshRenderer faceRenderer = null;

    Dictionary<PaperBagFaceKey, Material> faceDict = new Dictionary<PaperBagFaceKey, Material>();

    private void Awake()
    {
        faceRenderer = GetComponent<MeshRenderer>();
    }


    public void SwitchFace(PaperBagFaceKey faceKey)
    {
        faceRenderer.material = faceDict[faceKey];
    }

    [Serializable]
    private struct PaperBagFace
    {
        public PaperBagFaceKey faceKey;
        public Material faceMaterial;
    }
}


