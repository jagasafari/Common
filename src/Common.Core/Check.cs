namespace Common.Core
{
    using System;

    public static class Check
    {
        public static T NotNull< T >( T value )
        {
            if(ReferenceEquals( value, null )) throw new NullReferenceException($"Obejct of type {typeof(T)} was null");
            return value;
        }
    }
}
