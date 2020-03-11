// 
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.
// 
// Microsoft Cognitive Services: http://www.microsoft.com/cognitive
// 
// Microsoft Cognitive Services Github:
// https://github.com/Microsoft/Cognitive
// 
// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// MIT License:
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using ServiceHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Core;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntelligentKioskSample.Views
{

    [KioskExperience(Title = "Greeting Kiosk", ImagePath = "ms-appx:/Assets/GreetingKiosk.jpg", ExperienceType = ExperienceType.Kiosk)]
    public sealed partial class GreetingKiosk : Page
    {
        private Task processingLoopTask;
        private bool isProcessingLoopInProgress;
        private bool isProcessingPhoto;
        private int authenticated = 2;
        private bool sentNotification = false;
        private int notificationCount = 0;
        private bool deletedRecords = false;

        public GreetingKiosk()
        {
            this.InitializeComponent();

            Window.Current.Activated += CurrentWindowActivationStateChanged;
            this.cameraControl.FilterOutSmallFaces = true;
            this.cameraControl.HideCameraControls();
            this.cameraControl.CameraAspectRatioChanged += CameraControl_CameraAspectRatioChanged;
            //this.Buttons.Visibility = Visibility.Collapsed;
            this.Details.Visibility = Visibility.Collapsed;
        }

        private void CameraControl_CameraAspectRatioChanged(object sender, EventArgs e)
        {
            this.UpdateCameraHostSize();
        }

        private void StartProcessingLoop()
        {
            this.isProcessingLoopInProgress = true;

            if (this.processingLoopTask == null || this.processingLoopTask.Status != TaskStatus.Running)
            {
                this.processingLoopTask = Task.Run(() => this.ProcessingLoop());
            }
        }


        private async void ProcessingLoop()
        {
            while (this.isProcessingLoopInProgress)
            {
                await this.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
                {
                    if (!this.isProcessingPhoto)
                    {
                        this.isProcessingPhoto = true;
                        if (this.cameraControl.NumFacesOnLastFrame == 0)
                        {
                            await this.ProcessCameraCapture(null);
                        }
                        else
                        {
                            await this.ProcessCameraCapture(await this.cameraControl.CaptureFrameAsync());
                        }
                    }
                });

                await Task.Delay(this.cameraControl.NumFacesOnLastFrame == 0 ? 100 : 1000);
            }
        }

        private async void CurrentWindowActivationStateChanged(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if ((e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.CodeActivated ||
                e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.PointerActivated) &&
                this.cameraControl.CameraStreamState == Windows.Media.Devices.CameraStreamState.Shutdown)
            {
                // When our Window loses focus due to user interaction Windows shuts it down, so we 
                // detect here when the window regains focus and trigger a restart of the camera.
                await this.cameraControl.StartStreamAsync(isForRealTimeProcessing: true);
            }
        }

        private async Task ProcessCameraCapture(ImageAnalyzer e)
        {
            if (e == null)
            {
                this.UpdateUIForNoFacesDetected();
                this.isProcessingPhoto = false;
                return;
            }

            DateTime start = DateTime.Now;

            await e.DetectFacesAsync();

            if (e.DetectedFaces.Any())
            {
                await e.IdentifyFacesAsync();
                this.greetingTextBlock.Text = this.GetGreettingFromFaces(e);

                if (e.IdentifiedPersons.Any())
                {
                    this.greetingTextBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.GreenYellow);
                    this.greetingSymbol.Foreground = new SolidColorBrush(Windows.UI.Colors.GreenYellow);
                    this.greetingSymbol.Symbol = Symbol.Comment;
                }
                else
                {
                    this.Details.Visibility = Visibility.Collapsed;
                    //this.Buttons.Visibility = Visibility.Collapsed;
                    this.greetingTextBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.Yellow);
                    this.greetingSymbol.Foreground = new SolidColorBrush(Windows.UI.Colors.Yellow);
                    this.greetingSymbol.Symbol = Symbol.View;
                }
            }
            else
            {
                this.UpdateUIForNoFacesDetected();
            }

            TimeSpan latency = DateTime.Now - start;
            this.faceLantencyDebugText.Text = string.Format("Face API latency: {0}ms", (int)latency.TotalMilliseconds);

            this.isProcessingPhoto = false;
        }

        private string GetGreettingFromFaces(ImageAnalyzer img)
        {
            if (img.IdentifiedPersons.Any())
            {
                string names = img.IdentifiedPersons.Count() > 1 ? string.Join(", ", img.IdentifiedPersons.Select(p => p.Person.Name)) : img.IdentifiedPersons.First().Person.Name;

                if (img.DetectedFaces.Count() > img.IdentifiedPersons.Count())
                {
                    this.Details.Visibility = Visibility.Collapsed;
                    //this.Buttons.Visibility = Visibility.Collapsed;
                    return string.Format("Welcome back, {0} and company! Please step one at a time to start!", names);
                }
                else
                {
                    if (img.IdentifiedPersons.Count() > 1)
                    {
                        this.Details.Visibility = Visibility.Collapsed;
                        //this.Buttons.Visibility = Visibility.Collapsed;
                        return string.Format(
                            "Welcome back, {0}! Please step one at a time in front of the camera to start!", names);
                    }

                    else
                    {
                        //Send a notification to the customer's phone
                        if (!sentNotification && notificationCount == 0)
                        {
                            this.Details.Visibility = Visibility.Collapsed;
                            //this.Buttons.Visibility = Visibility.Collapsed;
                            NotificationMethod();
                            notificationCount++;
                        }


                        if (sentNotification && authenticated == 2)
                        {
                            //Keep checking if the user is authenticated or not and assign authenticated value to the variable
                            this.Details.Visibility = Visibility.Collapsed;
                            //this.Buttons.Visibility = Visibility.Collapsed;
                            GetAuthStatus();

                            //authenticated=2 if not authenticated till now
                            //authenticated=1 if authentication was successful
                            //authenticated=0 if authentication was not successful

                            //If user is not authenticated, send this:
                            return string.Format(
                                "Welcome back {0}! I've sent a notification on your phone. Please confirm to proceed!",
                                names);
                        }

                        else if (authenticated == 1)
                        {
                            this.Details.Text = "Divergence Customer Collaboration Center.";
                            this.Details.Visibility = Visibility.Visible;
                            //this.Buttons.Visibility = Visibility.Visible;
                            return string.Format("Welcome back {0}!", names);
                        }

                        else if (authenticated == 0)
                        {
                            this.Details.Visibility = Visibility.Collapsed;
                            //this.Buttons.Visibility = Visibility.Collapsed;
                            if (!deletedRecords)
                            {
                                DeleteRecordsMethod();
                                deletedRecords = true;
                                Thread.Sleep(1000);
                            }


                            if (deletedRecords)
                            {
                                GetAuthStatus();
                            }
                            Thread.Sleep(1000);
                            return string.Format("We could not process the authentication. Please try again.");
                        }

                        else
                        {
                            this.Details.Visibility = Visibility.Collapsed;
                            //this.Buttons.Visibility = Visibility.Collapsed;
                            return string.Format(
                                "Welcome back {0}! I've sent a notification on your phone. Please confirm to proceed!",
                                names);
                        }

                    }
                }
            }
            else
            {
                if (img.DetectedFaces.Count() > 1)
                {
                    sentNotification = false;
                    authenticated = 2;
                    notificationCount = 0;
                    this.Details.Visibility = Visibility.Collapsed;
                    //this.Buttons.Visibility = Visibility.Collapsed;
                    return "Hi everyone! Welcome to Divergence Customer Collaboration Center..";

                }
                else
                {
                    sentNotification = false;
                    authenticated = 2;
                    notificationCount = 0;
                    this.Details.Visibility = Visibility.Collapsed;
                    //this.Buttons.Visibility = Visibility.Collapsed;
                    return "Hi there! Welcome to Divergence Customer Collaboration Center.";
                }
            }
        }

        public async void NotificationMethod()
        {
            string res = await SendNotification();
        }

        public async Task<string> SendNotification()
        {
            const string NotificationURL = "https://smart-banking.azurewebsites.net/notify";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(NotificationURL);
            request.Method = "GET";
            //request.ContentType = "application/json";
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                Debug.WriteLine(reader.ReadToEnd());
                DeleteRecordsMethod();
            }

            return "Sent notification";
        }

        public async void DeleteRecordsMethod()
        {
            string res = await DeleteRecords();

        }

        public async Task<string> DeleteRecords()
        {
            const string RemoveURL = "https://smart-banking.azurewebsites.net/auth/status/removeAll";
            WebRequest delRequest = WebRequest.Create(RemoveURL);
            delRequest.Method = "DELETE";
            //request.ContentType = "application/json";
            using (HttpWebResponse response = (HttpWebResponse)await delRequest.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                Debug.WriteLine(reader.ReadToEnd());
                sentNotification = true;
            }

            return "Deleted";
        }

        public async void GetAuthStatus()
        {
            string res = await CheckAuthStatus();
        }

        public async Task<string> CheckAuthStatus()
        {
            const string CheckURL = "https://smart-banking.azurewebsites.net/auth/status";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(CheckURL);
            request.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonString = reader.ReadToEnd();
                JArray jObject = JArray.Parse(jsonString);
                if (jObject.Count > 0)
                {
                    authenticated = (int)jObject[0].SelectToken("status");
                    if (authenticated == 0)
                    {
                        deletedRecords = false;
                    }
                }
            }
            return "Checked ";
        }

        private void UpdateUIForNoFacesDetected()
        {
            this.greetingTextBlock.Text = "Step in front of the camera to start";
            this.Details.Visibility = Visibility.Collapsed;
            //this.Buttons.Visibility = Visibility.Collapsed;
            this.greetingTextBlock.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
            this.greetingSymbol.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
            this.greetingSymbol.Symbol = Symbol.Contact;
            authenticated = 2;
            sentNotification = false;
            notificationCount = 0;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            EnterKioskMode();

            if (string.IsNullOrEmpty(SettingsHelper.Instance.FaceApiKey))
            {
                await new MessageDialog("Missing Face API Key. Please enter a key in the Settings page.", "Missing API Key").ShowAsync();
            }
            else
            {
                await this.cameraControl.StartStreamAsync(isForRealTimeProcessing: true);
                this.StartProcessingLoop();
            }

            base.OnNavigatedTo(e);
        }

        private void EnterKioskMode()
        {
            ApplicationView view = ApplicationView.GetForCurrentView();
            if (!view.IsFullScreenMode)
            {
                view.TryEnterFullScreenMode();
            }
        }

        protected override async void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.isProcessingLoopInProgress = false;
            Window.Current.Activated -= CurrentWindowActivationStateChanged;
            this.cameraControl.CameraAspectRatioChanged -= CameraControl_CameraAspectRatioChanged;

            await this.cameraControl.StopStreamAsync();
            base.OnNavigatingFrom(e);
        }

        private void OnPageSizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.UpdateCameraHostSize();
        }

        private void UpdateCameraHostSize()
        {
            this.cameraHostGrid.Width = this.cameraHostGrid.ActualHeight * (this.cameraControl.CameraAspectRatio != 0 ? this.cameraControl.CameraAspectRatio : 1.777777777777);
        }
    }
}