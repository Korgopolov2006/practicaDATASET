﻿#pragma checksum "..\..\toysss.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "303E3987A7AEDB37410A4F20FE60837AE8E8B488BEE25D2E892E02E85BE216C3"
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
    /// toysss
    /// </summary>
    public partial class toysss : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\toysss.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataGrid1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\toysss.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox1;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\toysss.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBox1;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\toysss.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox2;
        
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
            System.Uri resourceLocater = new System.Uri("/PRACTA;component/toysss.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\toysss.xaml"
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
            
            #line 12 "..\..\toysss.xaml"
            this.DataGrid1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataGrid1_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 12 "..\..\toysss.xaml"
            this.DataGrid1.Loaded += new System.Windows.RoutedEventHandler(this.DataGrid1_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TextBox1 = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\toysss.xaml"
            this.TextBox1.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox1_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ComboBox1 = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\toysss.xaml"
            this.ComboBox1.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ComboBox1_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 19 "..\..\toysss.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Add);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 20 "..\..\toysss.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Delete);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 21 "..\..\toysss.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Chose);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TextBox2 = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\toysss.xaml"
            this.TextBox2.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox2_TextChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
