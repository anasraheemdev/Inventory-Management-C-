﻿#pragma checksum "..\..\..\StockTrackingWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "708E0712FB4BA124FDB24583A2FBF082EDF6D711"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using LiveCharts.Wpf;
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


namespace FinalDB {
    
    
    /// <summary>
    /// StockTrackingWindow
    /// </summary>
    public partial class StockTrackingWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 353 "..\..\..\StockTrackingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TotalItemsTextBlock;
        
        #line default
        #line hidden
        
        
        #line 374 "..\..\..\StockTrackingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ItemsInStockTextBlock;
        
        #line default
        #line hidden
        
        
        #line 395 "..\..\..\StockTrackingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LowStockItemsTextBlock;
        
        #line default
        #line hidden
        
        
        #line 416 "..\..\..\StockTrackingWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock OutOfStockItemsTextBlock;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FinalDB;component/stocktrackingwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\StockTrackingWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 158 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DashboardButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 166 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MakeInvoiceButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 172 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.TransactionButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 180 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddProductButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 186 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ProductsButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 192 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PurchaseRecordButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 198 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StockTrackingButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 208 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CategoryButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 214 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BrandButton_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 220 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UnitsButton_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 226 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SupplierButton_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 232 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.IssuedButton_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 238 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MasterPriceButton_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 248 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddCashierButton_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 254 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoginAsAdminButton_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 260 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoginPageButton_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 266 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HomeLoginAsButton_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            
            #line 273 "..\..\..\StockTrackingWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditProductButton_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.TotalItemsTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 20:
            this.ItemsInStockTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 21:
            this.LowStockItemsTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 22:
            this.OutOfStockItemsTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

