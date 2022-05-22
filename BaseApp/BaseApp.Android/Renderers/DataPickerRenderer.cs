﻿using Android.Content;
using Android.Graphics.Drawables;
using BaseApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DatePicker), typeof(BaseDatePickerRenderer))]

namespace BaseApp.Droid.Renderers {

    public class BaseDatePickerRenderer : DatePickerRenderer {

        public BaseDatePickerRenderer(Context context)
            : base(context) {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e) {
            base.OnElementChanged(e);
            if (Control != null) {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}