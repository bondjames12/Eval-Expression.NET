﻿// Description: C# Expression Evaluator | Evaluate, Compile and Execute C# code and expression at runtime.
// Website: http://eval-expression.net/
// Documentation: https://github.com/zzzprojects/Eval-Expression.NET/wiki
// Forum & Issues: https://github.com/zzzprojects/Eval-Expression.NET/issues
// License: https://github.com/zzzprojects/Eval-Expression.NET/blob/master/LICENSE
// More projects: http://www.zzzprojects.com/
// Copyright © ZZZ Projects Inc. 2014 - 2016. All rights reserved.

using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Z.Expressions
{
    public partial class EvalContext
    {
        public EvalContext RegisterMember(params Type[] types)
        {
            foreach (var type in types)
            {
                var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                var fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                RegisterMember(constructors);
                RegisterMember(fields);
                RegisterMember(methods);
                RegisterMember(properties);
            }

            return this;
        }

        /// <summary>Registers specified static members.</summary>
        /// <param name="members">A variable-length parameters list containing members to register.</param>
        /// <returns>An Fluent EvalContext.</returns>
        public EvalContext RegisterMember(params MemberInfo[] members)
        {
            foreach (var member in members)
            {
                AliasMembers.AddOrUpdate(member.Name, s =>
                {
                    var dict = new ConcurrentDictionary<MemberInfo, byte>();
                    dict.TryAdd(member, 1);
                    return dict;
                }, (s, list) =>
                {
                    list.TryAdd(member, 1);
                    return list;
                });
            }

            return this;
        }
    }
}