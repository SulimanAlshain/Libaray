// Updated by XamlIntelliSenseFileGenerator 11/11/2023 12:53:02 PM
#pragma checksum "..\..\..\..\Car\FrmCar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "34801BA6DAEEE0BFE1CFA62BA1E873F9EA0CC6BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PresentationLayer.Car;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PresentationLayer.Car
{


    /// <summary>
    /// FrmCar
    /// </summary>
    public partial class FrmCar : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PresentationLayer;V1.0.0.0;component/car/frmcar.xaml", System.UriKind.Relative);

#line 1 "..\..\..\..\Car\FrmCar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.Label lblTitle;
        internal System.Windows.Controls.Label lblName;
        internal System.Windows.Controls.Label lblAuthor;
        internal System.Windows.Controls.Label lblType;
        internal System.Windows.Controls.Label lblPublisher;
        internal System.Windows.Controls.TextBox txtBookName;
        internal System.Windows.Controls.ComboBox cbAuthorName;
        internal System.Windows.Controls.ComboBox cbBookType;
        internal System.Windows.Controls.ComboBox cbPublisherName;
    }
}

