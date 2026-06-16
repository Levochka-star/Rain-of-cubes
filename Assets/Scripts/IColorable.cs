using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IColorable
{
   public event Action ColorChangeRequested;
}
