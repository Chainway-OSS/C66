
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace UHF
{
	public class Set_Fragment : Fragment
	{
		Button btnGetFre;
		Button btnSetFre;
		Button btnGetPower;
		Button btnSetPower;
		Button btnGetTime;
		Button btnSetTime;
		EditText edtTxtWorkTime;
		EditText edtTxtWaitTime;
		Spinner spnWorkMode;
		Spinner spnPower;
		MainActivity mContext;
        Spinner spnsession;
        Spinner spnInventoried;
        Button btnsessionset;
        Button btnsessionget;
        CheckBox chbepc;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,Bundle savedInstanceState)
		{
			View view = inflater.Inflate (Resource.Layout.Set_Fragment,container,false);
			return view;
		}
		public override void OnActivityCreated(Bundle savedInstanceState) {
			base.OnActivityCreated (savedInstanceState);
		
			mContext = (MainActivity)Activity;
			btnGetFre = View.FindViewById<Button> (Resource.Id.btnGetFre);
			btnSetFre = View.FindViewById<Button> (Resource.Id.btnSetFre);
			btnGetPower = View.FindViewById<Button> (Resource.Id.btnGetPower);
			btnSetPower = View.FindViewById<Button> (Resource.Id.btnSetPower);
			btnGetTime = View.FindViewById<Button> (Resource.Id.btnGetTime);
			btnSetTime = View.FindViewById<Button> (Resource.Id.btnSetTime);
			edtTxtWorkTime = View.FindViewById<EditText> (Resource.Id.edtTxtTime);
			edtTxtWaitTime = View.FindViewById<EditText> (Resource.Id.edtTxtWait);
			spnWorkMode = View.FindViewById<Spinner> (Resource.Id.spnWorkMode);
			spnPower = View.FindViewById<Spinner> (Resource.Id.spnPower);
            spnsession = View.FindViewById<Spinner>(Resource.Id.spnSession);
            spnInventoried = View.FindViewById<Spinner>(Resource.Id.spnInventoried);
            btnsessionget = View.FindViewById<Button>(Resource.Id.btnGetSession);
            btnsessionset = View.FindViewById<Button>(Resource.Id.btnSetSession);
            chbepc = View.FindViewById<CheckBox>(Resource.Id.checkBox1);
            spnsession.SetSelection(1);
            spnInventoried.SetSelection(0);

            chbepc.CheckedChange += Chbepc_CheckedChange;

            btnGetFre.Click += delegate {
				GetFre();
			};
			btnSetFre.Click += delegate {
				SetFre();
			};
			btnGetPower.Click += delegate {
				GetPower();
			};
			btnSetPower.Click += delegate {
				SetPower();
			};
			btnGetTime.Click += delegate {
				GetTime();
			};
			btnSetTime.Click += delegate {
				SetTime();
			};
            btnsessionget.Click += Btnsessionget_Click;
            btnsessionset.Click += Btnsessionset_Click;
        }

        private void Chbepc_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (chbepc.Checked)
                mContext.uhfAPI.SetEPCTIDMode(true);
            else
                mContext.uhfAPI.SetEPCTIDMode(false);
        }

        private void Btnsessionset_Click(object sender, EventArgs e)
        {
            //设置SESSION只针对盘点EPC有效，对返回EPC+TID,EPC+TID+USER无效

            int seesionid = spnsession.SelectedItemPosition;
            int inventoried = spnInventoried.SelectedItemPosition;
            if (seesionid < 0 || inventoried < 0)
            {
                return;
            }
            char[] p = mContext.uhfAPI.GetGen2();
            if (p != null && p.Length >= 14)
            {
                int target = p[0];
                int action = p[1];
                int t = p[2];
                int q = p[3];
                int startQ = p[4];
                int minQ = p[5];
                int maxQ = p[6];
                int dr = p[7];
                int coding = p[8];
                int p1 = p[9];
                int Sel = p[10];
                int Session = p[11];
                int g = p[12];
                int linkFrequency = p[13];
                StringBuilder sb = new StringBuilder();
                sb.Append("target="); sb.Append(target);
                sb.Append(" ,action="); sb.Append(action);
                sb.Append(" ,t="); sb.Append(t);
                sb.Append(" ,q="); sb.Append(q);
                sb.Append(" startQ="); sb.Append(startQ);
                sb.Append(" minQ="); sb.Append(minQ);
                sb.Append(" maxQ="); sb.Append(maxQ);
                sb.Append(" dr="); sb.Append(dr);
                sb.Append(" coding="); sb.Append(coding);
                sb.Append(" p="); sb.Append(p1);
                sb.Append(" Sel="); sb.Append(Sel);
                sb.Append(" Session="); sb.Append(Session);
                sb.Append(" g="); sb.Append(g);
                sb.Append(" linkFrequency="); sb.Append(linkFrequency);
                sb.Append("seesionid="); sb.Append(seesionid);
                sb.Append(" inventoried="); sb.Append(inventoried);
                Log.Info("Session set", sb.ToString());
                if (mContext.uhfAPI.SetGen2(target, action, t, q, startQ, minQ, maxQ, dr, coding, p1, Sel, seesionid, inventoried, linkFrequency))
                {
                    Toast.MakeText(mContext, "success!", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(mContext, "Fail!", ToastLength.Short).Show();
                }
            }
            else
            {
                Toast.MakeText(mContext, "Fail!!", ToastLength.Short).Show();
            }
        }

        private void Btnsessionget_Click(object sender, EventArgs e)
        {
            char[] p = mContext.uhfAPI.GetGen2();
            if (p != null && p.Length >= 14)
            {
                int target = p[0];
                int action = p[1];
                int t = p[2];
                int q = p[3];
                int startQ = p[4];
                int minQ = p[5];
                int maxQ = p[6];
                int dr = p[7];
                int coding = p[8];
                int p1 = p[9];
                int Sel = p[10];
                int Session = p[11];
                int g = p[12];
                int linkFrequency = p[13];
                StringBuilder sb = new StringBuilder();
                sb.Append("target="); sb.Append(target);
                sb.Append(" ,action="); sb.Append(action);
                sb.Append(" ,t="); sb.Append(t);
                sb.Append(" ,q="); sb.Append(q);
                sb.Append(" startQ="); sb.Append(startQ);
                sb.Append(" minQ="); sb.Append(minQ);
                sb.Append(" maxQ="); sb.Append(maxQ);
                sb.Append(" dr="); sb.Append(dr);
                sb.Append(" coding="); sb.Append(coding);
                sb.Append(" p="); sb.Append(p1);
                sb.Append(" Sel="); sb.Append(Sel);
                sb.Append(" Session="); sb.Append(Session);
                sb.Append(" g="); sb.Append(g);
                sb.Append(" linkFrequency="); sb.Append(linkFrequency);
                Log.Info("Session get", sb.ToString());
                spnsession.SetSelection(Session);
                spnInventoried.SetSelection(g);

            }
            else
                Toast.MakeText(mContext, "Fail!", ToastLength.Short).Show();
        }

        public override void OnResume() {
			base.OnResume();
			GetFre();
			GetPower();
			//GetTime();
		}
		private void SetFre()
		{
			sbyte iFre = (sbyte)spnWorkMode.SelectedItemPosition;
			if (mContext.uhfAPI.SetFrequencyMode(iFre)) 
			{
				Toast.MakeText (mContext,"success!",ToastLength.Short).Show();
			} 
			else 
			{
				Toast.MakeText (mContext,"failuer!",ToastLength.Short).Show();
			}

		}
		private void GetFre()
		{
			int idx = mContext.uhfAPI.FrequencyMode;

			if (idx != -1)
			{
				int count = spnWorkMode.Count;
				spnWorkMode.SetSelection(idx > count - 1 ? count - 1 : idx);
			} 
			else
			{
				Toast.MakeText (mContext,"failuer!",ToastLength.Short).Show();
			}
		}
			
		public void GetPower() {
			int iPower = mContext.uhfAPI.Power;
			if (iPower > -1) {
				int position = iPower - 5;
				int count = spnPower.Count;
				spnPower.SetSelection(position > count - 1 ? count - 1 : position);
			}
			else 
			{
				Toast.MakeText (mContext,"failuer!",ToastLength.Short).Show();
			}

		}
		public void SetPower() {
			int iPower = spnPower.SelectedItemPosition + 5;
		
			if (mContext.uhfAPI.SetPower(iPower)) 
			{
				Toast.MakeText (mContext,"success!",ToastLength.Short).Show();
			} 
			else 
			{
				Toast.MakeText (mContext,"failuer!",ToastLength.Short).Show();
			}

		}


		public void GetTime() {
			int[] pwm = mContext.uhfAPI.GetPwm();
			if (pwm == null||pwm.Length<2)
			{
				Toast.MakeText (mContext,"failuer!",ToastLength.Short).Show();
				return;
			}
			edtTxtWorkTime.SetText(pwm[0]);
			edtTxtWaitTime.SetText(pwm[1]);

		}

		public void SetTime() 
		{
			try
			{
				int workTime = int.Parse (edtTxtWorkTime.Text);
				int waitTime = int.Parse (edtTxtWaitTime.Text);
				if(mContext.uhfAPI.SetPwm(workTime,waitTime)) 
				{
					Toast.MakeText (mContext,"success!",ToastLength.Short).Show();
				} 
				else 
				{
					Toast.MakeText (mContext,"failuer!",ToastLength.Short).Show();
				}
			}
			catch
			{

			}

		}
	}
}

