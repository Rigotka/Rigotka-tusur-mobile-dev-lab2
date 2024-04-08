using Android.OS;
using Android.Runtime;
using static Android.Preferences.Preference;
using System.Collections.Generic;

namespace lab2
{
	public class SavedState : BaseSavedState
    {
        public int ViewsCount { get; set; }

        public List<bool> CheckBoxes { get; set; }

        public SavedState(IParcelable state, int viewsCount, List<bool> checkBoxes) : base(state)
        {
            ViewsCount = viewsCount;
            CheckBoxes = checkBoxes;
        }

        public override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            base.WriteToParcel(dest, flags);
            dest.WriteInt(ViewsCount);
            dest.WriteList(CheckBoxes);
        }
    }
}

