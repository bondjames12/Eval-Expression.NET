﻿// Description: C# Expression Evaluator | Evaluate, Compile and Execute C# code and expression at runtime.
// Website: http://eval-expression.net/
// Documentation: https://github.com/zzzprojects/Eval-Expression.NET/wiki
// Forum & Issues: https://github.com/zzzprojects/Eval-Expression.NET/issues
// License: https://github.com/zzzprojects/Eval-Expression.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.


#if NET45
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Z.Expressions
{
    public static partial class Eval
    {
        /// <summary>Compile the code or expression and return a TDelegate of type Func or Action to execute.</summary>
        /// <typeparam name="TDelegate">Type of the delegate (Func or Action) to use to compile the code or expression.</typeparam>
        /// <param name="code">The code or expression to compile.</param>
        /// <returns>A TDelegate of type Func or Action that represents the compiled code or expression.</returns>
        public static Task<TDelegate> CompileAsync<TDelegate>(string code)
        {
            return EvalManager.DefaultContext.CompileAsync<TDelegate>(code);
        }

        /// <summary>Compile the code or expression and return a TDelegate of type Func or action to execute.</summary>
        /// <typeparam name="TDelegate">Type of the delegate (Func or Action) to use to compile the code or expression.</typeparam>
        /// <param name="code">The code or expression to compile.</param>
        /// <param name="parameterNames">Parameter names used to compile the code or expressions.</param>
        /// <returns>A TDelegate of type Func or Action that represents the compiled code or expression.</returns>
        public static Task<TDelegate> CompileAsync<TDelegate>(string code, IEnumerable<string> parameterNames)
        {
            return EvalManager.DefaultContext.CompileAsync<TDelegate>(code, parameterNames);
        }

        /// <summary>Compile the code or expression and return a TDelegate of type Func or Action to execute.</summary>
        /// <typeparam name="TDelegate">Type of the delegate (Func or Action) to use to compile the code or expression.</typeparam>
        /// <param name="code">The code or expression to compile.</param>
        /// <param name="parameterNames">Parameter names used to compile the code or expressions.</param>
        /// <returns>A TDelegate of type Func or Action that represents the compiled code or expression.</returns>
        public static Task<TDelegate> CompileAsync<TDelegate>(string code, params string[] parameterNames)
        {
            return EvalManager.DefaultContext.CompileAsync<TDelegate>(code, parameterNames);
        }
    }
}

#endif