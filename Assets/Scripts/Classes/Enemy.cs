﻿using Assets.Scripts.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Enemy : GameUnit
    {
        [Header("Enemy - Base")]
        public MovingObject Target;
        public float pushForce = 4f;
    }
}