using System;
using System.Collections.Generic;
using OneButton.Common;
using UnityEngine;

namespace OneButton.InGame
{
    public static class CustomExtension
    {
        public static List<Vector3> ToVector3List(this MoveType type)
        {
            return type switch
            {
                MoveType.Up => new List<Vector3> { Vector3.up },
                MoveType.Down => new List<Vector3> { Vector3.down },
                MoveType.Left => new List<Vector3> { Vector3.left },
                MoveType.Right => new List<Vector3> { Vector3.right },
                MoveType.DoubleUp => new List<Vector3> { Vector3.up, Vector3.up },
                MoveType.DoubleDown => new List<Vector3> { Vector3.down, Vector3.down },
                MoveType.DoubleLeft => new List<Vector3> { Vector3.left, Vector3.left },
                MoveType.DoubleRight => new List<Vector3> { Vector3.right, Vector3.right },
                _ => throw new Exception(ExceptionConfig.NOT_FOUND_MOVE_TYPE),
            };
        }
    }
}