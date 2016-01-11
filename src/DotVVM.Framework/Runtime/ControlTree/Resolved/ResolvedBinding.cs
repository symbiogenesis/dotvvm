﻿using System;
using System.Diagnostics;
using System.Linq.Expressions;
using DotVVM.Framework.Exceptions;
using DotVVM.Framework.Parser.Dothtml.Parser;
using DotVVM.Framework.Runtime.Compilation;

namespace DotVVM.Framework.Runtime.ControlTree.Resolved
{
    [DebuggerDisplay("{Type.Name}: {Value}")]
    public class ResolvedBinding : IAbstractBinding
    {
        public DothtmlBindingNode BindingNode { get; set; }
        public Type BindingType { get; set; }
        public string Value { get; set; }
        public Expression Expression { get; set; }
        public DataContextStack DataContextTypeStack { get; set; }
        public Exception ParsingError { get; set; }

        public Expression GetExpression()
        {
            if (ParsingError != null)
            {
                throw new DotvvmCompilationException($"The binding '{{{ BindingType.Name }: { Value }}}' is not valid!", ParsingError, BindingNode.Tokens);
            }
            return Expression;
        }


        IDataContextStack IAbstractBinding.DataContextTypeStack => DataContextTypeStack;
        public ITypeDescriptor ResultType { get; set; }
    }
}
