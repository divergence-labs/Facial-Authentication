﻿#pragma checksum "C:\Cognitive-Samples-IntelligentKiosk\Kiosk\Views\VisionApiExplorer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0C7D8B1D387C015DC4C1464C96C40145"
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
    partial class VisionApiExplorer : 
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
            case 1: // Views\VisionApiExplorer.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).SizeChanged += this.OnPageSizeChanged;
                }
                break;
            case 2: // Views\VisionApiExplorer.xaml line 23
                {
                    this.commandBar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 3: // Views\VisionApiExplorer.xaml line 54
                {
                    this.landingMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Views\VisionApiExplorer.xaml line 91
                {
                    this.resultsDetails = (global::Windows.UI.Xaml.Controls.ScrollViewer)(target);
                }
                break;
            case 5: // Views\VisionApiExplorer.xaml line 93
                {
                    this.tagsGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 6: // Views\VisionApiExplorer.xaml line 111
                {
                    this.descriptionGridView = (global::Windows.UI.Xaml.Controls.GridView)(target);
                }
                break;
            case 7: // Views\VisionApiExplorer.xaml line 134
                {
                    this.celebritiesTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8: // Views\VisionApiExplorer.xaml line 136
                {
                    this.colorInfoListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 9: // Views\VisionApiExplorer.xaml line 187
                {
                    this.ocrTextBox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // Views\VisionApiExplorer.xaml line 190
                {
                    this.objectDetectionToggle = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                    ((global::Windows.UI.Xaml.Controls.ToggleSwitch)this.objectDetectionToggle).Toggled += this.OnObjectDetectionToggled;
                }
                break;
            case 11: // Views\VisionApiExplorer.xaml line 179
                {
                    this.ocrToggle = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                    ((global::Windows.UI.Xaml.Controls.ToggleSwitch)this.ocrToggle).Toggled += this.OnOCRToggled;
                }
                break;
            case 12: // Views\VisionApiExplorer.xaml line 180
                {
                    global::Windows.UI.Xaml.Controls.ComboBox element12 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)element12).SelectionChanged += this.OcrModeSelectionChanged;
                }
                break;
            case 13: // Views\VisionApiExplorer.xaml line 183
                {
                    this.printedOCRComboBoxItem = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 14: // Views\VisionApiExplorer.xaml line 184
                {
                    this.handwrittigOCRComboBoxItem = (global::Windows.UI.Xaml.Controls.ComboBoxItem)(target);
                }
                break;
            case 19: // Views\VisionApiExplorer.xaml line 70
                {
                    this.webCamHostGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 20: // Views\VisionApiExplorer.xaml line 82
                {
                    this.imageWithFacesControl = (global::IntelligentKioskSample.Controls.ImageWithFaceBorderUserControl)(target);
                }
                break;
            case 21: // Views\VisionApiExplorer.xaml line 71
                {
                    this.imageFromCameraWithFaces = (global::IntelligentKioskSample.Controls.ImageWithFaceBorderUserControl)(target);
                }
                break;
            case 22: // Views\VisionApiExplorer.xaml line 79
                {
                    this.cameraControl = (global::IntelligentKioskSample.Controls.CameraControl)(target);
                }
                break;
            case 23: // Views\VisionApiExplorer.xaml line 39
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element23 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element23).Click += this.OnWebCamButtonClicked;
                }
                break;
            case 24: // Views\VisionApiExplorer.xaml line 41
                {
                    this.PicturesAppBarButton = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 25: // Views\VisionApiExplorer.xaml line 43
                {
                    this.imageSearchFlyout = (global::Windows.UI.Xaml.Controls.Flyout)(target);
                }
                break;
            case 26: // Views\VisionApiExplorer.xaml line 44
                {
                    global::IntelligentKioskSample.Controls.ImageSearchUserControl element26 = (global::IntelligentKioskSample.Controls.ImageSearchUserControl)(target);
                    ((global::IntelligentKioskSample.Controls.ImageSearchUserControl)element26).OnImageSearchCompleted += this.OnImageSearchCompleted;
                    ((global::IntelligentKioskSample.Controls.ImageSearchUserControl)element26).OnImageSearchCanceled += this.OnImageSearchCanceled;
                }
                break;
            case 27: // Views\VisionApiExplorer.xaml line 27
                {
                    this.favoriteImagePickerFlyout = (global::Windows.UI.Xaml.Controls.Flyout)(target);
                }
                break;
            case 28: // Views\VisionApiExplorer.xaml line 28
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

