﻿#pragma checksum "C:\Cognitive-Samples-IntelligentKiosk\Kiosk\Views\BingVisualSearch.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5CDC8A14DF1559CF2233A78114A6E53B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntelligentKioskSample.Views
{
    partial class BingVisualSearch : 
        global::Windows.UI.Xaml.Controls.Page, 
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
            case 1: // Views\BingVisualSearch.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).SizeChanged += this.OnPageSizeChanged;
                }
                break;
            case 5: // Views\BingVisualSearch.xaml line 80
                {
                    this.commandBar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 6: // Views\BingVisualSearch.xaml line 111
                {
                    this.landingMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // Views\BingVisualSearch.xaml line 145
                {
                    this.resultsDetails = (global::Windows.UI.Xaml.Controls.ScrollViewer)(target);
                }
                break;
            case 8: // Views\BingVisualSearch.xaml line 147
                {
                    this.resultsGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 9: // Views\BingVisualSearch.xaml line 148
                {
                    this.progressRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 10: // Views\BingVisualSearch.xaml line 149
                {
                    this.searchErrorTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // Views\BingVisualSearch.xaml line 138
                {
                    this.resultTypeComboBox = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.resultTypeComboBox).SelectionChanged += this.OnResultTypeSelectionChanged;
                }
                break;
            case 12: // Views\BingVisualSearch.xaml line 139
                {
                    this.celebrityResultType = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 13: // Views\BingVisualSearch.xaml line 140
                {
                    this.similarImagesResultType = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 14: // Views\BingVisualSearch.xaml line 141
                {
                    this.similarProductsResultType = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 15: // Views\BingVisualSearch.xaml line 127
                {
                    this.webCamHostGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 16: // Views\BingVisualSearch.xaml line 132
                {
                    this.imageWithFacesControl = (global::IntelligentKioskSample.Controls.ImageWithFaceBorderUserControl)(target);
                }
                break;
            case 17: // Views\BingVisualSearch.xaml line 128
                {
                    this.imageFromCameraWithFaces = (global::IntelligentKioskSample.Controls.ImageWithFaceBorderUserControl)(target);
                }
                break;
            case 18: // Views\BingVisualSearch.xaml line 129
                {
                    this.cameraControl = (global::IntelligentKioskSample.Controls.CameraControl)(target);
                }
                break;
            case 19: // Views\BingVisualSearch.xaml line 96
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element19 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element19).Click += this.OnWebCamButtonClicked;
                }
                break;
            case 20: // Views\BingVisualSearch.xaml line 98
                {
                    this.PicturesAppBarButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 21: // Views\BingVisualSearch.xaml line 100
                {
                    this.imageSearchFlyout = (global::Windows.UI.Xaml.Controls.Flyout)(target);
                }
                break;
            case 22: // Views\BingVisualSearch.xaml line 101
                {
                    global::IntelligentKioskSample.Controls.ImageSearchUserControl element22 = (global::IntelligentKioskSample.Controls.ImageSearchUserControl)(target);
                    ((global::IntelligentKioskSample.Controls.ImageSearchUserControl)element22).OnImageSearchCompleted += this.OnImageSearchCompleted;
                    ((global::IntelligentKioskSample.Controls.ImageSearchUserControl)element22).OnImageSearchCanceled += this.OnImageSearchCanceled;
                }
                break;
            case 23: // Views\BingVisualSearch.xaml line 84
                {
                    this.favoriteImagePickerFlyout = (global::Windows.UI.Xaml.Controls.Flyout)(target);
                }
                break;
            case 24: // Views\BingVisualSearch.xaml line 85
                {
                    this.favoritePhotosGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    ((global::Windows.UI.Xaml.Controls.GridView)this.favoritePhotosGridView).SelectionChanged += this.OnFavoriteSelectionChanged;
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

