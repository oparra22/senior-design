﻿#pragma checksum "..\..\ManualPinTest.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A16D8879F9713F34B860234F26347E40"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GCITester;
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


namespace GCITester {
    
    
    /// <summary>
    /// ManualPinTest
    /// </summary>
    public partial class ManualPinTest : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backButton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label pinToTestLab;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pinNumberTextBox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button testPinButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button openPortBtn;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView manualTestPinResults;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label comLabel;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label baudLabel;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label stopBitsLabel;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label parityLabel;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ManualPinTest.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label dataBitsLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/GCITester;component/manualpintest.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ManualPinTest.xaml"
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
            
            #line 8 "..\..\ManualPinTest.xaml"
            ((GCITester.ManualPinTest)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.OnWindowClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.backButton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\ManualPinTest.xaml"
            this.backButton.Click += new System.Windows.RoutedEventHandler(this.backButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.pinToTestLab = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.pinNumberTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\ManualPinTest.xaml"
            this.pinNumberTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.textBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.testPinButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ManualPinTest.xaml"
            this.testPinButton.Click += new System.Windows.RoutedEventHandler(this.testPinButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.openPortBtn = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\ManualPinTest.xaml"
            this.openPortBtn.Click += new System.Windows.RoutedEventHandler(this.openPortBtn_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.manualTestPinResults = ((System.Windows.Controls.ListView)(target));
            
            #line 15 "..\..\ManualPinTest.xaml"
            this.manualTestPinResults.Loaded += new System.Windows.RoutedEventHandler(this.frmManualTest_Load);
            
            #line default
            #line hidden
            return;
            case 8:
            this.comLabel = ((System.Windows.Controls.Label)(target));
            
            #line 22 "..\..\ManualPinTest.xaml"
            this.comLabel.Loaded += new System.Windows.RoutedEventHandler(this.testPinLoad);
            
            #line default
            #line hidden
            return;
            case 9:
            this.baudLabel = ((System.Windows.Controls.Label)(target));
            
            #line 23 "..\..\ManualPinTest.xaml"
            this.baudLabel.Loaded += new System.Windows.RoutedEventHandler(this.testPinLoad);
            
            #line default
            #line hidden
            return;
            case 10:
            this.stopBitsLabel = ((System.Windows.Controls.Label)(target));
            
            #line 24 "..\..\ManualPinTest.xaml"
            this.stopBitsLabel.Loaded += new System.Windows.RoutedEventHandler(this.testPinLoad);
            
            #line default
            #line hidden
            return;
            case 11:
            this.parityLabel = ((System.Windows.Controls.Label)(target));
            
            #line 25 "..\..\ManualPinTest.xaml"
            this.parityLabel.Loaded += new System.Windows.RoutedEventHandler(this.testPinLoad);
            
            #line default
            #line hidden
            return;
            case 12:
            this.dataBitsLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

