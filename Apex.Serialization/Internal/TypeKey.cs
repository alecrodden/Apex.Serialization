﻿using System;
using System.Collections.Generic;

namespace Apex.Serialization.Internal
{
    internal struct TypeKey : IEquatable<TypeKey>
    {
        public Type Type;
        public ImmutableSettings Settings;

        public override bool Equals(object? obj) => obj is TypeKey && Equals((TypeKey)obj);
        public bool Equals(TypeKey other) => EqualityComparer<Type>.Default.Equals(Type, other.Type) && Settings.Equals(other.Settings);

        public override int GetHashCode()
        {
            var hashCode = -1649973959;
            hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(Type);
            hashCode = hashCode * -1521134295 + Settings.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(TypeKey key1, TypeKey key2) => key1.Equals(key2);
        public static bool operator !=(TypeKey key1, TypeKey key2) => !(key1 == key2);
    }
}
