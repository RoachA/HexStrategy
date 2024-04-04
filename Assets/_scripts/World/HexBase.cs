using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexBase
{
   public readonly int Q;
   public readonly int R;
   public readonly int S;

   static readonly float WIDTH_MULTIPLIER = Mathf.Sqrt(3) / 2;

   public HexBase(int q, int r)
   {
      this.Q = q;
      this.R = r;
      this.S = -(q + r);
   }
   
//return worldspace pos of this hex
   public Vector3 Position()
   {
      float radius = 1f;
      float height = radius * 2;
      float width = WIDTH_MULTIPLIER * height;

      float horizontal = width;
      float vertical = height * 0.75f;

      var pos = new Vector3(horizontal * (this.Q + this.R / 2f), 0, vertical * this.R);

      return pos;
   }
}
