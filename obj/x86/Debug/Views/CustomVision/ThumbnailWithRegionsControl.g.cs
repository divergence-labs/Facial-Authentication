﻿#pragma checksum "C:\Cognitive-Samples-IntelligentKiosk\Kiosk\Views\CustomVision\ThumbnailWithRegionsControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5BA865E37FAE4A918D056972BCD4BA11"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntelligentKioskSample.Views.CustomVision
{
    partial class ThumbnailWithRegionsControl : 
        global::Windows.UI.Xaml.Controls.UserControl, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // Views\CustomVision\ThumbnailWithRegionsControl.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.UserControl element1 = (global::Windows.UI.Xaml.Controls.UserControl)(target);
                    ((global::Windows.UI.Xaml.Controls.UserControl)element1).DataContextChanged += this.OnControlDataContextChanged;
                }
                break;
            case 2: // Views\CustomVision\ThumbnailWithRegionsControl.xaml line 15
                {
                    this.thumbnailImage = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)this.thumbnailImage).ImageOpened += this.OnTaggedThubnailImageOpened;
                }
                break;
            case 3: // Views\CustomVision\ThumbnailWithRegionsControl.xaml line 16
                {
                    this.imageRegionsCanvas = (global::Windows.UI.Xaml.Controls.Canvas)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
