﻿#pragma checksum "..\..\animals.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "85FB10AB8DE48D4168BB0DE256BC40FAE9D5622E58219AD54BDCF656AF602854"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using PRACTA;
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


namespace PRACTA {
    
    
    /// <summary>
    /// animals
    /// </summary>
    public partial class animals : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\animals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\animals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox1;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\animals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox2;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\animals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox3;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\animals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox2;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\animals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox1;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\animals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox6;
        
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
            System.Uri resourceLocater = new System.Uri("/PRACTA;component/animals.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\animals.xaml"
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
            this.DataGrid1 = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\animals.xaml"
            this.DataGrid1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid1_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 12 "..\..\animals.xaml"
            this.DataGrid1.Loaded += new System.Windows.RoutedEventHandler(this.DataGrid1_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBox1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBox2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TextBox3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ComboBox2 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 16 "..\..\animals.xaml"
            this.ComboBox2.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox2_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ComboBox1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\animals.xaml"
            this.ComboBox1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBox6 = ((System.Windows.Controls.TextBox)(target));
            
            #line 19 "..\..\animals.xaml"
            this.TextBox6.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox6_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 20 "..\..\animals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Search);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 21 "..\..\animals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cleaning);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 22 "..\..\animals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 23 "..\..\animals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 24 "..\..\animals.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Chose);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

