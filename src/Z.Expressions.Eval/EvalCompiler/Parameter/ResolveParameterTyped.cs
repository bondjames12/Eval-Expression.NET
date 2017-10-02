﻿// Description: C# Expression Evaluator | Evaluate, Compile and Execute C# code and expression at runtime.
// Website: http://eval-expression.net/
// Documentation: https://github.com/zzzprojects/Eval-Expression.NET/wiki
// Forum & Issues: https://github.com/zzzprojects/Eval-Expression.NET/issues
// License: https://github.com/zzzprojects/Eval-Expression.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Z.Expressions.CodeCompiler.CSharp;

namespace Z.Expressions
{
    internal static partial class EvalCompiler
    {
        /// <summary>Resolve typed parameters used for the code or expression.</summary>
        /// <param name="scope">The expression scope for the code or expression to compile.</param>
        /// <param name="parameterTypes">The dictionary of parameter (name / type) used in the code or expression to compile.</param>
        /// <returns>A ParameterExpression list used in code or expression to compile.</returns>
        private static List<ParameterExpression> ResolveParameterTyped(ExpressionScope scope, IDictionary<string, Type> parameterTypes)
        {
            var parameters = new List<ParameterExpression>();

            foreach (var parameter in parameterTypes)
            {
                parameters.Add(scope.CreateParameter(parameter.Value, parameter.Key));
            }

            if (parameterTypes.Count == 1)
            {
                var keyValue = parameterTypes.First();
                if (Type.GetTypeCode(keyValue.Value) == TypeCode.Object)
                {
                    ResolzeLazyMember(scope, parameterTypes, keyValue.Key, keyValue.Value);
                }
            }

            return parameters;
        }
    }
}