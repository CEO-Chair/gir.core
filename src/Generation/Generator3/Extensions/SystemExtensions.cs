﻿using System;
using System.Collections.Generic;
using System.Linq;

internal static class SystemExtensions
{
    public static string ForEachCall<T>(this IEnumerable<T> list, Func<T, string> func)
        => string.Join(Environment.NewLine, list.Select(func));

    public static string? Render(this string? str)
    {
        if (string.IsNullOrEmpty(str))
            return string.Empty;

        return str + Environment.NewLine;
    }

    public static string Join(this IEnumerable<string> ie, string separator)
        => string.Join(separator, ie);
}
