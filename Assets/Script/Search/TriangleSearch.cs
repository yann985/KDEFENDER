using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TriangleSearch : ShapeSearcher
{
    public override bool TryGetAllOfTypesInShape<TType>(Vector3 startPoint, float range, out TType[] objects)
    {
        Vector2 a = (Vector2)startPoint + new Vector2(0f, range);
        Vector2 b = (Vector2)startPoint + new Vector2(-0.866f * range, -0.5f * range);
        Vector2 c = (Vector2)startPoint + new Vector2(0.866f * range, -0.5f * range);

        var colliders = new List<Collider2D>();
        Physics2D.OverlapCircle(startPoint, range, new ContactFilter2D().NoFilter(), colliders);

        var results = new List<TType>();
        foreach (var col in colliders)
        {
            Vector2 p = col.transform.position;
            float d1 = (p.x - b.x) * (a.y - b.y) - (a.x - b.x) * (p.y - b.y);
            float d2 = (p.x - c.x) * (b.y - c.y) - (b.x - c.x) * (p.y - c.y);
            float d3 = (p.x - a.x) * (c.y - a.y) - (c.x - a.x) * (p.y - a.y);
            bool inside = !((d1 < 0 || d2 < 0 || d3 < 0) && (d1 > 0 || d2 > 0 || d3 > 0));

            if (inside && col.TryGetComponent(out TType found))
                results.Add(found);
        }

        objects = results.ToArray();
        return objects.Length > 0;
    }
}
