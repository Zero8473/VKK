﻿#pragma checksum "..\..\..\GUI\WelcomePage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3DA9D2CF1951827C04F54A76A3B424E6C0049AC01C6DA5D78B4E967C7EF641BC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using VKK.GUI;


namespace VKK.GUI {
    
    
    /// <summary>
    /// WelcomePage
    /// </summary>
    public partial class WelcomePage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\GUI\WelcomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_Search;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\GUI\WelcomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Lbl_Welcome;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\GUI\WelcomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_New;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\GUI\WelcomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Browse;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\GUI\WelcomePage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_Go;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/VKK;component/gui/welcomepage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\WelcomePage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Txt_Search = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Lbl_Welcome = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Btn_New = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\GUI\WelcomePage.xaml"
            this.Btn_New.Click += new System.Windows.RoutedEventHandler(this.Btn_New_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Btn_Browse = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\GUI\WelcomePage.xaml"
            this.Btn_Browse.Click += new System.Windows.RoutedEventHandler(this.Btn_Browse_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Btn_Go = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\GUI\WelcomePage.xaml"
            this.Btn_Go.Click += new System.Windows.RoutedEventHandler(this.Btn_Go_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
