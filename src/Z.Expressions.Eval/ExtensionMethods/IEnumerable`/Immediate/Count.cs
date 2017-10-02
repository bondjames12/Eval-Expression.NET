﻿// Description: C# Expression Evaluator | Evaluate, Compile and Execute C# code and expression at runtime.
// Website: http://eval-expression.net/
// Documentation: https://github.com/zzzprojects/Eval-Expression.NET/wiki
// Forum & Issues: https://github.com/zzzprojects/Eval-Expression.NET/issues
// License: https://github.com/zzzprojects/Eval-Expression.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Z.Expressions
{
    public static partial class Extensions
    {
        public static int Count<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource, string>> predicate)
        {
            return source.Count(predicate, null);
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Expression<Func<TSource, string>> predicate, object parameter)
        {
            return (int) EvalLinq.Execute("{1}.Count({expression});", predicate, parameter, source);
        }
    }
}