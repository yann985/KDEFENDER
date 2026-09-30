using System;
using UnityEngine;

[Serializable]
public abstract class ShapeSearcher
{
    public abstract bool TryGetAllOfTypesInShape<TType>(Vector3 startPoint, float range, out TType[] objects);
}
