﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Reflection;

namespace Auth0.ManagementApi;

/// <summary>
/// Provider of generic extension methods.
/// </summary>
internal static class ExtensionMethods
{
    /// <summary>
    /// Adds a key and value to a dictionary provided the value
    /// is not <see langword="null"/> or empty.
    /// </summary>
    /// <param name="dictionary">Dictionary to add the key and value to.</param>
    /// <param name="key">Key of the item to add if <paramref name="value"/> is not <see langword="null"/> or empty.</param>
    /// <param name="value">Value of the item to add if it is not <see langword="null"/> or empty.</param>
    public static void AddIfNotEmpty(this IDictionary<string, string> dictionary, string key, string value)
    {
        if (!string.IsNullOrEmpty(value))
            dictionary.Add(key, value);
    }

    /// <summary>
    /// Get the <see cref="EnumMemberAttribute"/> value for a given <see cref="Enum"/> value.
    /// </summary>
    /// <typeparam name="T">Type of enum.</typeparam>
    /// <param name="value">Value of the enum.</param>
    /// <returns>Name of the enum derived from the <see cref="EnumMemberAttribute"/> value.</returns>
    public static string ToEnumString<T>(this T value) where T:struct, IConvertible
    {
        var enumType = typeof(T);
        var name = Enum.GetName(enumType, value);
        var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetTypeInfo().GetDeclaredField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true))[0];
        return enumMemberAttribute.Value;
    }

    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if the provided object is <see langword="null"/>.
    /// </summary>
    /// <param name="input">The object to check for <see langword="null"/>.</param>
    /// <param name="paramName">The name of the parameter being checked, automatically captured using <see cref="System.Runtime.CompilerServices.CallerArgumentExpressionAttribute"/>.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is <see langword="null"/>.</exception>
    public static void ThrowIfNull(this object input, [System.Runtime.CompilerServices.CallerArgumentExpression("input")] string? paramName = null)
    {
        if (input == null)
        {
            throw new ArgumentNullException(paramName);
        }
    }
}