﻿#pragma checksum "C:\Cognitive-Samples-IntelligentKiosk\Kiosk\Views\AutomaticPhotoCapturePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B63CD2C06BE77A7EDE0395D09AC59CB6"
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
    partial class AutomaticPhotoCapturePage : 
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
            case 1: // Views\AutomaticPhotoCapturePage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).SizeChanged += this.OnPageSizeChanged;
                }
                break;
            case 2: // Views\AutomaticPhotoCapturePage.xaml line 13
                {
                    this.MainGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // Views\AutomaticPhotoCapturePage.xaml line 77
                {
                    this.photoCaptureBalloonHost = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4: // Views\AutomaticPhotoCapturePage.xaml line 92
                {
                    this.resultDisplayTimerUI = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 5: // Views\AutomaticPhotoCapturePage.xaml line 38
                {
                    this.cameraHostGrid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6: // Views\AutomaticPhotoCapturePage.xaml line 43
                {
                    this.cameraGuideHost = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 7: // Views\AutomaticPhotoCapturePage.xaml line 45
                {
                    this.cameraGuideBallon = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 8: // Views\AutomaticPhotoCapturePage.xaml line 61
                {
                    this.cameraGuideCountdownHost = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 9: // Views\AutomaticPhotoCapturePage.xaml line 69
                {
                    this.countDownTextBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 10: // Views\AutomaticPhotoCapturePage.xaml line 57
                {
                    this.cameraGuideText = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // Views\AutomaticPhotoCapturePage.xaml line 39
                {
                    this.cameraControl = (global::IntelligentKioskSample.Controls.CameraControl)(target);
                }
                break;
            case 12: // Views\AutomaticPhotoCapturePage.xaml line 40
                {
                    this.imageFromCameraWithFaces = (global::IntelligentKioskSample.Controls.ImageWithFaceBorderUserControl)(target);
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

