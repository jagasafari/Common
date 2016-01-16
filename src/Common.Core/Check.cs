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
        
        public static T NotNull< T >( T value, string nameOfArgument )
        {
            if(ReferenceEquals( value, null )) throw new NullReferenceException($"Obejct of type {typeof(T)}, with argument name {nameOfArgument} was null");
            return value;
        }
        
        public static string NotNullOrWhiteSpace(string value, string nameOfArgument){
            if(string.IsNullOrWhiteSpace(NotNull(value, nameOfArgument))) throw new ArgumentException($"string with argument name {nameOfArgument} was empty or white space");
            return value;
        }
        
        public static int NotNegative(int value, string nameOfArgument) {
            if(value<0)throw new ArgumentException($"integer with argument name {nameOfArgument} was negative");
            return value;
        }
    }
}
