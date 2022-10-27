﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.Domain.Others
{
    public class MapItem
    {
        public Type Type { get; private set; }

        public string PropertyName { get; private set; }

        public MapItem(Type type, string propertyName)
        {
            Type = type;
            PropertyName = propertyName;
        }
    }
}
