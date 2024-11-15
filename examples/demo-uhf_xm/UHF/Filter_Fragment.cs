using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Rscja.Deviceapi;

namespace UHF
{
    [Activity(Label = "Filter_Fragment")]
    public class Filter_Fragment : Fragment
    {
        MainActivity mContext;
        EditText etptr;
        EditText etlen;
        EditText etdata;
        RadioButton rbepc;
        RadioButton rbtid;
        RadioButton rbuser;
        Button btnset;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.popwindow_filter2, container, false);
            return view;
        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            mContext = (MainActivity)Activity;

            etptr = View.FindViewById<EditText>(Resource.Id.etPtr);
            etlen = View.FindViewById<EditText>(Resource.Id.etLen);
            etdata = View.FindViewById<EditText>(Resource.Id.etData);
            rbepc = View.FindViewById<RadioButton>(Resource.Id.rbEPC);
            rbtid = View.FindViewById<RadioButton>(Resource.Id.rbTID);
            rbuser = View.FindViewById<RadioButton>(Resource.Id.rbUser);
            btnset = View.FindViewById<Button>(Resource.Id.btSet);
          

            btnset.Click += delegate {
                if (string.IsNullOrEmpty(etptr.Text.Trim().ToString()))
                {
                    Toast.MakeText(mContext, "Start Address is null", ToastLength.Short).Show();
                    return;
                }
                if (string.IsNullOrEmpty(etlen.Text.Trim().ToString()))
                {
                    Toast.MakeText(mContext, "Length is null", ToastLength.Short).Show();
                    return;
                }

                int ptr = int.Parse(etptr.Text.Trim());
                int len = int.Parse(etlen.Text.Trim());
                String data = etdata.Text.Trim();
                if (len > 0)
                {
                    String rex = "[\\da-fA-F]*"; //匹配正则表达式，数据为十六进制格式
                                                 //if (string.IsNullOrEmpty(data) || Pattern...matches(rex, data)) //)!data.Matches(rex)|| Math.)
                                                 //{
                                                 //    Toast.MakeText(mContext, "Data isn't HEX", ToastLength.Short).Show();
                                                 //    //									mContext.playSound(2);
                                                 //    return;
                                                 //}
                    RFIDWithUHF.BankEnum bank;
                    if (rbepc.Checked)
                        bank = RFIDWithUHF.BankEnum.Uii;
                    else if (rbtid.Checked)
                        bank = RFIDWithUHF.BankEnum.Tid;
                    else if (rbuser.Checked)
                        bank = RFIDWithUHF.BankEnum.User;
                    else
                        bank = RFIDWithUHF.BankEnum.Uii;

              bool re=      mContext.uhfAPI.SetFilter(bank, ptr, len, data, false);
                    if(re)
                    {
                        Toast.MakeText(mContext, "Set Success", ToastLength.Short).Show();

                        this.OnDestroy();
                    }
                    else
                    {
                        Toast.MakeText(mContext, "Set Fail", ToastLength.Short).Show();
                    }


                }

                  

            };

        }
    }
}