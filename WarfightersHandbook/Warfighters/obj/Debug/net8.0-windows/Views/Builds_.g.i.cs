﻿#pragma checksum "..\..\..\..\Views\Builds_.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "50E07F49F0E6E050B9C37D5125CBE340C5DB5D17"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Warfighters.Views;


namespace Warfighters.Views {
    
    
    /// <summary>
    /// Builds
    /// </summary>
    public partial class Builds : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Views\Builds_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button charactersBT;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Views\Builds_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button weaponsBT;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Views\Builds_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button artefactsBT;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Views\Builds_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTB;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Views\Builds_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame contentFR;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Views\Builds_.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView itemsLV;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Warfighters;V1.0.0.0;component/views/builds_.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Builds_.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.charactersBT = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.weaponsBT = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\..\Views\Builds_.xaml"
            this.weaponsBT.Click += new System.Windows.RoutedEventHandler(this.weaponsBT_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.artefactsBT = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\Views\Builds_.xaml"
            this.artefactsBT.Click += new System.Windows.RoutedEventHandler(this.artefactsBT_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.searchTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.contentFR = ((System.Windows.Controls.Frame)(target));
            return;
            case 6:
            this.itemsLV = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

