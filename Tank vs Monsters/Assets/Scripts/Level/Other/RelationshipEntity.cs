using System;
using System.Collections.Generic;
using Level.Config;
using UnityEngine;

namespace Level.Other
{
    [Serializable]
    public class RelationshipEntity
    {
        [SerializeField] private List<EntityConfig> _friendlyEntities;

        public List<EntityConfig> FriendlyEntities => _friendlyEntities;
    }
}