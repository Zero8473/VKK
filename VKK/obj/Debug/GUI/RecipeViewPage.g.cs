﻿#pragma checksum "..\..\..\GUI\RecipeViewPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "49A3A7A81E61F77C0744F9BF64B2A2E03F02B9B62A9B58DCA86B18328CAA28DA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
    /// RecipeViewPage
    /// </summary>
    public partial class RecipeViewPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\GUI\RecipeViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Lbl_RecipeTitle;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\GUI\RecipeViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_Ingredients;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\GUI\RecipeViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_Steps;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\GUI\RecipeViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Img_RecipePic;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\GUI\RecipeViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Btn_RecipeDelete;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\GUI\RecipeViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_CurrRecipe;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\GUI\RecipeViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Lbl_Servings;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\GUI\RecipeViewPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Txt_Servings;
        
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
            System.Uri resourceLocater = new System.Uri("/VKK;component/gui/recipeviewpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\GUI\RecipeViewPage.xaml"
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
            this.Lbl_RecipeTitle = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Txt_Ingredients = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Txt_Steps = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Img_RecipePic = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.Btn_RecipeDelete = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\GUI\RecipeViewPage.xaml"
            this.Btn_RecipeDelete.Click += new System.Windows.RoutedEventHandler(this.Btn_RecipeDelete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Txt_CurrRecipe = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.Lbl_Servings = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.Txt_Servings = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\GUI\RecipeViewPage.xaml"
            this.Txt_Servings.TextInput += new System.Windows.Input.TextCompositionEventHandler(this.Txt_Servings_TextInput);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

