﻿#pragma checksum "..\..\..\..\..\Telas\Exercicio\U_TipoTreinoDados.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "908C98D1DFC52A04E89C7B802CC29ED6BFA25F7F"
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


namespace ControlWorks {
    
    
    /// <summary>
    /// U_TipoTreinoDados
    /// </summary>
    public partial class U_TipoTreinoDados : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\..\Telas\Exercicio\U_TipoTreinoDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbPesquisar;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\..\..\Telas\Exercicio\U_TipoTreinoDados.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridTipoTreino;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ControlWorks;V1.0.0.0;component/telas/exercicio/u_tipotreinodados.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Telas\Exercicio\U_TipoTreinoDados.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.12.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 6 "..\..\..\..\..\Telas\Exercicio\U_TipoTreinoDados.xaml"
            ((ControlWorks.U_TipoTreinoDados)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tbPesquisar = ((System.Windows.Controls.TextBox)(target));
            
            #line 10 "..\..\..\..\..\Telas\Exercicio\U_TipoTreinoDados.xaml"
            this.tbPesquisar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.tbPesquisar_TextChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dataGridTipoTreino = ((System.Windows.Controls.DataGrid)(target));
            
            #line 12 "..\..\..\..\..\Telas\Exercicio\U_TipoTreinoDados.xaml"
            this.dataGridTipoTreino.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.dataGridTipoTreino_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
