using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAffectionObserver 
{
   void OnAffectionChanged(int newAffectionPoints);
}