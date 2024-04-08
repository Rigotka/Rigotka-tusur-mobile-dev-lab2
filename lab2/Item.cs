using Android.Content;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace lab2
{
	public class Item : RelativeLayout
    {
        private TextView _textView1;

        private TextView _textView2;

        public CheckBox _checkBox;

        public Item(Context context) : base(context)
        {
            Initialize(context, null);
        }

        public Item(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize(context, attrs);
        }

        public Item(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Initialize(context, attrs);
        }

        private void Initialize(Context context, IAttributeSet attrs)
        {
            LayoutInflater.From(context).Inflate(Resource.Layout.item_layout, this, true);

            _textView1 = FindViewById<TextView>(Resource.Id.textView1);
            _textView2 = FindViewById<TextView>(Resource.Id.textView2);
            _checkBox = FindViewById<CheckBox>(Resource.Id.checkBox);
        }

        public void SetTextView1Text(string text)
        {
            _textView1.Text += text;
        }

        public void SetTextView2Text(string text)
        {
            _textView2.Text += text;
        }

        public void SetCheckBox(bool status)
        {
            _checkBox.Checked = status;
        }

        public bool GetCheckBox()
        {
            return _checkBox.Checked;
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            if (e.Action == MotionEventActions.Down)
            {
                _checkBox.Toggle();
            }
            return base.OnTouchEvent(e);
        }
    }
}

