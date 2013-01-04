﻿namespace DynamicDescriptors.Tests
{
    using System;
    using System.ComponentModel;

    internal sealed class MockPropertyDescriptor : PropertyDescriptor
    {
        public MockPropertyDescriptor()
            : base("MockProperty", new Attribute[] { }) { }

        public Type ComponentTypeResult { get; set; }
        public override Type ComponentType { get { return this.ComponentTypeResult; } }

        public bool IsReadOnlyResult { get; set; }
        public override bool IsReadOnly { get { return this.IsReadOnlyResult; } }

        public Type PropertyTypeResult { get; set; }
        public override Type PropertyType { get { return this.PropertyTypeResult; } }

        public object GetValueComponent { get; private set; }
        public object GetValueResult { get; set; }
        public bool GetValueCalled { get; private set; }
        public override object GetValue(object component)
        {
            this.GetValueCalled = true;
            this.GetValueComponent = component;
            return this.GetValueResult;
        }

        public object SetValueComponent { get; private set; }
        public object SetValueValue { get; private set; }
        public bool SetValueCalled { get; private set; }
        public override void SetValue(object component, object value)
        {
            this.SetValueCalled = true;
            this.SetValueComponent = component;
            this.SetValueValue = value;
        }

        public object ResetValueComponent { get; private set; }
        public bool ResetValueCalled { get; private set; }
        public override void ResetValue(object component)
        {
            this.ResetValueCalled = true;
            this.ResetValueComponent = component;
        }

        public object CanResetValueComponent { get; private set; }
        public bool CanResetValueResult { get; set; }
        public bool CanResetValueCalled { get; set; }
        public override bool CanResetValue(object component)
        {
            this.CanResetValueCalled = true;
            this.CanResetValueComponent = component;
            return this.CanResetValueResult;
        }

        public object ShouldSerializeValueComponent { get; private set; }
        public bool ShouldSerializeValueResult { get; set; }
        public bool ShouldSerializeValueCalled { get; set; }
        public override bool ShouldSerializeValue(object component)
        {
            this.ShouldSerializeValueCalled = true;
            this.ShouldSerializeValueComponent = component;
            return this.ShouldSerializeValueResult;
        }
    }
}