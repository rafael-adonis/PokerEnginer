﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rafael.Util
{
    public class EnumUtil
    {
        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
