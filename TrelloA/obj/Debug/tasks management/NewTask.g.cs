﻿#pragma checksum "..\..\..\tasks management\NewTask.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A1BA94B5F675996E6D7352BD8761B3FBF12E522C92D90E2CFFA3F3BBB8F9D4F2"
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
using TrelloA.tasks_management;


namespace TrelloA.tasks_management {
    
    
    /// <summary>
    /// NewTask
    /// </summary>
    public partial class NewTask : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\tasks management\NewTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox titleTB;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\tasks management\NewTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox descriptionTB;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\tasks management\NewTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton red;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\tasks management\NewTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton green;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\tasks management\NewTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton yellow;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\tasks management\NewTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton blue;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\tasks management\NewTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton notDone;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\tasks management\NewTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton done;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\tasks management\NewTask.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox creatorIdTB;
        
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
            System.Uri resourceLocater = new System.Uri("/TrelloA;component/tasks%20management/newtask.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\tasks management\NewTask.xaml"
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
            this.titleTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.descriptionTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.red = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.green = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.yellow = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.blue = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.notDone = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this.done = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this.creatorIdTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            
            #line 57 "..\..\..\tasks management\NewTask.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CreateTask_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

