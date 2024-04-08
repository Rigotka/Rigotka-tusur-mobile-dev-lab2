using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using System.Collections.Generic;

namespace lab2
{
	public class ViewsContainer : LinearLayout
    {
        private int _viewsCount = 0;

        private List<Item> _items = new List<Item>();

        public ViewsContainer(Context context) : base(context) { }
        public ViewsContainer(Context context, IAttributeSet attributeSet) : base(context, attributeSet) { }

        public void IncrementViews(bool checkBox)
        {
            Item itemView = new Item(Context);
            itemView.SetTextView1Text(_viewsCount.ToString());
            itemView.SetTextView2Text(_viewsCount.ToString());
            itemView.SetCheckBox(checkBox);
            AddView(itemView);
            _items.Add(itemView);
            _viewsCount++;
        }

        protected override IParcelable OnSaveInstanceState()
        {
            List<bool> temp = new List<bool>();
            foreach(Item item in _items)
            {
                temp.Add(item.GetCheckBox());
            }
            var state = new SavedState(base.OnSaveInstanceState(), _viewsCount, temp);
            return state;
        }

        protected override void OnRestoreInstanceState(IParcelable state)
        {
            if (!(state is SavedState))
            {
                base.OnRestoreInstanceState(state);
                return;
            }
            var s = (SavedState)state;
            base.OnRestoreInstanceState(state);
            var temp = s.CheckBoxes;
            for (var i = 0; i < s.ViewsCount; ++i)
            {
                IncrementViews(temp[i]);
            }
        }

    }
}

