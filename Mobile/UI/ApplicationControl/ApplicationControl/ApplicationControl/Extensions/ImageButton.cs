/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using Xamarin.Forms;
using Image = Xamarin.Forms.Image;

namespace ApplicationControl.Extensions
{
    /// <summary>
    /// A class for an image enable to get click events.
    /// It can use as a button.
    /// </summary>
    public class CustomImageButton : Image, IButtonController
    {
        /// <summary>
        /// The constructor for an image button
        /// </summary>
        public CustomImageButton() : base()
        {
            var gestureRecognizer = new LongTapGestureRecognizer();
            //When tap event is invoked. add pressed color to image.
            gestureRecognizer.TapStarted += (s, e) =>
            {
                //change foreground blend color of image
                ImageAttributes.SetBlendColor(this, Color.FromRgb(213, 228, 240));
            };

            //If tap is released. set default color to image.
            gestureRecognizer.TapCanceled += (s, e) =>
            {
                //revert foreground blend color of image
                ImageAttributes.SetBlendColor(this, Color.Default);
                SendClicked();
            };

            //If tap is completed. set default color to image.
            gestureRecognizer.TapCompleted += (s, e) =>
            {
                //revert foreground blend color of image
                ImageAttributes.SetBlendColor(this, Color.Default);
                SendClicked();
            };
            GestureRecognizers.Add(gestureRecognizer);

        }

        /// <summary>
        /// To broadcast a click event to subscribers
        /// </summary>
        public void SendClicked()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// To broadcast a press event to subscribers
        /// </summary>
        public void SendPressed()
        {
        }

        /// <summary>
        /// To broadcast a release event to subscribers
        /// </summary>
        public void SendReleased()
        {
        }

        public event EventHandler Clicked;
    }
}