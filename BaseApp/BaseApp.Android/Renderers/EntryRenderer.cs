using Android.Content;
using Android.Graphics.Drawables;
using BaseApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(BaseEntryRenderer))]

namespace BaseApp.Droid.Renderers {

    public class BaseEntryRenderer : EntryRenderer {

        public BaseEntryRenderer(Context context)
            : base(context) {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);
            if (Control != null) {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}