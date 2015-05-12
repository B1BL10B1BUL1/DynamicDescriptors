﻿namespace DynamicDescriptors.Tests
{
    using System;
    using System.ComponentModel;
    using NUnit.Framework;

    [TestFixture]
    internal sealed class DynamicPropertyDescriptorTests
    {
        [Test]
        public void Constructor_DescriptorIsNull_ThrowsArgumentNullException()
        {
            const string message = "descriptor should not be null.";
            Assert.That(() => new DynamicPropertyDescriptor(null),
                Throws.TypeOf<ArgumentNullException>()
                      .And.Message.Contains(message));
        }

        [Test]
        public void CanResetValue_ReturnsResultOfDescriptorCanResetValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            object component = new object();

            mockDescriptor.CanResetValueResult = true;
            Assert.That(dynamicDescriptor.CanResetValue(component), Is.True);
            Assert.That(mockDescriptor.CanResetValueComponent, Is.EqualTo(component));

            mockDescriptor.CanResetValueResult = false;
            Assert.That(dynamicDescriptor.CanResetValue(component), Is.False);
            Assert.That(mockDescriptor.CanResetValueComponent, Is.EqualTo(component));
        }

        [Test]
        public void ComponentType_ReturnsResultOfDescriptorComponentType()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            Type type = typeof(string);
            mockDescriptor.ComponentTypeResult = type;
            Assert.That(dynamicDescriptor.ComponentType, Is.EqualTo(type));
        }

        [Test]
        public void GetValue_ReturnsResultOfDescriptorGetValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            object component = new object();
            object result = new object();

            mockDescriptor.GetValueResult = result;
            Assert.That(dynamicDescriptor.GetValue(component), Is.EqualTo(result));
            Assert.That(mockDescriptor.GetValueComponent, Is.EqualTo(component));
        }

        [Test]
        public void PropertyType_ReturnsResultOfDescriptorPropertyType()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            Type type = typeof(string);
            mockDescriptor.PropertyTypeResult = type;
            Assert.That(dynamicDescriptor.PropertyType, Is.EqualTo(type));
        }

        [Test]
        public void ResetValue_CallsDescriptorResetValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            object component = new object();
            dynamicDescriptor.ResetValue(component);
            Assert.That(mockDescriptor.ResetValueComponent, Is.EqualTo(component));
            Assert.That(mockDescriptor.ResetValueCalled, Is.True);
        }

        [Test]
        public void SetValue_CallsDescriptorSetValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            object component = new object();
            object value = new object();
            dynamicDescriptor.SetValue(component, value);
            Assert.That(mockDescriptor.SetValueComponent, Is.EqualTo(component));
            Assert.That(mockDescriptor.SetValueValue, Is.EqualTo(value));
            Assert.That(mockDescriptor.SetValueCalled, Is.True);
        }

        [Test]
        public void ShouldSerializeValue_ReturnsResultOfDescriptorShouldSerializeValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            object component = new object();

            mockDescriptor.ShouldSerializeValueResult = true;
            Assert.That(dynamicDescriptor.ShouldSerializeValue(component), Is.True);
            Assert.That(mockDescriptor.ShouldSerializeValueComponent, Is.EqualTo(component));

            mockDescriptor.ShouldSerializeValueResult = false;
            Assert.That(dynamicDescriptor.ShouldSerializeValue(component), Is.False);
            Assert.That(mockDescriptor.ShouldSerializeValueComponent, Is.EqualTo(component));
        }

        [Test]
        public void Category_NoOverride_ReturnsDescriptorValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.CategoryResult = "Base";

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            Assert.That(dynamicDescriptor.Category, Is.EqualTo("Base"));
        }

        [Test]
        public void Category_Override_ReturnsOverrideValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.CategoryResult = "Base";

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);
            dynamicDescriptor.SetCategory("Override");

            Assert.That(dynamicDescriptor.Category, Is.EqualTo("Override"));
        }

        [Test]
        public void Converter_NoOverride_ReturnsDescriptorValue()
        {
            TypeConverter converter = new TypeConverter();

            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.ConverterResult = converter;

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            Assert.That(dynamicDescriptor.Converter, Is.EqualTo(converter));
        }

        [Test]
        public void Converter_Override_ReturnsOverrideValue()
        {
            TypeConverter converterBase = new TypeConverter();
            TypeConverter converterOverride = new TypeConverter();

            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.ConverterResult = converterBase;

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);
            dynamicDescriptor.SetConverter(converterOverride);

            Assert.That(dynamicDescriptor.Converter, Is.EqualTo(converterOverride));
        }

        [Test]
        public void Description_NoOverride_ReturnsDescriptorValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.DescriptionResult = "Base";

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            Assert.That(dynamicDescriptor.Description, Is.EqualTo("Base"));
        }

        [Test]
        public void Description_Override_ReturnsOverrideValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.DescriptionResult = "Base";

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);
            dynamicDescriptor.SetDescription("Override");

            Assert.That(dynamicDescriptor.Description, Is.EqualTo("Override"));
        }

        [Test]
        public void DisplayName_NoOverride_ReturnsDescriptorValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.DisplayNameResult = "Base";

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            Assert.That(dynamicDescriptor.DisplayName, Is.EqualTo("Base"));
        }

        [Test]
        public void DisplayName_Override_ReturnsOverrideValue()
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.DisplayNameResult = "Base";

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);
            dynamicDescriptor.SetDisplayName("Override");

            Assert.That(dynamicDescriptor.DisplayName, Is.EqualTo("Override"));
        }

        [TestCase(true), TestCase(false)]
        public void IsReadOnly_NoOverride_ReturnsDescriptorValue(bool value)
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.IsReadOnlyResult = value;

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            Assert.That(dynamicDescriptor.IsReadOnly, Is.EqualTo(value));
        }

        [TestCase(true, true), TestCase(true, false), TestCase(false, true), TestCase(false, false)]
        public void IsReadOnly_Override_ReturnsOverrideValue(bool descriptorValue, bool overrideValue)
        {
            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.IsReadOnlyResult = descriptorValue;

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);
            dynamicDescriptor.SetReadOnly(overrideValue);

            Assert.That(dynamicDescriptor.IsReadOnly, Is.EqualTo(overrideValue));
        }

        [Test]
        public void GetEditor_NoOverride_ReturnsDescriptorValue()
        {
            MockUITypeEditor baseEditor = new MockUITypeEditor();

            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.GetEditorResult = baseEditor;

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);

            Assert.That(dynamicDescriptor.GetEditor(typeof(MockUITypeEditor)), Is.EqualTo(baseEditor));
        }

        [Test]
        public void GetEditor_Override_ReturnsOverrideValue()
        {
            MockUITypeEditor baseEditor = new MockUITypeEditor();
            MockUITypeEditor overrideEditor = new MockUITypeEditor();

            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.GetEditorResult = baseEditor;

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);
            dynamicDescriptor.SetEditor(typeof(MockUITypeEditor), overrideEditor);

            Assert.That(dynamicDescriptor.GetEditor(typeof(MockUITypeEditor)), Is.EqualTo(overrideEditor));
        }

        [Test]
        public void GetEditor_OverrideThenClear_ReturnsDescriptorValue()
        {
            MockUITypeEditor baseEditor = new MockUITypeEditor();
            MockUITypeEditor overrideEditor = new MockUITypeEditor();

            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.GetEditorResult = baseEditor;

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);
            dynamicDescriptor.SetEditor(typeof(MockUITypeEditor), overrideEditor);
            dynamicDescriptor.SetEditor(typeof(MockUITypeEditor), null);

            Assert.That(dynamicDescriptor.GetEditor(typeof(MockUITypeEditor)), Is.EqualTo(baseEditor));
        }

        [Test]
        public void GetEditor_MultipleOverrides_ReturnsMostRecentOverrideValue()
        {
            MockUITypeEditor baseEditor = new MockUITypeEditor();
            MockUITypeEditor overrideEditor1 = new MockUITypeEditor();
            MockUITypeEditor overrideEditor2 = new MockUITypeEditor();

            MockPropertyDescriptor mockDescriptor = new MockPropertyDescriptor();
            mockDescriptor.GetEditorResult = baseEditor;

            DynamicPropertyDescriptor dynamicDescriptor = new DynamicPropertyDescriptor(mockDescriptor);
            dynamicDescriptor.SetEditor(typeof(MockUITypeEditor), overrideEditor1);
            dynamicDescriptor.SetEditor(typeof(MockUITypeEditor), overrideEditor2);

            Assert.That(dynamicDescriptor.GetEditor(typeof(MockUITypeEditor)), Is.EqualTo(overrideEditor2));
        }
    }
}