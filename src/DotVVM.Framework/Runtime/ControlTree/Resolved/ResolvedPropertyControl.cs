﻿using DotVVM.Framework.Binding;

namespace DotVVM.Framework.Runtime.ControlTree.Resolved
{
    public class ResolvedPropertyControl : ResolvedPropertySetter, IAbstractPropertyControl
    {
        public ResolvedControl Control { get; set; }

        IAbstractControl IAbstractPropertyControl.Control => Control;

        public ResolvedPropertyControl(DotvvmProperty property, ResolvedControl control) : base(property)
        {
            Control = control;
            control.Parent = this;
        }

        public override void Accept(IResolvedControlTreeVisitor visitor)
        {
            visitor.VisitPropertyControl(this);
        }

        public override void AcceptChildren(IResolvedControlTreeVisitor visitor)
        {
            Control?.Accept(visitor);
        }
    }
}
