using System.ComponentModel;
using BaseApp.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(IosEntryRenderer))]

namespace BaseApp.iOS.Renderers {

    public class IosEntryRenderer : EntryRenderer {

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (Control != null) {
                Control.Layer.BorderWidth = 0;
                Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}