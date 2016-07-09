﻿using System.Collections.Generic;
using DotVVM.Framework.Compilation.Parser.Dothtml.Parser;

namespace DotVVM.Framework.Compilation.ControlTree
{
    public interface IAbstractContentNode : IAbstractTreeNode
    {

        DothtmlNode DothtmlNode { get; }
        IEnumerable<IAbstractControl> Content { get; }
        IControlResolverMetadata Metadata { get; }
        IDataContextStack DataContextTypeStack { get; set; }
	}
}