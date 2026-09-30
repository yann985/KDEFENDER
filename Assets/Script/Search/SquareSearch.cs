using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SquareSearch : ShapeSearcher
{
    public override bool TryGetAllOfTypesInShape<TType>(Vector3 startPoint, float range, out TType[] objects)
    {
        var colliders = new List<Collider2D>();
        Physics2D.OverlapBox(startPoint, Vector2.one * (range * 2f), 0f, new ContactFilter2D().NoFilter(), colliders);

        var results = new List<TType>();
        foreach (var col in colliders)
            if (col.TryGetComponent(out TType found))
                results.Add(found);

        objects = results.ToArray();
        return objects.Length > 0;
    }
}
